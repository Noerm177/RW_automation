using RW_Auto.core.TestBase;
//using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;

namespace RW_Auto.pages
{
    public class Login
    {
        private IWebDriver driver;

        // Login login = PageFactory.InitElements(driver , login);

        public Login(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".login-form [name='loginEmail']")]
        public IWebElement emailField;

        [FindsBy(How = How.CssSelector, Using = ".login-form [name='passwdRetailer']")]
        public IWebElement passField;

        [FindsBy(How = How.CssSelector, Using = ".login-form .login__button > .rw-button")]
        public IWebElement loginBtnField;

        [FindsBy(How = How.CssSelector, Using = ".page-title")]
        public IWebElement actualTitle;

        public void logIn(string email, string pass)
        {
            emailField.SendKeys(email);
            passField.SendKeys(pass);
            loginBtnField.Click();
        }

        public void getTitle()
        {
            String managaUserText = "Manage Users";

            var  wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(actualTitle, managaUserText));

            String title = actualTitle.GetAttribute("innerText");

            if (title == managaUserText)
            {
                Console.WriteLine("\nCorrect title is: " + title);
            }
            else
            {
                Console.WriteLine("\nWrong Page Title is: " + title);
            }
        }
    }
}