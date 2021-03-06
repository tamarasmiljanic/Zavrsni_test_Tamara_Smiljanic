﻿using System;
using OpenQA.Selenium;
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

        public HomePage FillLoginData(string user,string pass)
        {
            this.UserNameInput?.SendKeys(user);
            this.PasswordInput?.SendKeys(pass);
            this.LogInBtn?.Click();
            //wait.Until(EC.ElementIsVisible(By.XPath("//a[@class='navbar-brand']")));
            return new HomePage(this.driver);

        }
    }
}
