using AppiumCSharpExample.Drivers;
using OpenQA.Selenium;
using System;

namespace AppiumCSharpExample.Tests
{

    public class GoogleSearchTest
    {
        static void Main(string[] args)
        {
            var driverSetup = new DriverSetup();
            driverSetup.SetupDriver();
            var driver = driverSetup.Driver;

            try
            {
                // Navegar a Google
                driver.Navigate().GoToUrl("https://www.google.com");

                // Aceptar términos y condiciones si aparecen
                try
                {
                    var acceptButton = driver.FindElement(By.Id("L2AGLb"));
                    acceptButton.Click();
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("No se encontraron términos y condiciones.");
                }

                // Buscar algo en Google
                var searchBox = driver.FindElement(By.Name("q"));
                searchBox.SendKeys("Appium tutorial");
                searchBox.SendKeys(Keys.Enter);

                // Imprimir el primer resultado
                var firstResult = driver.FindElement(By.CssSelector("h3"));
                Console.WriteLine("Primer resultado: " + firstResult.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }
            finally
            {
                driverSetup.QuitDriver();
            }
        }
    }

}
