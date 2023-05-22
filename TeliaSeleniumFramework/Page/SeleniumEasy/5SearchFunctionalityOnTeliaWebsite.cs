using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace TeliaSeleniumFramework.SeleniumEasy
{
    public class _5SearchFunctionalityOnTeliaWebsite
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public _5SearchFunctionalityOnTeliaWebsite(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement CookieConsentButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input.btn.btn-primary.js-cookie-modal-accept[type='submit']")));
        public IWebElement SearchButton => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button[data-test='search-open']")));
        public IWebElement SearchField => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[data-test='search-input']")));

        public void AcceptCookies()
        {
            CookieConsentButton.Click();
        }

        public void PerformSearch(string keyword)
        {
            SearchButton.Click();
            SearchField.SendKeys(keyword);
            SearchField.SendKeys(Keys.Enter);
        }

        public void NavigateToSearchedProduct()
        {
            var iPhoneElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href='/prekes/mobilieji-telefonai/apple-iphone-14-pro']")));
            iPhoneElement.Click();
        }

        public bool IsTextPresentOnPage(string textToFind)
        {
            return driver.PageSource.Contains(textToFind);
        }
    }
}