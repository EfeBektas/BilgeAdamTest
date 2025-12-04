using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace BilgeAdamTest.Pages
{
    internal class CartPage
    {
        private IWebDriver _driver;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Sepetteki ürün adlarını almak
        public List<string> GetProductNames()
        {
            var elements = _driver.FindElements(By.ClassName("inventory_item_name"));
            return elements.Select(e => e.Text).ToList();
        }

        // Sepetteki ürün fiyatlarını almak
        public List<string> GetProductPrices()
        {
            var elements = _driver.FindElements(By.ClassName("inventory_item_price"));
            return elements.Select(e => e.Text).ToList();
        }

        // Sepetteki miktarları almak
        public List<string> GetQuantities()
        {
            var elements = _driver.FindElements(By.ClassName("cart_quantity"));
            return elements.Select(e => e.Text).ToList();
        }
    }
}

