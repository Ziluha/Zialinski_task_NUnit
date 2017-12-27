using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using Zialinski_task_NUnit.Tests.Base;
using Zialinski_task_NUnit.PageObjects.GmailAuthorization;
using Zialinski_task_NUnit.PageObjects.GmailMail;

namespace Zialinski_task_NUnit.Tests.TestCases
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class GmailAuthorizationTest : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowsersToRunWith")]
        public void AuthWithValidData(string browserName)
        {
            IWebDriver driver = InitDriver(browserName);

            GmailLoginPage gmailLogin = new GmailLoginPage(driver);
            gmailLogin.InputLogin(ConfigurationManager.AppSettings["ValidLogin"]);
            gmailLogin.SubmitLogin();

            GmailPasswordPage gmailPassword = new GmailPasswordPage(driver);
            gmailPassword.InputPassword(ConfigurationManager.AppSettings["ValidPassword"]);
            gmailPassword.SubmitPassword();

            GmailInboxPage gmailInbox = new GmailInboxPage(driver);
            Assert.True(gmailInbox.IsLoginSucceed(driver), "User was not logged in");
                
            QuitDriver(driver);
        }

        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowsersToRunWith")]
        public void AuthWithInvalidLogin(string browserName)
        {
            IWebDriver driver = InitDriver(browserName);

            GmailLoginPage gmailLogin = new GmailLoginPage(driver);
            gmailLogin.InputLogin(ConfigurationManager.AppSettings["InvalidLogin"]);
            gmailLogin.SubmitLogin();
            Assert.True(gmailLogin.IsLoginErrorLabelPresented(driver), "Login Error Labeln  is not presented");
                
            QuitDriver(driver);
        }

        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowsersToRunWith")]
        public void AuthWithInvalidPassword(string browserName)
        {
            IWebDriver driver = InitDriver(browserName);

            GmailLoginPage gmailLogin = new GmailLoginPage(driver);
            gmailLogin.InputLogin(ConfigurationManager.AppSettings["ValidLogin"]);
            gmailLogin.SubmitLogin();

            GmailPasswordPage gmailPassword = new GmailPasswordPage(driver);
            gmailPassword.InputPassword(ConfigurationManager.AppSettings["InvalidPassword"]);
            gmailPassword.SubmitPassword();
            Assert.True(gmailPassword.IsPasswordErrorLabelPresented(),
                "Password Error Lable is not presented");
                
            QuitDriver(driver);
        }
    }
}