using System.Configuration;
using Zialinski_task_NUnit.Tests.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using Zialinski_task_NUnit.PageObjects;

namespace Zialinski_task_NUnit.Tests.TestCases
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class GmailDraftsTest : BaseTest
    {
        private void SetUpAuth(IWebDriver driver)
        {
            Pages.GmailLogin.InputLogin(ConfigurationManager.AppSettings["ValidLogin"]);
            Pages.GmailLogin.SubmitLogin();
            Pages.GmailPassword.InputPassword(ConfigurationManager.AppSettings["ValidPassword"], driver);
            Pages.GmailPassword.SubmitPassword();
        }

        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowsersToRunWith")]
        public void AddMessageToDrafts(string browserName)
        {
            IWebDriver driver = InitDriver(browserName);
            SetUp(driver);
            Pages = new PagesFactory(driver);
            SetUpAuth(driver);

            Pages.GmailInbox.ClickComposeButton();
            Pages.GmailInbox.InputMessageSubject(ConfigurationManager.AppSettings["TextSample"]);
            Assert.True(Pages.GmailInbox.IsSavedLabelDisplayed(driver), "Saved Lable is not presented");
            Pages.GmailInbox.GoToDrafts();
            Assert.True(Pages.GmailDrafts.IsDraftPageOpened(driver), "Draft Page is not opened");
            Assert.True(Pages.GmailDrafts.IsDraftAdded(ConfigurationManager.AppSettings["TextSample"]),
                "No message with this subject in drafts");

            QuitDriver(driver);
        }

        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowsersToRunWith")]
        public void DeleteMessageFromDrafts(string browserName)
        {
            IWebDriver driver = InitDriver(browserName);
            SetUp(driver);
            Pages = new PagesFactory(driver);
            SetUpAuth(driver);

            int draftNumber = 3;
            Pages.GmailInbox.GoToDrafts();
            Assert.True(Pages.GmailDrafts.IsDraftPageOpened(driver), "Draft Page is not opened");
            int countOfDraftsAtStart = Pages.GmailDrafts.GetCountOfDrafts();
            Pages.GmailDrafts.ChooseDraft(draftNumber);
            Pages.GmailDrafts.ClickDiscardDraftsButton();
            Assert.AreEqual(countOfDraftsAtStart - 1, Pages.GmailDrafts.GetCountOfDrafts(),
                "Count of drafts at start and afted discarding doesn't match");

            QuitDriver(driver);
        }
    }
}
