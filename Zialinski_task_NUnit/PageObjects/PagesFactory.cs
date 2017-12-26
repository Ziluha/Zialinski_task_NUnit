using OpenQA.Selenium;
using Zialinski_task_NUnit.PageObjects.GmailAuthorization;
using Zialinski_task_NUnit.PageObjects.GmailMail;

namespace Zialinski_task_NUnit.PageObjects
{
    public class PagesFactory
    {
        private readonly IWebDriver _driver;

        public PagesFactory(IWebDriver driver)
        {
            _driver = driver;
        }

        public GmailLoginPage GmailLogin => new GmailLoginPage(_driver);
        public GmailPasswordPage GmailPassword => new GmailPasswordPage(_driver);
        public GmailInboxPage GmailInbox => new GmailInboxPage(_driver);
        public GmailDraftsPage GmailDrafts => new GmailDraftsPage(_driver);

    }
}
