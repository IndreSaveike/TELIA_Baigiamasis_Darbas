using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TeliaSeleniumFramework.Page.SeleniumEasy
{
    public class _2ProductBuyFlowPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public _2ProductBuyFlowPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void AcceptCookies()
        {
            try
            {
                var cookieConsentButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input.btn.btn-primary.js-cookie-modal-accept[type='submit']")));
                cookieConsentButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
        
            }
        }

        public void NavigateToEparduotuve()
        {
            IWebElement linkEparduotuve = driver.FindElement(By.XPath("//a[contains(text(), 'E. parduotuvė') and contains(@href, '#Eparduotuvė')]"));
            linkEparduotuve.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(), 'Ausinės') and contains(@class, 'DropdownItemLinkstyles__DropdownItemText-sc-1enpkrm-5')]")));
        }

        public void OpenCategory()
        {
            IWebElement linkAusinės = driver.FindElement(By.XPath("//a[.//span[text()='Ausinės']]"));
            linkAusinės.Click();
            wait.Until(ExpectedConditions.UrlContains("ausines"));
        }

        public void SelectProduct()
        {
            IWebElement linkAppleAirPodsPro = driver.FindElement(By.XPath("//a[contains(@href, '/prekes/ausines-garso-iranga/ausines/apple-airpods-pro-2nd-gen-2022') and contains(text(), 'Apple AirPods Pro (2nd gen) (2022)')]"));
            linkAppleAirPodsPro.Click();
            wait.Until(ExpectedConditions.UrlContains("apple-airpods-pro-2nd-gen-2022"));
        }

        public void PlaceOrder()
        {
            IWebElement buttonUžsakyti = driver.FindElement(By.XPath("//a[contains(@data-test, 'cart-box-action-button') and contains(., 'Užsakyti')]"));
            buttonUžsakyti.Click();
            wait.Until(ExpectedConditions.UrlContains("kliento-duomenys"));
        }

        public void FillUserData()
        {
            IWebElement inputName = driver.FindElement(By.XPath("//input[@type='text' and @name='name' and @placeholder='Įveskite vardą ir pavardę']"));
            inputName.SendKeys("Test Telia");
            IWebElement inputEmail = driver.FindElement(By.XPath("//input[@type='email' and @name='email' and @placeholder='Įveskite el. pašto adresą']"));
            inputEmail.SendKeys("test.telia@gmail.com");
            IWebElement inputPhone = driver.FindElement(By.XPath("//input[@type='tel' and @name='phone' and @placeholder='Įveskite tel. numerį']"));
            inputPhone.SendKeys("+37065586425");
            IWebElement checkbox = driver.FindElement(By.CssSelector("input.form-option__input[name='rules_and_privacy_policy_consent'][data-test='rules-and-privacy-policy-consent--checkbox']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", checkbox);
            bool isChecked = checkbox.Selected;
        }

        public void ContinueToDeliveryPage()
        {
            IWebElement buttonTęsti = driver.FindElement(By.XPath("//button[@type='submit' and @data-test='action--button' and contains(text(), 'Tęsti')]"));
            buttonTęsti.Click();
            wait.Until(ExpectedConditions.UrlContains("pristatymas"));
        }

        public void FillDeliveryData()
        {
            IWebElement inputAddressSearch = driver.FindElement(By.CssSelector("input[name='addressStreet'][placeholder='Pvz.: Šilo g., Druskininkų m.']"));

            inputAddressSearch.SendKeys("Šilo g., Druskininkų m., Druskininkų sav.");
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".address-auto-complete__item")));

            IWebElement addressSuggestion = driver.FindElement(By.CssSelector(".address-auto-complete__item"));
            addressSuggestion.Click();

            IWebElement inputHouseNumber = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='field_addressHouse' and @name='addressHouse' and @placeholder='Pvz.: 2B']")));
            inputHouseNumber.SendKeys("1");
        }

        public void ContinueToPaymentPage()
        {
            IWebElement buttonTęstiApmokėjimas = driver.FindElement(By.XPath("//button[@type='submit' and @data-test='action--button' and contains(text(), 'Tęsti')]"));
            buttonTęstiApmokėjimas.Click();
            wait.Until(ExpectedConditions.UrlContains("apmokejimas"));
        }
    }
}