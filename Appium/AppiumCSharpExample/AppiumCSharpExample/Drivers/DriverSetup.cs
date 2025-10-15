using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumCSharpExample.Drivers
{

    public class DriverSetup
    {
        public AndroidDriver? Driver { get; private set; }

        public void SetupDriver()
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalAppiumOption("platformName", "Android");
            appiumOptions.AddAdditionalAppiumOption("deviceName", "emulator-5554"); // Cambia por el nombre de tu dispositivo/emulador
            appiumOptions.AddAdditionalAppiumOption("browserName", "Chrome");

            // Cambia la URL si tu servidor Appium está en otro lugar
            Driver = new AndroidDriver(new Uri("http://127.0.0.1:4723/wd/hub"), appiumOptions);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void QuitDriver()
        {
            Driver.Quit();
        }
    }

}
