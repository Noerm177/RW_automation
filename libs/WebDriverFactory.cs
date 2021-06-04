using OpenQA.Selenium;
using RW_Auto.Contracts;
using Newtonsoft.Json;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;


namespace RW_Auto.libs.Components
{
    public class WebDriverFactory
    {
        private readonly DriverParams driverParams;
        private readonly ChromeOptions chOpt;

        //Constructor
        public WebDriverFactory(ChromeOptions chOpt, DriverParams driverParams)
        {
            this.chOpt = chOpt;
            chOpt.AcceptInsecureCertificates = true;
            chOpt.AddArgument("safebrowsing_for_trusted_sources_enabled");
            chOpt.AddArgument("trusted-download-sources");
            chOpt.AddArgument("ignore-certificate-errors");
            chOpt.AddArgument("disable-popup-blocking");
            chOpt.AddArgument("proxy-bypass-list");
            chOpt.PageLoadStrategy = PageLoadStrategy.Normal;

            this.driverParams = driverParams;
            if (string.IsNullOrEmpty(driverParams.Binaries) || driverParams.Binaries == ".")
            {
                driverParams.Binaries = Environment.CurrentDirectory;
            }

        }
        /*public WebDriverFactory(string driverParamsJson) 
           :this(LoadParams(driverParamsJson)){ }*/

        //Local web drivers
        private IWebDriver GetChrome() => new ChromeDriver(driverParams.Binaries, chOpt); // Send parameters
        private IWebDriver GetFirefox() => new FirefoxDriver(driverParams.Binaries);
        private IWebDriver GetInternetExplorer() => new InternetExplorerDriver(driverParams.Binaries);

        public IWebDriver GetDriver()
        {
            switch (driverParams.Driver.ToUpper())
            {
                case "IE": return GetInternetExplorer();
                case "CHROME": return GetChrome();
                case "FF": return GetFirefox();
                default: return GetChrome();
            }
        }
        //Load json into driver params object
        private static DriverParams LoadParams(string driverParamsJson)
        {
            if (string.IsNullOrEmpty(driverParamsJson))
            {
                return new DriverParams { Source = "Local", Driver = "Chrome", Binaries = "." };
            }
            return JsonConvert.DeserializeObject<DriverParams>(driverParamsJson);
        }
    }
}