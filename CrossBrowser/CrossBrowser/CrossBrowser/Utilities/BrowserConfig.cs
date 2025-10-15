using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;

namespace CrossBrowser.Utilities
{
    public class BrowserConfig
    {
        public static IWebDriver GetWebDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    return new ChromeDriver();
                case "firefox":
                    return new FirefoxDriver();
                case "edge":
                    return new EdgeDriver();
                default:
                    throw new ArgumentException($"El navegador '{browser}' no está soportado.");
            }
        }
    }
}
