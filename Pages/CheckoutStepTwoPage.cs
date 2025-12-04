using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BilgeAdamTest.Pages
{
    internal class CheckoutStepTwoPage
    {
        private IWebDriver _driver;

        public CheckoutStepTwoPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement ItemTotalLabel => _driver.FindElement(By.ClassName("summary_subtotal_label"));
        private IWebElement TaxLabel => _driver.FindElement(By.ClassName("summary_tax_label"));
        private IWebElement TotalLabel => _driver.FindElement(By.ClassName("summary_total_label"));
        private IWebElement FinishButton => _driver.FindElement(By.Id("finish"));

        public string GetItemTotal() => ItemTotalLabel.Text;
        public string GetTax() => TaxLabel.Text;
        public string GetTotal() => TotalLabel.Text;

        public void FinishOrder()
        {
            FinishButton.Click();
        }
    }
}
