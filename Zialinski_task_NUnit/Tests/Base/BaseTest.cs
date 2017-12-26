using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Zialinski_task_NUnit.Driver;
using Zialinski_task_NUnit.PageObjects;

namespace Zialinski_task_NUnit.Tests.Base
{
   // [TestFixture]
  //  [Parallelizable]
    public class BaseTest
    {
        protected IWebDriver Driver { get; set; }
        protected DriverInitQuit DriverInitQuit { get; set; }
        protected DriverConfig DriverConfig { get; set; }
        protected PagesFactory Pages { get; set; }

        public IWebDriver InitDriver(string browserName)
        {
            DriverConfig = new DriverConfig();
            DriverInitQuit = new DriverInitQuit();
            Driver = DriverInitQuit.InitDriver(browserName);
            //DriverConfig.LoadApp(Driver, ConfigurationManager.AppSettings["GmailURL"]);
            return Driver;
        }

        public void InitPages(IWebDriver driver)
        {
            Pages = new PagesFactory(driver);
        }

        //[TearDown]
        public void QuitDriver(IWebDriver driver)
        {
            driver.Quit();
            //DriverInitQuit.QuitDriver(Driver);
            //Driver.Quit();
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
