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

        public SelectElement ListItem(By by)
        {
            IWebElement element;
            SelectElement item;
            try
            {
                element = FindElement(by);
                item = new SelectElement(element);
            }
            catch (Exception)
            {
                item = null;
            }
            return item;
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

        public SelectElement Quantity1
        {
            get
            {
                return ListItem(By.XPath("//div[@class='col-sm-3 text-center'][1]/div[@class='panel panel-default']/div[@class='panel-body text-justify']/form/p[@class='text-center']/select"));
            }
        }

        public SelectElement Quantity2
        {
            get
            {
                return ListItem(By.XPath("/html/body/div[@class='container']/div[@class='row'][4]/div[@class='col-sm-3 text-center'][4]/div[@class='panel panel-success']/div[@class='panel-body text-justify']/form/p[@class='text-center']/select"));
            }
        }

        public  IWebElement Order1
        {
            get
            {
                return FindElement(By.XPath("//div[@class='col-sm-3 text-center'][1]/div[@class='panel panel-default']/div[@class='panel-body text-justify']/form/p[@class='text-center margin-top-20']/input[@class='btn btn-primary']"));
            }
        }

        public IWebElement Order2
        {
            get
            {
                return FindElement(By.XPath("//div[@class='col-sm-3 text-center'][4]/div[@class='panel panel-success']/div[@class='panel-body text-justify']/form/p[@class='text-center margin-top-20']/input[@class='btn btn-primary']"));
            }
        }
        public IWebElement SucessfulRegistration
        {
            get
            {
                this.wait.Until(EC.ElementIsVisible(By.XPath("//div[@class='alert alert-success']/strong[contains(text(),'Uspeh!')]")));
                return FindElement(By.XPath("//div[@class='alert alert-success']/strong[contains(text(),'Uspeh!')]"));
            }
        }

        public IWebElement WelcomeBack
        {
            get
            {
                IWebElement element;
                try
                {
                    element = this.wait.Until(EC.ElementIsVisible(By.XPath("//h2[contains(text(),'Welcome back,')]")));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }
        }

        public IWebElement CartLink
        {
            get
            {
                return FindElement(By.XPath("//a[@href='/cart']"));
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
        
        public HomePage AddToCart()
        {
            this.Quantity1?.SelectByValue("2");
            this.Order1?.Click();
            CartPage cart = new CartPage(this.driver);
            cart.ContinueShoping?.Click();
            this.Quantity2?.SelectByValue("3");
            this.Order2?.Click();
            cart.ContinueShoping?.Click();
            
            return new HomePage(this.driver);
        }
        public CartPage ClickOnCartLink()
        {
            this.CartLink?.Click();
            return new CartPage(this.driver);
        }

    }
}
