using System.Collections.Generic;
using System.Configuration;
using OpenQA.Selenium;
using Zialinski_task_NUnit.Driver;

namespace Zialinski_task_NUnit.Tests.Base
{
    public class BaseTest
    {
        public IWebDriver InitDriver(string browserName)
        {
            DriverConfig driverConfig = new DriverConfig();
            DriverInit driverInitQuit = new DriverInit();
            IWebDriver driver = driverInitQuit.InitDriver(browserName);
            driverConfig.LoadApp(driver, ConfigurationManager.AppSettings["GmailURL"]);
            return driver;
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
