using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using Zialinski_task_NUnit.PageObjects;
using Zialinski_task_NUnit.Tests.Base;

namespace Zialinski_task_NUnit.Tests.TestCases
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class GmailAuthorizationTest : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowsersToRunWith")]
        public void AuthWithValidData(string browserName)
        {
            IWebDriver driver = InitDriver(browserName);
            DriverConfig.LoadApp(driver, ConfigurationManager.AppSettings["GmailURL"]);
            InitPages(driver);

            Pages.GmailLogin.InputLogin(ConfigurationManager.AppSettings["ValidLogin"]);
            Pages.GmailLogin.SubmitLogin();
            Pages.GmailPassword.InputPassword(ConfigurationManager.AppSettings["ValidPassword"], Driver);
            Pages.GmailPassword.SubmitPassword();
            Assert.True(Pages.GmailInbox.IsLoginSucceed(Driver), "User was not logged in");

            QuitDriver(driver);
        }

        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowsersToRunWith")]
        public void AuthWithInvalidLogin(string browserName)
        {
            IWebDriver driver = InitDriver(browserName);
            DriverConfig.LoadApp(driver, ConfigurationManager.AppSettings["GmailURL"]);
            InitPages(driver);

            Pages.GmailLogin.InputLogin(ConfigurationManager.AppSettings["InvalidLogin"]);
            Pages.GmailLogin.SubmitLogin();
            Assert.True(Pages.GmailLogin.IsLoginErrorLabelPresented(Driver), "Login Error Lable is not presented");

            QuitDriver(driver);
        }

        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowsersToRunWith")]
        public void AuthWithInvalidPassword(string browserName)
        {
            IWebDriver driver = InitDriver(browserName);
            DriverConfig.LoadApp(driver, ConfigurationManager.AppSettings["GmailURL"]);
            InitPages(driver);

            Pages.GmailLogin.InputLogin(ConfigurationManager.AppSettings["ValidLogin"]);
            Pages.GmailLogin.SubmitLogin();
            Pages.GmailPassword.InputPassword(ConfigurationManager.AppSettings["InvalidPassword"], Driver);
            Pages.GmailPassword.SubmitPassword();
            Assert.True(Pages.GmailPassword.IsPasswordErrorLabelPresented(Driver),
                "Password Error Lable is not presented");

            QuitDriver(driver);
        }
    }
}
