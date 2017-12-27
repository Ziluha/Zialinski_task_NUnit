using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using Zialinski_task_NUnit.PageObjects.GmailAuthorization;
using Zialinski_task_NUnit.Tests.Base;

namespace Zialinski_task_NUnit.Tests.TestCases
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class GmailFailTest : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowsersToRunWith")]
        public void FailCheck(string browserName)
        {
            IWebDriver driver = InitDriver(browserName);

            GmailLoginPage gmailLogin = new GmailLoginPage(driver);
            gmailLogin.InputLogin(ConfigurationManager.AppSettings["InvalidLogin"]);
            gmailLogin.SubmitLogin();

            GmailPasswordPage gmailPassword = new GmailPasswordPage(driver);
            Assert.True(gmailPassword.IsLoginApplied(), "Password page is not opened");

            QuitDriver(driver);
        }
    }
}