﻿using System;
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
    class RegistrationPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public static string user;
        public static string pass;

        public RegistrationPage(IWebDriver driver)
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

        public IWebElement FirstName
        {
            get
            {
                return FindElement(By.Name("ime"));
            }
        }

        public IWebElement LasttName
        {
            get
            {
                return FindElement(By.Name("prezime"));
            }
        }

        public IWebElement Email
        {
            get
            {
                return FindElement(By.Name("email"));
            }
        }

        public IWebElement UserName
        {
            get
            {
                return FindElement(By.Name("korisnicko"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return FindElement(By.Name("lozinka"));
            }
        }

        public IWebElement ConfirmPassword
        {
            get
            {
                return FindElement(By.Name("lozinkaOpet"));
            }
        }

        public IWebElement RegisterBtn
        {
            get
            {
                return FindElement(By.Name("register"));
            }
        }

        public IWebElement ResetBtn
        {
            get
            {
                return FindElement(By.Name("reset"));
            }
        }

        public void PressResetBtn()
        {
            this.FirstName?.Clear();
            this.LasttName?.Clear();
            this.Email?.Clear();
            this.UserName?.Clear();
            this.Password?.Clear();
            this.ConfirmPassword?.Clear();
        }

        public HomePage PressRegisterBtn()
        {
            this.FirstName?.SendKeys("Tamara");
            this.LasttName?.SendKeys("Smiljanic");
            this.Email?.SendKeys("tamarasmiljanic@gmail.com");
            this.UserName?.SendKeys("smiljka1979");
            user = this.UserName?.Text;
            this.Password?.SendKeys("Smiljka1979");
            pass = this.Password?.Text;
            this.ConfirmPassword?.SendKeys(pass);
            return new HomePage(this.driver);
        }

        public string ReturnUserName()
        {
            return user;
        }
        public string ReturnPassword()
        {
            return pass;
        }




    }
}