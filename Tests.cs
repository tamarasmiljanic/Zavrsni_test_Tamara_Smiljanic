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
        public void TestShopQARS()
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

            home.GoToPage();
            LoginPage login = home.ClickOnLogIn();
            home = login.FillLoginData(username,password);
            
            if (home.WelcomeBack != null)
            {
                TestContext.WriteLine("Successful login");
                home = home.AddToCart();
                TestContext.WriteLine("Selected items are added to shoping cart successfully.");
                CartPage cart = home.ClickOnCartLink();
                TestContext.WriteLine("View shoping cart from Home Page is valid link");
                
                CheckOutPage checkout = cart.ClickOnCheckOut();
                
                double CheckTotal = checkout.TotalAmount;
                int checkNumber = checkout.OrderNumber;
                TestContext.WriteLine("Amount to pay from Checkout page: {0} Order number from checkout page: {1}", CheckTotal, checkNumber);
                History historyTable = checkout.ClickOnOrderHistory();
                
                double historyTotal = historyTable.orderAmount;
                int historyOrderNum = historyTable.orderNum;
                TestContext.WriteLine("Amount to pay from histry  page: {0} Order number from history page: {1}", historyTotal, historyOrderNum);
                if ((CheckTotal == historyTotal/100) && (checkNumber == historyOrderNum))
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
