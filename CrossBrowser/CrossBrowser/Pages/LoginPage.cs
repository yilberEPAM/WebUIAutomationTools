using OpenQA.Selenium;

namespace CrossBrowser.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement UsernameField => driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordField => driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => driver.FindElement(By.Id("login-button"));
        private IWebElement ErrorMessage => driver.FindElement(By.CssSelector("[data-test='error']"));

        public void EnterUsername(string username)
        {
            EnterText(UsernameField, username);
        }

        public void EnterPassword(string password)
        {
            EnterText(PasswordField, password);
        }

        public void ClickLogin()
        {
            Click(LoginButton);
        }

        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }
    }
}
