using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using ZavrsniTest_SmiljanicTamara.PageObjects;
using NUnit.Framework.Internal;


namespace ZavrsniTest_SmiljanicTamara
{
    class Tests
    {
        IWebDriver driver;
        WebDriverWait wait;
       
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
            home = login.FillLoginData("tamara1979","Smiljka1979");
            
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
                
                History historyTable = checkout.ClickOnOrderHistory();
                
                double historyTotal = historyTable.orderAmount;
                int historyOrderNum = historyTable.orderNum;
                
                if ((CheckTotal == historyTotal) && (checkNumber == historyOrderNum))
                {
                    TestContext.WriteLine("Amount and order number are equal on  checkout and history page.");
                    Assert.Pass();
                }
                else
                {
                    TestContext.WriteLine("Amount and order number aren't equal on  checkout and history page.");
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
