using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace TeliaSeleniumFramework
{
    public class Driver
    {
        public IWebDriver WebDriver { get; set; }
        public WebDriverWait Wait { get; set; }

        public Driver()
        {
            WebDriver = new ChromeDriver();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(20));
        }

        public void NavigateTo(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        public void Quit()
        {
            WebDriver.Quit();
        }

        public static string TakeScreenshot(IWebDriver driver, string methodName)
        {
            string screenshotDirectoryPath = "/Users/rimac/Projects/TELIA_Baigiamasis_Darbas/TeliaSeleniumTest/bin/Debug/net7.0/Screenshots/";
            string screenshotName = $"{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}-{methodName}-screenshot.png";
            string screenshotFilePath = $"{screenshotDirectoryPath}\\{screenshotName}";

            Directory.CreateDirectory(screenshotDirectoryPath);
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile($"{screenshotFilePath}", ScreenshotImageFormat.Png);

            return screenshotFilePath;
        }

    }
}