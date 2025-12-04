using BilgeAdamTest.Pages;
using BilgeAdamTest.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdamTest.Tests
{
    public class CartTests : BaseTest
    {
        [Test]
        public void AddMultipleProductsToCart_FromJson()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            Console.WriteLine(Path.Combine(Directory.GetCurrentDirectory(), "TestData", "products.json"));

            // 1. Login
            _driver.Navigate().GoToUrl(ConfigReader.BaseUrl);
            var loginPage = new LoginPage(_driver);
            loginPage.Login(ConfigReader.Username, ConfigReader.Password);

            var productsPage = new ProductsPage(_driver);

            // 2. JSON'dan ürünleri oku
            var data = DataReader.LoadProducts();


            string ConvertToProductName(string id)
            {
                string name = id.Replace("-", " ");

                // T Shirt → T-Shirt düzeltmesi
                name = name.Replace("t shirt", "t-shirt");

                // Title Case
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
            }

            foreach (var product in data.Products)
            {
                productsPage.AddProductToCart(product.Id);
            }

            // 4. Sepete git
            productsPage.GoToCart();

            var cartPage = new CartPage(_driver);

            // 5. Sepetteki ürünleri oku
            var cartNames = cartPage.GetProductNames();

            // 6. JSON’daki ürünler gerçekten sepette mi?
            foreach (var product in data.Products)
            {
                string expectedName = ConvertToProductName(product.Id);

                Assert.That(cartNames, Does.Contain(expectedName));

            }

        }
    }
}

