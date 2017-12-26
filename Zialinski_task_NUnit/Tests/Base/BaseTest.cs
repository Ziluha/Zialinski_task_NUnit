using System.Collections.Generic;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using Zialinski_task_NUnit.Driver;
using Zialinski_task_NUnit.PageObjects;

namespace Zialinski_task_NUnit.Tests.Base
{
    public class BaseTest
    {
        protected DriverInitQuit DriverInitQuit { get; set; }
        protected DriverConfig DriverConfig { get; set; }
        protected PagesFactory Pages { get; set; }

        public IWebDriver InitDriver(string browserName)
        {
            DriverConfig = new DriverConfig();
            DriverInitQuit = new DriverInitQuit();
            return DriverInitQuit.InitDriver(browserName);
        }

        public void SetUp(IWebDriver driver)
        {
            DriverConfig.LoadApp(driver, ConfigurationManager.AppSettings["GmailURL"]);
            InitPages(driver);
        }

        public void InitPages(IWebDriver driver)
        {
            Pages = new PagesFactory(driver);
        }
        
        public void QuitDriver(IWebDriver driver)
        {
            driver.Quit();
        }

        public static IEnumerable<string> BrowsersToRunWith()
        {
            string[] browsers = AutomationSettings.browsersToRunWith.Split(',');

            foreach (var browser in browsers)
            {
                yield return browser;
            }
        }
    }
}
