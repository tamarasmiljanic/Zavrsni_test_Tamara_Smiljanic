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
    class LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
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

        public IWebElement UserNameInput
        {
            get
            {
                IWebElement element;
                try
                {
                    element = this.driver.FindElement(By.Name("username"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }
        }

        public IWebElement PasswordInput
        {
            get
            {
                return FindElement(By.Name("password"));
            }
        }

        public IWebElement LogInBtn
        {
            get
            {
                return FindElement(By.Name("login"));
            }
        }

        public IWebElement ForgotPassLink
        {
            get
            {
                return FindElement(By.XPath("//a[@href='forgot']"));
            }
        }

        public IWebElement RegisterLink
        {
            get
            {
                return FindElement(By.XPath("//a[@href='/register']"));
            }
        }

        public HomePage FillLoginData()
        {
            this.UserNameInput?.SendKeys("tamara1979");
            this.PasswordInput?.SendKeys("Smiljka1979");
            this.LogInBtn?.Click();
            wait.Until(EC.ElementIsVisible(By.XPath("//a[@class='navbar-brand']")));
            return new HomePage(this.driver);

        }
    }
}
