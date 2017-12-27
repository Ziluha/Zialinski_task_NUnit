using System.Configuration;
using Zialinski_task_NUnit.Tests.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using Zialinski_task_NUnit.PageObjects.GmailAuthorization;
using Zialinski_task_NUnit.PageObjects.GmailMail;

namespace Zialinski_task_NUnit.Tests.TestCases
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class GmailDraftsTest : BaseTest
    {
        private void SetUpAuth(IWebDriver driver)
        {
            GmailLoginPage gmailLogin = new GmailLoginPage(driver);
            gmailLogin.InputLogin(ConfigurationManager.AppSettings["ValidLogin"]);
            gmailLogin.SubmitLogin();

            GmailPasswordPage gmailPassword = new GmailPasswordPage(driver);
            gmailPassword.InputPassword(ConfigurationManager.AppSettings["ValidPassword"]);
            gmailPassword.SubmitPassword();
        }

        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowsersToRunWith")]
        public void AddMessageToDrafts(string browserName)
        {
            IWebDriver driver = InitDriver(browserName);
            SetUpAuth(driver);

            GmailInboxPage gmailInbox = new GmailInboxPage(driver);
            gmailInbox.ClickComposeButton();
            gmailInbox.InputMessageSubject(ConfigurationManager.AppSettings["TextSample"]);
            Assert.True(gmailInbox.IsSavedLabelDisplayed(driver), "Saved Lable is not presented");
            gmailInbox.GoToDrafts();

            GmailDraftsPage gmailDrafts = new GmailDraftsPage(driver);
            Assert.True(gmailDrafts.IsDraftPageOpened(driver), "Draft Page is not opened");
            Assert.True(gmailDrafts.IsDraftAdded(ConfigurationManager.AppSettings["TextSample"]),
                "No message with this subject in drafts");

            QuitDriver(driver);
        }

        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowsersToRunWith")]
        public void DeleteMessageFromDrafts(string browserName)
        {
            IWebDriver driver = InitDriver(browserName);
            SetUpAuth(driver);
            int draftNumber = 3;

            GmailInboxPage gmailInbox = new GmailInboxPage(driver);
            gmailInbox.GoToDrafts();

            GmailDraftsPage gmailDrafts = new GmailDraftsPage(driver);
            Assert.True(gmailDrafts.IsDraftPageOpened(driver), "Draft Page is not opened");
            gmailDrafts.ChooseDraft(draftNumber);
            int countOfDraftsAtStart = gmailDrafts.GetCountOfDrafts();
            gmailDrafts.ClickDiscardDraftsButton();
            Assert.AreEqual(countOfDraftsAtStart - 1, gmailDrafts.GetCountOfDrafts(),
                "Count of drafts at start and afted discarding doesn't match");

            QuitDriver(driver);
        }
    }
}