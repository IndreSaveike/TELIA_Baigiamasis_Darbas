using NUnit.Framework;
using TeliaSeleniumFramework.SeleniumEasy;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium;
using TeliaSeleniumFramework;

namespace TeliaSeleniumTest.Tests
{
    public class _4ServiceSelectionTest : TeliaSeleniumTest.BaseTests.BaseTests
    {
        private _4ServiceSelection serviceSelectionPage;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            serviceSelectionPage = new _4ServiceSelection(driver.WebDriver, driver.Wait);
            serviceSelectionPage.AcceptCookies();
        }

        [Test]
        public void TestCase_4_1_Paslaugos_page_functionality()
        {
            serviceSelectionPage.NavigateToServiceMenu();
            serviceSelectionPage.SelectTelia1Category();
            serviceSelectionPage.ClickGetOfferButton();
            serviceSelectionPage.FillOutForm("Test Name", "65586425", "Test Comment");
            serviceSelectionPage.SubmitForm();

            driver.Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//input[@name='p_common_name']")));

            bool isSuccessMessageDisplayed = serviceSelectionPage.IsSuccessMessageDisplayed();
            Assert.IsTrue(isSuccessMessageDisplayed, "Success message is not displayed after form submission");
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
