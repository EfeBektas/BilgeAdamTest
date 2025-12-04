using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BilgeAdamTest.Pages
{
    internal class ProductsPage
    {
        private IWebDriver _driver;

        public ProductsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Örnek locator: Products sayfasının başlığı
        private IWebElement PageTitle => _driver.FindElement(By.ClassName("title"));

        // Products sayfasında olup olmadığını doğrulama
        public bool IsAtProductsPage()
        {
            return PageTitle.Text == "Products";
        }
        public void AddProductToCart(string productId)
        {
            var button = _driver.FindElement(By.Id($"add-to-cart-{productId}"));
            button.Click();
        }
        public void GoToCart()
        {
            var cartIcon = _driver.FindElement(By.Id("shopping_cart_container"));
            cartIcon.Click();
        }


    }
}

