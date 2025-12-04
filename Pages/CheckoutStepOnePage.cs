using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BilgeAdamTest.Pages
{
    internal class CheckoutStepOnePage
    {
        private IWebDriver _driver;

        public CheckoutStepOnePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement FirstName => _driver.FindElement(By.Id("first-name"));
        private IWebElement LastName => _driver.FindElement(By.Id("last-name"));
        private IWebElement PostalCode => _driver.FindElement(By.Id("postal-code"));
        private IWebElement ContinueButton => _driver.FindElement(By.Id("continue"));

        public void FillInformation(string first, string last, string postal)
        {
            FirstName.SendKeys(first);
            LastName.SendKeys(last);
            PostalCode.SendKeys(postal);
            ContinueButton.Click();
        }
    }
}

