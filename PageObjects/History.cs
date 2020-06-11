using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Text.RegularExpressions;

namespace ZavrsniTest_SmiljanicTamara.PageObjects
{
    class History
    {
        IWebDriver driver;
        WebDriverWait wait;

        public History(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        public IWebElement getElement(By by)
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

        public int orderNum
        {
            get
            {
                int num = 0;
                try
                {
                    IWebElement element = this.getElement(By.XPath("//tbody/tr[1]/td[@class='order']"));
                    string text = Regex.Replace(element.Text,"[^0-9]","");
                    num = Convert.ToInt32(text);
                }
                catch (Exception)
                {

                }
                return num;
            }
        }

        public double orderAmount
        {
            get
            {
                double num = 0;
                try
                {
                    IWebElement element = this.getElement(By.XPath("//tbody/tr[1]/td[@class='total']"));
                    string text = Regex.Replace(element.Text, "[^0-9]", "");
                    num = Convert.ToDouble(text);
                }
                catch (Exception)
                {

                }
                return num;
            }
        }
    }
}
