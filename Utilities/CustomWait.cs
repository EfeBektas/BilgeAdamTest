using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilgeAdamTest.Utilities;


public class WaitTimeoutException : Exception
{
    public WaitTimeoutException(string message) : base(message)
    {
    }

}
public static class CustomWait
{

    public static void WaitForUrlToBe(IWebDriver driver, string expectedUrl, int timeoutSeconds = 5)
    {
        var start = DateTime.Now;

        while ((DateTime.Now - start).TotalSeconds < timeoutSeconds)
        {
            if (driver.Url.Contains(expectedUrl))
                return;

            Thread.Sleep(200); // CPU'yu yormadan beklet
        }

        throw new WaitTimeoutException($"URL expected to contain '{expectedUrl}', but was '{driver.Url}'");
    }
}
