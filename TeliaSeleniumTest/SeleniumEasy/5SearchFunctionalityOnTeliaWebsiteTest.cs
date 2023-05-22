using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TeliaSeleniumFramework;
using TeliaSeleniumFramework.SeleniumEasy;
using TeliaSeleniumTest.BaseTests;

namespace TeliaSeleniumTest.Tests
{
    public class _5SearchFunctionalityOnTeliaWebsiteTest : TeliaSeleniumTest.BaseTests.BaseTests
    {
        private _5SearchFunctionalityOnTeliaWebsite page;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            page = new _5SearchFunctionalityOnTeliaWebsite(driver.WebDriver);
            page.AcceptCookies();
        }

        [Test]
        public void TestCase_5_1_Basic_search_functionality()
        {
            string keyword = "Apple iPhone 14 pro";
            page.PerformSearch(keyword);
            string expectedUrl = $"https://www.telia.lt/privatiems/paieska?ieskoti={keyword.Replace(" ", "+")}";
            WebDriverWait wait = new WebDriverWait(driver.WebDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.UrlToBe(expectedUrl));
            Assert.AreEqual(expectedUrl, driver.WebDriver.Url, $"The current URL {driver.WebDriver.Url} does not match the expected URL {expectedUrl}");
            bool isTextPresent = page.IsTextPresentOnPage(keyword);
            Assert.IsTrue(isTextPresent, $"The text {keyword} is not present on the page");
            page.NavigateToSearchedProduct();
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