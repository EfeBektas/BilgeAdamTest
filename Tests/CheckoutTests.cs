using BilgeAdamTest.Pages;
using BilgeAdamTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace BilgeAdamTest.Tests
{
    public class CheckoutTests : BaseTest
    {
        [Test]
        public void CompleteOrderAndVerifySummary()
        {
            _driver.Navigate().GoToUrl(ConfigReader.BaseUrl);
            var loginPage = new LoginPage(_driver);
            loginPage.Login(ConfigReader.Username, ConfigReader.Password);

            var productsPage = new ProductsPage(_driver);
            productsPage.AddProductToCart("sauce-labs-backpack");
            productsPage.GoToCart();

            var cartPage = new CartPage(_driver);
            _driver.FindElement(By.Id("checkout")).Click();

            var stepOne = new CheckoutStepOnePage(_driver);
            stepOne.FillInformation("Efe", "Bektas", "34000");

            var stepTwo = new CheckoutStepTwoPage(_driver);

            string itemTotalText = stepTwo.GetItemTotal();
            string taxText = stepTwo.GetTax();
            string totalText = stepTwo.GetTotal();

            // Rakamları ayıklama
            decimal itemTotal = decimal.Parse(itemTotalText.Replace("Item total: $", ""), CultureInfo.InvariantCulture);
            decimal tax = decimal.Parse(taxText.Replace("Tax: $", ""), CultureInfo.InvariantCulture);
            decimal total = decimal.Parse(totalText.Replace("Total: $", ""), CultureInfo.InvariantCulture);


            decimal rawTax = itemTotal * 0.08m;
            decimal expectedTax = Math.Ceiling(rawTax * 100) / 100;
            decimal expectedTotal = itemTotal + expectedTax;

            Assert.That(tax, Is.EqualTo(expectedTax), "Vergi yanlış hesaplanmış!");
            Assert.That(total, Is.EqualTo(expectedTotal), "Total hesaplaması hatalı!");

            // Siparişi tamamla
            stepTwo.FinishOrder();

            // Sipariş tamamlandı sayfasını doğrula
            var completePage = new CheckoutCompletePage(_driver);
            Assert.That(completePage.IsOrderComplete(), Is.True, "Sipariş tamamlama mesajı görüntülenmedi.");

            completePage.BackToProducts();
            productsPage = new ProductsPage(_driver);
            productsPage.AddProductToCart("sauce-labs-backpack");

            var removeButton = _driver.FindElement(By.Id("remove-sauce-labs-backpack"));
            Assert.That(removeButton.Displayed, Is.True, "Ürün tekrar sepete eklenmedi → stok uyarısı olabilir!");

        }
    }
}
