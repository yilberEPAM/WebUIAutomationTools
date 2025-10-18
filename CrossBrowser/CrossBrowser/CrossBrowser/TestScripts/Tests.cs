using NUnit.Framework;
using CrossBrowser.Pages;
using CrossBrowser.Utilities;
using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace CrossBrowser.TestScripts
{
    public class Tests : TestBase
    {
        private ExtentReports extent;
        private ExtentTest test;

        [SetUp]
        public void ExtentSetup()
        {
            extent = ExtentManager.GetReporter();
        }

        [Test]
        public void ValidLoginTest()
        {
            test = extent.CreateTest("ValidLoginTest");
            driver.Navigate().GoToUrl(BrowserConfig.Config["baseUrl"].ToString());

            LoginPage loginPage = new LoginPage(driver);

            loginPage.EnterUsername("standard_user");
            loginPage.EnterPassword("secret_sauce");

            loginPage.ClickLogin();

            string expectedUrl = "https://www.saucedemo.com/inventory.html";
            string actualUrl = driver.Url;

            Assert.Equals(expectedUrl, actualUrl);
            test.Pass("Login exitoso y el usuario fue redirigido a la página del inventario.");
        }

        [Test]
        public void InvalidLoginTest()
        {
            test = extent.CreateTest("InvalidLoginTest");
            driver.Navigate().GoToUrl(BrowserConfig.Config["baseUrl"].ToString());

            LoginPage loginPage = new LoginPage(driver);

            loginPage.EnterUsername("incorrect_user");
            loginPage.EnterPassword("invalid_password");

            loginPage.ClickLogin();

            string expectedErrorMessage = "Epic sadface: Username and password do not match any user in this service";
            string actualErrorMessage = loginPage.GetErrorMessage();

            Assert.Equals(expectedErrorMessage, actualErrorMessage);
            test.Pass($"Login fallido con error: {actualErrorMessage}");
        }

        [TearDown]
        public void ReportTearDown()
        {
            extent.Flush();
        }
    }
}
