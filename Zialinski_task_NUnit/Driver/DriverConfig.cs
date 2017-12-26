using System;
using OpenQA.Selenium;

namespace Zialinski_task_NUnit.Driver
{
    public class DriverConfig
    {
        public void LoadApp(IWebDriver driver, string url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}
