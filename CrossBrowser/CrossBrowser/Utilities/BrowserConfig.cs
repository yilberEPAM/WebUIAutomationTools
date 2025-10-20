using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;
using Newtonsoft.Json;
using System.IO;

namespace CrossBrowser.Utilities
{
    public class BrowserConfig
    {
        public static dynamic Config { get; private set; }

        static BrowserConfig()
        {
            string configPath = Path.Combine(Directory.GetCurrentDirectory(), "Configuration", "config.json");
            Config = JsonConvert.DeserializeObject(File.ReadAllText(configPath));
        }

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
