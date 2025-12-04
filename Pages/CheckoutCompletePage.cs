using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BilgeAdamTest.Pages
{
    internal class CheckoutCompletePage
    {
        private IWebDriver _driver;

        public CheckoutCompletePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement Header => _driver.FindElement(By.ClassName("complete-header"));
        private IWebElement BackHomeButton => _driver.FindElement(By.Id("back-to-products"));

        public bool IsOrderComplete()
        {
            return Header.Text.Contains("Thank you", StringComparison.OrdinalIgnoreCase);
        }

        public void BackToProducts()
        {
            BackHomeButton.Click();
        }
    }
}

