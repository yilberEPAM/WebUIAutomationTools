using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CrossBrowser.Utilities
{
    public class TestBase
    {
        protected IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            string browser = TestContext.Parameters.Get("browser", "chrome");
            driver = BrowserConfig.GetWebDriver(browser);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((int)BrowserConfig.Config["implicitWait"]);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
