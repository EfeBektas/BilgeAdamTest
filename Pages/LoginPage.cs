using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BilgeAdamTest.Pages
{
    internal class LoginPage
    {
        private IWebDriver _driver;
        private IWebElement ErrorMessage => _driver.FindElement(By.CssSelector("[data-test='error']"));

        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }

        // Constructor
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Locators
        private IWebElement UsernameInput => _driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));

        // Actions
        public void Login(string username, string password)
        {
            UsernameInput.SendKeys(username);
            PasswordInput.SendKeys(password);
            LoginButton.Click();
        }
    }
}


