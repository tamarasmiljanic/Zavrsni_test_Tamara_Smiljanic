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
using ZavrsniTest_SmiljanicTamara.PageObjects;
using NUnit.Framework.Internal;

namespace ZavrsniTest_SmiljanicTamara
{
    class Tests
    {
        IWebDriver driver;
        WebDriverWait wait;
        string username,password;

        [SetUp]
        public void SetUp()
        {
            this.driver = new ChromeDriver();
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();
        }

        [Test]
        [Category("shop.qa.rs")]
        public void TestRegistration()
        {
            HomePage home = new HomePage(this.driver);
            home.GoToPage();
            RegistrationPage register = home.ClickOnRegisterLink();
            home = register.PressRegisterBtn();
            username = register.ReturnUserName();
            password = register.ReturnPassword();
            if (home.SucessfulRegistration != null)
            {
                TestContext.WriteLine("User registered successfuly");
            }
            else
            {
                TestContext.WriteLine("User isn't registered");
            }
            LoginPage login = home.ClickOnLogIn();
            home = login.ClickOnLoginBtn(username,password);
            if (home.WelcomeBack !=null)
            {
                TestContext.WriteLine("Success");
            }
            else
            {
                TestContext.WriteLine("Unsuccessful login");
            }
        }

        /*[Test]
        [Category("shop.qa.rs")]
        public void TestLogin()
        {
            HomePage home = new HomePage(this.driver);
            home.GoToPage();
            LoginPage login = home.ClickOnLogIn();
            home = login.ClickOnLoginBtn(ListOfUsers[0]);
            if (home.WelcomeBack!=null)
            {
                TestContext.WriteLine("User is successfuly login");
            }
            else
            {
                TestContext.WriteLine("Such user does not exist");
            }
        }*/

        [TearDown]
        public void TearDown()
        {
            this.driver.Close();
        }
    }
}
