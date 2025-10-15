using NUnit.Framework;
using OpenQA.Selenium;

namespace CrossBrowser.Utilities
{
    public class TestBase
    {
        protected IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            string browser = "chrome"; 
            driver = BrowserConfig.GetWebDriver(browser);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
