using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TeliaSeleniumFramework;
using TeliaSeleniumFramework.Page;
using TeliaSeleniumFramework.SeleniumEasy;
using TeliaSeleniumTest.BaseTests;

namespace TeliaSeleniumTest.Tests
{
    [TestFixture]
    public class _1TeliaLoginForPrivateCustomersTest : TeliaSeleniumTest.BaseTests.BaseTests
    {
        private _1TeliaLoginForPrivateCustomers loginPage;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            loginPage = new _1TeliaLoginForPrivateCustomers(driver.WebDriver);
            loginPage.GoToLoginPage();
        }

        [Test]
        public void TestCase_1_1_Valid_login_for_private_customer_functionality()
        {
            try
            {
                loginPage.AcceptCookies();
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
            }
            loginPage.PerformLogin("test.telia142@gmail.com", "Testtelia123");
            Assert.IsTrue(driver.WebDriver.Url.Contains("mano/privatiems/apzvalga"));
        }

        [Test]
        public void TestCase_1_2_Invalid_login_with_incorrect_Email()
        {
            try
            {
                loginPage.AcceptCookies();
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
            }

            loginPage.PerformLogininvalidemial("invalid.email@example.com", "Testtelia123");

            Assert.IsTrue(loginPage.IsErrorMessageDisplayed(), "Error message not found.");
            Assert.IsFalse(driver.WebDriver.Url.Contains("mano/privatiems/apzvalga"));
        }

        [Test]
        public void TestCase_1_3_Invalid_login_with_incorrect_password()
        {
            try
            {
                loginPage.AcceptCookies();
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
            }

            loginPage.PerformLogininvalidpassword("test.telia142@gmail.com", "incorrectpassword");

            Assert.IsTrue(loginPage.IsErrorMessageDisplayed(), "Error message not found.");
            Assert.IsFalse(driver.WebDriver.Url.Contains("mano/privatiems/apzvalga"));
        }

        [Test]
        public void TestCase_1_4_Forgot_password_functionality()
        {
            try
            {
                loginPage.AcceptCookies();
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
            }
            loginPage.NavigateToPasswordRecovery("test.telia142@gmail.com");
            loginPage.ClickButtonTesti();
            Assert.IsTrue(loginPage.IsRecoveryMessageDisplayed(), "Recovery message not found.");
        }

        [TearDown]
        public override void TearDown()
        {
            WebDriverWait wait = new WebDriverWait(driver.WebDriver, TimeSpan.FromSeconds(20));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

            string methodName = TestContext.CurrentContext.Test.MethodName ?? "UnknownMethod";
            string screenshotFilePath = Driver.TakeScreenshot(driver.WebDriver, methodName);
            TestContext.AddTestAttachment(screenshotFilePath);

            base.TearDown();
        }
    }
}