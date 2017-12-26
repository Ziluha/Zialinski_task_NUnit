using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using Zialinski_task_NUnit.PageObjects;
using Zialinski_task_NUnit.Tests.Base;

namespace Zialinski_task_NUnit.Tests.TestCases
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class GmailFailTest : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowsersToRunWith")]
        public void FailCheck(string browserName)
        {
            IWebDriver driver = InitDriver(browserName);
            SetUp(driver);
            Pages = new PagesFactory(driver);

            Pages.GmailLogin.InputLogin(ConfigurationManager.AppSettings["InvalidLogin"]);
            Pages.GmailLogin.SubmitLogin();
            Assert.True(Pages.GmailPassword.IsLoginApplied(driver), "Password page is not opened");

            QuitDriver(driver);
        }
    }
}
