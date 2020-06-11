using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using ZavrsniTest_SmiljanicTamara.PageObjects;
using NUnit.Framework.Internal;
using Microsoft.Office.Interop.Excel;

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
            this.driver = new FirefoxDriver();
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
        }

        [Test]
        [Category("shop.qa.rs")]
        public void TestLogin()
        {
            HomePage home = new HomePage(this.driver);
            home.GoToPage();
            LoginPage login = home.ClickOnLogIn();
            home = login.FillLoginData("tamara1979","Smiljka1979");
            //System.Threading.Thread.Sleep(4000);
            if (home.WelcomeBack != null)
            {
                TestContext.WriteLine("Successful login");
                home = home.AddToCart();
                CartPage cart = home.ClickOnCartLink();
                System.Threading.Thread.Sleep(4000);
                //double CartTotal = cart.Total;
                //int OrderNumber = cart.orderNum;
                CheckOutPage checkout = cart.ClickOnCheckOut();
                System.Threading.Thread.Sleep(4000);
                double CheckTotal = checkout.TotalAmount;
                int checkNumber = checkout.OrderNumber;
                History historyTable = checkout.ClickOnOrderHistory();
                System.Threading.Thread.Sleep(4000);
                double historyTotal = historyTable.orderAmount;
                int historyOrderNum = historyTable.orderNum;
                if ((CheckTotal == historyTotal) && (checkNumber == historyOrderNum))
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
        
            }
            else
            {
                TestContext.WriteLine("Unsuccessful login");
            
            }
        }

        [TearDown]
        public void TearDown()
        {
            this.driver.Close();
        }
    }
}
