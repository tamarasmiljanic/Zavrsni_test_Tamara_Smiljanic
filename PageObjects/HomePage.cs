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
    class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
         public void GoToPage()
        {
            this.driver.Navigate().GoToUrl("http://shop.qa.rs/");
        }

        public IWebElement FindElement(By by)
        {
            IWebElement element;
            try
            {
                element = this.driver.FindElement(by);
            }catch(Exception)
            {
                element = null;
            }
            return element;
        }

        public IWebElement LoginLink
        {
            get
            {
                return FindElement(By.XPath("//a[@href='/login']"));
            }
        }

        public IWebElement RegisterLink
        {
            get
            {
                return FindElement(By.XPath("//a[@href='/register']"));
            }
        }

        public IWebElement SucessfulRegistration
        {
            get
            {
                return FindElement(By.XPath("//div[@class='alert alert-success']/strong[contains(text(),'Uspeh!')]"));
            }
        }

        public IWebElement WelcomeBack
        {
            get
            {
                wait.Until(EC.ElementIsVisible(By.XPath("//h2[contains(text(),'Welcome back,')]")));
                return this.FindElement(By.XPath("//h2[contains(text(),'Welcome back,')]"));
            }
        }

        public RegistrationPage ClickOnRegisterLink()
        {
            wait.Until(EC.ElementIsVisible(By.XPath("//a[@href='/register']")));
            this.RegisterLink?.Click();
            return new RegistrationPage(this.driver);
        }

        public LoginPage ClickOnLogIn()
        {
            wait.Until(EC.ElementIsVisible(By.XPath("//a[@href='/login']")));
            this.LoginLink?.Click();
            return new LoginPage(this.driver);
        }

    }
}
