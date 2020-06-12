using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Text.RegularExpressions;

namespace ZavrsniTest_SmiljanicTamara.PageObjects
{
    class CartPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement FindElement(By by)
        {
            IWebElement element;
            try
            {
                element = this.driver.FindElement(by);
            }
            catch (Exception)
            {
                element = null;
            }
            return element;
        }

        public IWebElement ContinueShoping
        {
            get
            {
                return this.FindElement(By.XPath("//a[contains(text(),'Continue shopping')]"));
            }
        }

        public IWebElement CheckOut
        {
            get
            {
                return this.FindElement(By.Name("checkout"));
            }
        }

        public double Total
        {
            get
            {
                IWebElement totalTd;
                double totalNum=0;
                try
                {
                    totalTd = this.driver.FindElement(By.XPath("//td[contains(text(),'Total:')]"));
                    string totalWithchar= Regex.Replace(totalTd.Text, "[^0-9]", "");
                    totalNum = Convert.ToDouble(totalWithchar);
                }
                catch (Exception)
                {

                }
                return totalNum;
            }
        }

        public int orderNum
        {
            get
            {
                int num = 0;
                try
                {
                    IWebElement element = this.FindElement(By.XPath("//h1[contains(text(),'Quality Assurance ')]"));
                    string text = Regex.Replace(element.Text, "[^0-9]", "");
                    num = Convert.ToInt32(text);
                }
                catch (Exception)
                {

                }
                return num;
            }
        }

        public HomePage ContinueShopingOnHomePage()
        {
            this.ContinueShoping?.Click();
            return new HomePage(this.driver);
        }

        public CheckOutPage ClickOnCheckOut()
        {
            this.CheckOut?.Click();
            return new CheckOutPage(this.driver);
        }
    }
}
