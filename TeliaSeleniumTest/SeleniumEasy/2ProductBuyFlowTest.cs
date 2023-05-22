using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TeliaSeleniumFramework;
using TeliaSeleniumFramework.Page.SeleniumEasy;
using TeliaSeleniumTest.BaseTests;

namespace TeliaSeleniumTest.Tests
{
    [TestFixture]
    public class _2ProductBuyFlowTest : TeliaSeleniumTest.BaseTests.BaseTests
    {
        private _2ProductBuyFlowPage productBuyFlowPage;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            productBuyFlowPage = new _2ProductBuyFlowPage(driver.WebDriver, driver.Wait);
            productBuyFlowPage.AcceptCookies();
        }

        [Test]
        public void TestCase2_1_Verify_that_the_user_can_add_a_product_to_the_cart()
        {
            productBuyFlowPage.NavigateToEparduotuve();
            productBuyFlowPage.OpenCategory();
            productBuyFlowPage.SelectProduct();
            productBuyFlowPage.PlaceOrder();
            productBuyFlowPage.FillUserData();
            productBuyFlowPage.ContinueToDeliveryPage();
            productBuyFlowPage.FillDeliveryData();
            productBuyFlowPage.ContinueToPaymentPage();
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