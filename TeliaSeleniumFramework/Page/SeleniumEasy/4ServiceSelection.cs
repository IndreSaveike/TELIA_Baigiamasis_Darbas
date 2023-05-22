using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TeliaSeleniumFramework.SeleniumEasy
{
    public class _4ServiceSelection
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public _4ServiceSelection(IWebDriver driver, WebDriverWait wait)
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
        public void NavigateToServiceMenu()
        {
            IWebElement serviceMenu = driver.FindElement(By.XPath("//a[@href='#Paslaugos']"));
            serviceMenu.Click();
        }

        public void SelectTelia1Category()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='TELIA1']")));
            IWebElement telia1Category = driver.FindElement(By.XPath("//span[text()='TELIA1']"));
            telia1Category.Click();
        }

        public void ClickGetOfferButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(), 'Gauti pasiūlymą')]")));
            IWebElement getOfferButton = driver.FindElement(By.XPath("//span[contains(text(), 'Gauti pasiūlymą')]"));
            getOfferButton.Click();
        }

        public void FillOutForm(string name, string phoneNumber, string comment)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='form-group form-group--name js-p_common_name']//input[@name='p_common_name']")));
            IWebElement inputName = driver.FindElement(By.XPath("//div[@class='form-group form-group--name js-p_common_name']//input[@name='p_common_name']"));
            inputName.SendKeys(name);

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='form-group form-group--phone-number js-p_telephone_number']//input[@name='p_telephone_number']")));
            IWebElement inputPhone = driver.FindElement(By.XPath("//div[@class='form-group form-group--phone-number js-p_telephone_number']//input[@name='p_telephone_number']"));
            inputPhone.SendKeys(phoneNumber);

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.form-group.form-group--comment.js-p_comment textarea[name='p_comment']")));
            IWebElement inputComment = driver.FindElement(By.CssSelector("div.form-group.form-group--comment.js-p_comment textarea[name='p_comment']"));
            inputComment.SendKeys(comment);
        }

        public void SubmitForm()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='modal-popup-telia-lead-popup']//input[@value='Gauti pasiūlymą']")));
            IWebElement submitButton = driver.FindElement(By.XPath("//*[@id='modal-popup-telia-lead-popup']//input[@value='Gauti pasiūlymą']"));
            submitButton.Click();
        }
        public bool IsSuccessMessageDisplayed()
        {
                try
                {
                    IWebElement successMessage = wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".alert-success")));
                    return successMessage != null;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }
    }
