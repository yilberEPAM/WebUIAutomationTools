using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

[TestFixture]
public class CookieTests
{
    private IWebDriver? driver;
    private const string TestUrl = "https://www.selenium.dev/selenium/web/cookies.html";

    [SetUp]
    public void SetUp()
    {
        try
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(TestUrl);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error initializing ChromeDriver: " + ex.Message);
            throw;
        }
    }

    [TearDown]
    public void TearDown()
    {
        if (driver != null)
        {
            driver.Quit();
            driver.Dispose();
            driver = null;
        }
    }

    [Test]
    public void AddAndVerifyCookie()
    {
        var cookie = new Cookie("TestCookie", "TestValue", "selenium.dev", "/", DateTime.Now.AddDays(1));
        driver.Manage().Cookies.AddCookie(cookie);

        var retrieved = driver.Manage().Cookies.GetCookieNamed("TestCookie");
        Assert.IsNotNull(retrieved);
        Assert.AreEqual("TestValue", retrieved.Value);
    }

    [Test]
    public void EditCookieValue()
    {
        var cookie = new Cookie("EditCookie", "Value1", "selenium.dev", "/", DateTime.Now.AddDays(1));
        driver.Manage().Cookies.AddCookie(cookie);

        driver.Manage().Cookies.DeleteCookieNamed("EditCookie");
        var newCookie = new Cookie("EditCookie", "Value2", "selenium.dev", "/", DateTime.Now.AddDays(1));
        driver.Manage().Cookies.AddCookie(newCookie);

        var retrieved = driver.Manage().Cookies.GetCookieNamed("EditCookie");
        Assert.AreEqual("Value2", retrieved.Value);
    }

    [Test]
    public void DeleteCookie()
    {
        var cookie = new Cookie("DeleteCookie", "ToDelete", "selenium.dev", "/", DateTime.Now.AddDays(1));
        driver.Manage().Cookies.AddCookie(cookie);

        driver.Manage().Cookies.DeleteCookieNamed("DeleteCookie");
        var retrieved = driver.Manage().Cookies.GetCookieNamed("DeleteCookie");
        Assert.IsNull(retrieved);
    }

    [Test]
    public void ListAllCookies()
    {
        driver.Manage().Cookies.AddCookie(new Cookie("Cookie1", "Value1", "selenium.dev", "/", DateTime.Now.AddDays(1)));
        driver.Manage().Cookies.AddCookie(new Cookie("Cookie2", "Value2", "selenium.dev", "/", DateTime.Now.AddDays(1)));

        var cookies = driver.Manage().Cookies.AllCookies;
        Assert.IsTrue(cookies.Any(c => c.Name == "Cookie1"));
        Assert.IsTrue(cookies.Any(c => c.Name == "Cookie2"));
    }
}