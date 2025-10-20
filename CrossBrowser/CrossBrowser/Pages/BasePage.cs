using OpenQA.Selenium;

namespace CrossBrowser.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected void Click(IWebElement element)
        {
            element.Click();
        }

        protected void EnterText(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
