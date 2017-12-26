using System.Configuration;
using Zialinski_task_NUnit.Tests.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using Zialinski_task_NUnit.PageObjects;

namespace Zialinski_task_NUnit.Tests.TestCases
{
    [TestFixture]
    [Parallelizable]
    public class GmailDraftsTest : BaseTest
    {
        private void SetUpAuth()
        {
            Pages.GmailLogin.InputLogin(ConfigurationManager.AppSettings["ValidLogin"]);
            Pages.GmailLogin.SubmitLogin();
            Pages.GmailPassword.InputPassword(ConfigurationManager.AppSettings["ValidPassword"], Driver);
            Pages.GmailPassword.SubmitPassword();
        }

        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowsersToRunWith")]
        public void AddMessageToDrafts(string browserName)
        {
            InitDriver(browserName);
            SetUpAuth();

            Pages.GmailInbox.ClickComposeButton();
            Pages.GmailInbox.InputMessageSubject(ConfigurationManager.AppSettings["TextSample"]);
            Assert.True(Pages.GmailInbox.IsSavedLabelDisplayed(Driver), "Saved Lable is not presented");
            Pages.GmailInbox.GoToDrafts();
            Assert.True(Pages.GmailDrafts.IsDraftPageOpened(Driver), "Draft Page is not opened");
            Assert.True(Pages.GmailDrafts.IsDraftAdded(ConfigurationManager.AppSettings["TextSample"]),
                "No message with this subject in drafts");
        }

        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowsersToRunWith")]
        public void DeleteMessageFromDrafts(string browserName)
        {
            InitDriver(browserName);
            SetUpAuth();

            int draftNumber = 3;
            Pages.GmailInbox.GoToDrafts();
            Assert.True(Pages.GmailDrafts.IsDraftPageOpened(Driver), "Draft Page is not opened");
            int countOfDraftsAtStart = Pages.GmailDrafts.GetCountOfDrafts();
            Pages.GmailDrafts.ChooseDraft(draftNumber);
            Pages.GmailDrafts.ClickDiscardDraftsButton();
            Assert.AreEqual(countOfDraftsAtStart - 1, Pages.GmailDrafts.GetCountOfDrafts(),
                "Count of drafts at start and afted discarding doesn't match");
        }
    }
}
