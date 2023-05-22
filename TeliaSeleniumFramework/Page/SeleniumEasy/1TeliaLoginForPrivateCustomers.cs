using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace TeliaSeleniumFramework.SeleniumEasy
{
    public class _1TeliaLoginForPrivateCustomers
    {
        private IWebDriver driver;
        private WebDriverWait shortWait;
        private WebDriverWait longWait;

        public _1TeliaLoginForPrivateCustomers(IWebDriver driver)
        {
            this.driver = driver;
            shortWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            longWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement LoginButton()
        {
            return shortWait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@data-test='login']/a[contains(text(),'Prisijungti')]")));
        }
        public IWebElement PrivateDashboardTitle()
        {
            return shortWait.Until(ExpectedConditions.ElementExists(By.CssSelector("h3.dashboard__title.text-uppercase.font-secondary")));
        }

        public IWebElement PrivateLoginButton()
        {
            return shortWait.Until(ExpectedConditions.ElementExists(By.CssSelector("a.btn.btn-primary.w-auto[href='/mano/privatiems/sso']")));
        }

        public IWebElement PasswordLoginOption()
        {
            return shortWait.Until(ExpectedConditions.ElementExists(By.CssSelector("a[href*='/mano/privatiems/sso/prisijungti-el-pastu']")));
        }

        public IWebElement EmailInput()
        {
            return shortWait.Until(ExpectedConditions.ElementExists(By.CssSelector("input[type='text'][name='loginName']")));
        }

        public IWebElement PasswordInput()
        {
            return shortWait.Until(ExpectedConditions.ElementExists(By.CssSelector("input[type='password'][name='password']")));
        }

        public IWebElement SubmitButton()
        {
            return shortWait.Until(ExpectedConditions.ElementExists(By.XPath("//telia-button[@type='submit']//button[text()='Prisijungti']")));
        }

        public IWebElement ErrorMessage()
        {
            return shortWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@slot='heading']/following-sibling::telia-p[@slot='content']")));
        }

        public bool IsErrorMessageDisplayed()
        {
            return ErrorMessage().Displayed;
        }

        public IWebElement ForgotPasswordLink()
        {
            return shortWait.Until(ExpectedConditions.ElementExists(By.CssSelector("a[href*='/mano/privatiems/sso/priminti-slaptazodi']")));
        }
        public bool IsRecoveryMessageDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement recoveryMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("telia-p[slot='content'].telia-p--paragraph-100.hydrated")));
            return recoveryMessage.Displayed;
        }

        public void GoToLoginPage()
        {
            driver.Navigate().GoToUrl("https://www.telia.lt/privatiems");
        }
        public void ClickButtonTesti()
        {
            IWebElement button = ButtonTesti();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", button);
        }

        private IWebElement ButtonTesti()
        {
           return driver.FindElement(By.XPath("//button[contains(@class, 'telia-button') and contains(@class, 'telia-button--primary') and contains(@class, 'telia-button--md') and text()='Tęsti']"));
        }

        public IWebElement GetPasswordRecoveryMessage()
        {
            
            return shortWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("your-css-selector-here")));
        }

        public void AcceptCookies()
        {
            var cookieConsentButton = shortWait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input.btn.btn-primary.js-cookie-modal-accept[type='submit']")));
            cookieConsentButton.Click();
        }
        public void PerformLogin(string email, string password)
        {
            LoginButton().Click();
            shortWait.Until(ExpectedConditions.UrlContains("https://www.telia.lt/mano"));
            PrivateLoginButton().Click();
            shortWait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href*='/mano/privatiems/sso']")));
            PasswordLoginOption().Click();
            shortWait.Until(ExpectedConditions.UrlContains("https://www.telia.lt/mano/privatiems/sso/prisijungti-el-pastu"));
            EmailInput().SendKeys(email);
            PasswordInput().SendKeys(password);
            SubmitButton().Click();
            longWait.Until(ExpectedConditions.UrlContains("mano/privatiems/apzvalga"));
        }
        public void PerformLogininvalidemial(string email, string password)
        {
            LoginButton().Click();
            shortWait.Until(ExpectedConditions.UrlContains("https://www.telia.lt/mano"));
            PrivateLoginButton().Click();
            shortWait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href*='/mano/privatiems/sso']")));
            PasswordLoginOption().Click();
            shortWait.Until(ExpectedConditions.UrlContains("https://www.telia.lt/mano/privatiems/sso/prisijungti-el-pastu"));
            EmailInput().SendKeys(email);
            PasswordInput().SendKeys(password);
            SubmitButton().Click();
        }
        public void PerformLogininvalidpassword(string email, string password)
        {
            LoginButton().Click();
            shortWait.Until(ExpectedConditions.UrlContains("https://www.telia.lt/mano"));
            PrivateLoginButton().Click();
            shortWait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href*='/mano/privatiems/sso']")));
            PasswordLoginOption().Click();
            shortWait.Until(ExpectedConditions.UrlContains("https://www.telia.lt/mano/privatiems/sso/prisijungti-el-pastu"));
            EmailInput().SendKeys(email);
            PasswordInput().SendKeys(password);
            SubmitButton().Click();
        }

        public void NavigateToPasswordRecovery(string email)
        {
            LoginButton().Click();
            shortWait.Until(ExpectedConditions.UrlContains("https://www.telia.lt/mano"));
            PrivateLoginButton().Click();
            shortWait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href*='/mano/privatiems/sso']")));
            ForgotPasswordLink().Click();
            shortWait.Until(ExpectedConditions.UrlContains("mano/privatiems/sso/priminti-slaptazodi"));
            EmailInput().SendKeys(email);
            longWait.Until(ExpectedConditions.ElementToBeClickable(ButtonTesti()));
            ClickButtonTesti();
        }
    }
}