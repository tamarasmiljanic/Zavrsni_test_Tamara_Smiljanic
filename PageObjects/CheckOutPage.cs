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
    class CheckOutPage
    {
        IWebDriver driver;
        WebDriverWait wait;

        public CheckOutPage(IWebDriver driver)
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

        public IWebElement OrderHistory
        {
            get
            {
                return this.getElement(By.XPath("//a[@href='/history']"));
            }
        }

        public History ClickOnOrderHistory()
        {
            this.OrderHistory?.Click();
            return new History(this.driver);
        }
    }
}
