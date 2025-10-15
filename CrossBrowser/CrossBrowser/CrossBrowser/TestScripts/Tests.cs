using NUnit.Framework;
using CrossBrowser.Pages;
using CrossBrowser.Utilities;
using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace CrossBrowser.TestScripts
{
    public class Tests : TestBase
    {
        [Test]
        public void ValidLoginTest()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com");

            LoginPage loginPage = new LoginPage(driver);

            loginPage.EnterUsername("standard_user");
            loginPage.EnterPassword("secret_sauce");

            loginPage.ClickLogin();

            string expectedUrl = "https://www.saucedemo.com/inventory.html";
            string actualUrl = driver.Url;

            Assert.Equals(expectedUrl, actualUrl);
            TestContext.WriteLine("Login exitoso y el usuario fue redirigido a la página del inventario.");
        }

        [Test]
        public void InvalidLoginTest()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com");

            LoginPage loginPage = new LoginPage(driver);

            loginPage.EnterUsername("incorrect_user");
            loginPage.EnterPassword("invalid_password");

            loginPage.ClickLogin();

            string expectedErrorMessage = "Epic sadface: Username and password do not match any user in this service";
            string actualErrorMessage = loginPage.GetErrorMessage();

            Assert.Equals(expectedErrorMessage, actualErrorMessage);
            TestContext.WriteLine($"Login fallido con error: {actualErrorMessage}");
        }
    }
}
