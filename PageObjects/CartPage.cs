using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

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
    }
}
