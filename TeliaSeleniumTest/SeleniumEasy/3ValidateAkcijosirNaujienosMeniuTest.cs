using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TeliaSeleniumFramework;
using TeliaSeleniumFramework.Page.SeleniumEasy;
using TeliaSeleniumFramework.SeleniumEasy;

namespace TeliaSeleniumTest.Tests
{
    [TestFixture]
    public class _3ValidateAkcijosirNaujienosMeniuTest : TeliaSeleniumTest.BaseTests.BaseTests
    {
        private _3ValidateAkcijosirNaujienosMeniu validateAkcijosirNaujienosMeniu;
        private AkcijosNaujienosPage akcijosNaujienosPage;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            validateAkcijosirNaujienosMeniu = new _3ValidateAkcijosirNaujienosMeniu(driver.WebDriver, driver.Wait);
            akcijosNaujienosPage = new AkcijosNaujienosPage(driver.WebDriver, driver.Wait);
        }

        [Test]
        public void TestCase_3_1Check_content_structure_for_Telefonai_category()
        {
            validateAkcijosirNaujienosMeniu.AcceptCookies();
            validateAkcijosirNaujienosMeniu.GoToAkcijosNaujienos();

            akcijosNaujienosPage.SelectTelefonaiCategory();
            Assert.IsTrue(akcijosNaujienosPage.IsPromotionElementPresentAndClicked());

            var oldPriceElements = akcijosNaujienosPage.GetOldPriceElements();
            Assert.AreEqual(2, oldPriceElements.Count);

            akcijosNaujienosPage.SelectPhonesForComparison(oldPriceElements);
            akcijosNaujienosPage.ComparePhones();
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