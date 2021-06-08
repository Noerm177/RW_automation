using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;

namespace RW_Auto.pages
{
    public class Manage_Content
    {
        private IWebDriver driver;

        public Manage_Content(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Retailer Roles')]") ]
        public IWebElement RRolesMenu;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Manage Roles')]")]
        public IWebElement ManageContent;

        [FindsBy(How = How.CssSelector, Using = ".rw-button--contained")]
        public IWebElement RRoleCreateButton;

        [FindsBy(How = How.CssSelector, Using = ".page-title")]
        public IWebElement actualTitle;
   

        public void getTitle()
        {
            String managaUserText = "Retailer Roles";

            ManageContent.Click();
            RRolesMenu.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(actualTitle, managaUserText));

            String title = actualTitle.GetAttribute("innerText");

            if (title == managaUserText)
            {
                Console.WriteLine("\nCorrect title is: " + title);
                Screenshot capture = driver.TakeScreenshot();
                capture.SaveAsFile("@C:\\Users\\Administrador\\source\\repos\\RW_automation\\evidence\\Error.PNG", ScreenshotImageFormat.Png);
            }
            else
            {
                Console.WriteLine("\nWrong Page Title is: " + title);
                Screenshot capture = driver.TakeScreenshot();
                capture.SaveAsFile("@C:\\Users\\Administrador\\source\\repos\\RW_automation\\evidence\\Pass.PNG", ScreenshotImageFormat.Png);
            }
        }

    }
}