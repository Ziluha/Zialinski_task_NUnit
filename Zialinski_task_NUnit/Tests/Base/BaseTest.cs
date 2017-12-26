using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using Zialinski_task_NUnit.Driver;
using Zialinski_task_NUnit.PageObjects;

namespace Zialinski_task_NUnit.Tests.Base
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver Driver { get; set; }
        protected DriverInitQuit DriverInitQuit { get; set; }
        protected DriverConfig DriverConfig { get; set; }
        protected PagesFactory Pages { get; set; }

        public void InitDriver(string browserName)
        {
            DriverConfig = new DriverConfig();
            DriverInitQuit = new DriverInitQuit();
            Driver = DriverInitQuit.InitDriver(browserName);
            DriverConfig.LoadApp(Driver, ConfigurationManager.AppSettings["GmailURL"]);
            Pages = new PagesFactory(Driver);
        }

        [TearDown]
        public void EndTest()
        {
            DriverInitQuit.QuitDriver(Driver);
        }
    }
}
