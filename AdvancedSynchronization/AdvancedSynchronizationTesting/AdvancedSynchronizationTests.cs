using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AdvancedSynchronizationTesting
{
    [TestFixture]
    public class AdvancedSynchronizationTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private const string TestUrl = "https://the-internet.herokuapp.com/dynamic_loading/1";

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(TestUrl);

            // Explicit wait: 10 seconds timeout, polling every 500ms
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void WaitForElementToBeVisible_ExplicitWait()
        {
            driver.FindElement(By.CssSelector("#start button")).Click();

            // Wait for the loading spinner to disappear and the result to be visible
            IWebElement result = wait.Until(drv =>
            {
                var element = drv.FindElement(By.Id("finish"));
                return element.Displayed ? element : null;
            });

            Assert.That(result.Text, Is.EqualTo("Hello World!"));
        }

        [Test]
        public void WaitForTextToAppear_CustomExpectedCondition()
        {
            driver.FindElement(By.CssSelector("#start button")).Click();

            // Custom wait for specific text
            bool textAppeared = wait.Until(drv =>
            {
                var element = drv.FindElement(By.Id("finish"));
                return element.Text == "Hello World!";
            });

            Assert.IsTrue(textAppeared);
        }

        [Test]
        public void FluentWaitForElement()
        {
            // FluentWait is not directly available in C#, but you can simulate it with WebDriverWait and custom polling
            driver.FindElement(By.CssSelector("#start button")).Click();

            var fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200)
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            IWebElement result = fluentWait.Until(drv =>
            {
                var element = drv.FindElement(By.Id("finish"));
                return element.Displayed ? element : null;
            });

            Assert.That(result.Text, Is.EqualTo("Hello World!"));
        }
    }
}