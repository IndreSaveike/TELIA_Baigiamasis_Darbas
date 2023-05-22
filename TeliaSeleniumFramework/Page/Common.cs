using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TeliaSeleniumFramework
{
    public class Common
    {
        private readonly Driver _driver;

        public Common(Driver driver)
        {
            _driver = driver;
        }

        public void AcceptCookies()
        {
            try
            {
                var cookieConsentButton = _driver.Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input.btn.btn-primary.js-cookie-modal-accept[type='submit']")));
                cookieConsentButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
               
            }
        }
    }
}
