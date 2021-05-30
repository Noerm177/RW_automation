using System;
using NUnit.Framework;
using OpenQA.Selenium;
using RW_Auto.libs.Components;
using RW_Auto.Contracts;
using OpenQA.Selenium.Chrome;

namespace RW_Auto.core.TestBase
{
    public class TestBase
    {
        String test_url = "https://rwqa3.gtk.gtech.com/RetailerWizard/#!/home";
        public IWebDriver driver = null;
        public ChromeOptions chromeOpt = null;

        [SetUp]
        public void startBrowser()
        {
            chromeOpt = new ChromeOptions();
            chromeOpt.AcceptInsecureCertificates = true;
            chromeOpt.AddArgument("safebrowsing_for_trusted_sources_enabled");
            chromeOpt.AddArgument("trusted-download-sources");
            chromeOpt.AddArgument("ignore-certificate-errors");
            chromeOpt.AddArgument("disable-popup-blocking");
            chromeOpt.AddArgument("proxy-bypass-list");

            this.driver = new WebDriverFactory(chromeOpt, new DriverParams
            { Driver = "Chrome", Binaries = @"C:\Users\Noe.ruvalcaba\Documents\retailer wizard\automation\RW_Auto\drivers", })
                .GetDriver();

            driver.Navigate().GoToUrl(test_url);
            driver.Manage().Window.Maximize();

        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Quit();
            Console.WriteLine("\n\nIT works");
        }
    }
}