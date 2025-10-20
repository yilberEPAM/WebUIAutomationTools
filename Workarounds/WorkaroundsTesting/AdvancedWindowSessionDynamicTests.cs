using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WorkaroundTesting
{
    [TestFixture]
    public class AdvancedWindowSessionDynamicTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            driver = new ChromeDriver(options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void WindowManagement_OpenNewTabAndSwitch()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
            string originalWindow = driver.CurrentWindowHandle;

            driver.FindElement(By.LinkText("Click Here")).Click();

            wait.Until(d => d.WindowHandles.Count == 2);

            var allWindows = driver.WindowHandles;
            string newWindow = allWindows.First(w => w != originalWindow);

            driver.SwitchTo().Window(newWindow);
            Assert.IsTrue(driver.Title.Contains("New Window"));

            driver.Close();
            driver.SwitchTo().Window(originalWindow);
            Assert.IsTrue(driver.Title.Contains("The Internet"));
        }

        [Test]
        public void SessionControl_CookieManagement()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com");
            driver.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie("TestSession", "SessionValue", "the-internet.herokuapp.com", "/", DateTime.Now.AddMinutes(10)));

            var cookie = driver.Manage().Cookies.GetCookieNamed("TestSession");
            Assert.IsNotNull(cookie);
            Assert.That(cookie.Value, Is.EqualTo("SessionValue"));

            driver.Manage().Cookies.DeleteCookieNamed("TestSession");
            Assert.IsNull(driver.Manage().Cookies.GetCookieNamed("TestSession"));
        }

        [Test]
        public void SessionControl_RestartSession()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com");
            driver.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie("TestSession", "SessionValue", "the-internet.herokuapp.com", "/", DateTime.Now.AddMinutes(10)));

            driver.Quit();
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com");

            var cookie = driver.Manage().Cookies.GetCookieNamed("TestSession");
            Assert.IsNull(cookie, "Session should not persist after browser restart.");
        }

        [Test]
        public void DynamicElements_WaitForElementToAppear()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/2");
            driver.FindElement(By.CssSelector("#start button")).Click();

            IWebElement finish = wait.Until(drv =>
            {
                var el = drv.FindElement(By.Id("finish"));
                return el.Displayed ? el : null;
            });

            Assert.That(finish.Text, Is.EqualTo("Hello World!"));
        }

        [Test]
        public void DynamicElements_HandleAjaxContent()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/notification_message_rendered");
            string message = "";

            for (int i = 0; i < 3; i++)
            {
                driver.FindElement(By.LinkText("Click here")).Click();
                IWebElement notification = wait.Until(drv =>
                {
                    var el = drv.FindElement(By.Id("flash"));
                    return el.Displayed ? el : null;
                });
                message = notification.Text;
                Assert.IsTrue(message.Contains("Action successful") || message.Contains("Action unsuccesful"), "Unexpected notification message.");
            }
        }
    }
}