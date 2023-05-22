using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Linq;
using System.Collections.Generic;

namespace TeliaSeleniumFramework.SeleniumEasy
{
    public class _3ValidateAkcijosirNaujienosMeniu
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public _3ValidateAkcijosirNaujienosMeniu(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public void AcceptCookies()
        {
            try
            {
                IWebElement cookieConsentButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input.btn.btn-primary.js-cookie-modal-accept[type='submit']")));
                cookieConsentButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
            }
        }

        public void GoToAkcijosNaujienos()
        {
            IWebElement akcijosNaujienosLink = driver.FindElement(By.XPath("//a[contains(@href, 'https://www.telia.lt/privatiems/akcijos/prekems-ir-irangai') and contains(text(), 'Akcijos ir naujienos')]"));
            akcijosNaujienosLink.Click();
        }
    }

    public class AkcijosNaujienosPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public AkcijosNaujienosPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void SelectTelefonaiCategory()
        {
            IWebElement telefonaiCategory = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(@data-slide-to-location, '#301') and contains(., 'TELEFONAI')]")));
            telefonaiCategory.Click();
        }

        public bool IsPromotionElementPresentAndClicked()
        {
            IWebElement promotionsElement = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[starts-with(@alt, 'Nuolaida')]")));
            if (promotionsElement != null)
            {
                promotionsElement.Click();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ClickFirstOldPriceElement()
        {
            IWebElement firstOldPriceElement = wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".mobiles-product-card__price-marker--old")));
            if (firstOldPriceElement != null)
            {
                firstOldPriceElement.Click();
            }
        }

        public List<IWebElement> GetOldPriceElements()
        {
            var oldPriceElements = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector(".mobiles-product-card__price-marker--old"))).Take(2).ToList();
            return oldPriceElements;
        }

        public void SelectPhonesForComparison(List<IWebElement> oldPriceElements)
        {
            for (int i = 0; i < 2; i++)
            {
                IWebElement compareCheckbox = oldPriceElements[i].FindElement(By.XPath("./ancestor::div[contains(@class, 'mobiles-product-card')]//span[contains(text(), 'Palyginti')]"));
                compareCheckbox.Click();
            }
        }

        public void ComparePhones()
        {
            IWebElement prekiuPalyginimasElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(@class, 'sticky-navigation-footer__item-icon')]/i[contains(@class, 'icon-scales')]")));
            prekiuPalyginimasElement.Click();

            IWebElement palygintiPasirinktasButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a.btn.btn-secondary.btn--longer.js-product-compare-button")));
            palygintiPasirinktasButton.Click();
        }
    }
}