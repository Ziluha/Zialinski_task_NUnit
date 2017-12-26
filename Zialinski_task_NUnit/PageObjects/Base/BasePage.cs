using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Zialinski_task_NUnit.PageObjects.Base
{
    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            PageFactory.InitElements(driver, this);
        }
    }
}
