using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TeliaSeleniumFramework;

namespace TeliaSeleniumTest.BaseTests
{
    public class BaseTests
    {
        protected Driver driver;

        [SetUp]
        public virtual void SetUp()
        {
            driver = new Driver();
            driver.WebDriver.Manage().Window.Maximize();
            driver.NavigateTo("https://www.telia.lt/privatiems");
        }

        [TearDown]
        public virtual void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                string methodName = TestContext.CurrentContext.Test.MethodName ?? "UnknownMethod";
                string screenshotFilePath = Driver.TakeScreenshot(driver.WebDriver, methodName);
                TestContext.AddTestAttachment(screenshotFilePath);
            }
            driver.Quit();
        }
    }
}