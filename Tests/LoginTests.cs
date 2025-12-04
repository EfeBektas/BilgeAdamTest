using BilgeAdamTest.Pages;
using BilgeAdamTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BilgeAdamTest.Tests
{
    public class LoginTests : BaseTest
    {
        [Test]
        public void SuccessfulLoginTest()
        {
            _driver.Navigate().GoToUrl(ConfigReader.BaseUrl);

            var loginPage = new LoginPage(_driver);
            loginPage.Login(ConfigReader.Username, ConfigReader.Password);
            var productsPage = new ProductsPage(_driver);

            Assert.That(productsPage.IsAtProductsPage(), Is.True, "Login fail.");


        }
        [Test]
        public void InvalidLoginTest()
        {
            _driver.Navigate().GoToUrl(ConfigReader.BaseUrl);

            var loginPage = new LoginPage(_driver);

            loginPage.Login("wrong_user", "wrong_pass");

            Assert.That(loginPage.GetErrorMessage(), Does.Contain("Epic sadface"),
                "Unexpected error message");
        }
        [Test]
        public void UnauthorizedPageAccessTest()
        {
            _driver.Navigate().GoToUrl(ConfigReader.BaseUrl);
            var loginPage = new LoginPage(_driver);
            loginPage.Login(ConfigReader.Username, ConfigReader.Password);

            _driver.Navigate().GoToUrl("https://www.saucedemo.com/inventory-item.html?id=9999");

            CustomWait.WaitForUrlToBe(_driver, "inventory.html");

            var productsPage = new ProductsPage(_driver);


            Assert.That(productsPage.IsAtProductsPage(), Is.True,
                "redirect gerçekleşmedi");
        }



    }

}

