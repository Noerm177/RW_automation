using System;
using NUnit.Framework;
using OpenQA.Selenium;
using RW_Auto.libs.Components;
using RW_Auto.Contracts;
using OpenQA.Selenium.Chrome;
using System.Threading;


namespace RW_Auto.core.TestBase
{
    public class TestBase
    {
        public IWebDriver driver = null;
        public ChromeOptions chromeOpt = null;

        [SetUp]
        public void startBrowser()
        {   // Optiones for chrome browser
            chromeOpt = new ChromeOptions();

            // Set values for driver
            this.driver = new WebDriverFactory(chromeOpt, new DriverParams
            { Driver = "Chrome", Binaries = @"C:\Users\Administrador\source\repos\RW_automation\drivers", })
                .GetDriver();
            driver.Url = "https://rwqa1.gtk.gtech.com/RetailerWizard/#/home";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Quit();
            Console.WriteLine("\n\nIT works");
        }
    }
}