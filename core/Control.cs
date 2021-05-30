using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Control
{
    public class Control
    {
        public static void EnterText(IWebElement webElement, string value) => webElement.SendKeys(value);
        public static void Click(IWebElement webElement) => webElement.Click();
        public static void SelectByValue(IWebElement webElement, string value)
        {
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByValue(value);
        }
        public static void SelectByText(IWebElement webElement, string text)
        {
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByText(text);
        }
    }
}