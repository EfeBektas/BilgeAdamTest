using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using BilgeAdamTest.Drivers;

namespace BilgeAdamTest.Tests
{
    public class BaseTest
    {
        protected IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = DriverFactory.CreateDriver();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
