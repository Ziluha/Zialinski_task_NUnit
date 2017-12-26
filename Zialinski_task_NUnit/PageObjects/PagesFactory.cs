using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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

       /*ublic GmailLoginPage GmailLogin => new GmailLoginPage(_driver);
        public GmailPasswordPage GmailPassword => new GmailPasswordPage(_driver);
        public GmailInboxPage GmailInbox => new GmailInboxPage(_driver);
        public GmailDraftsPage GmailDrafts => new GmailDraftsPage(_driver);*/
        

        private T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(_driver, page);
            return page;
        }

        public GmailLoginPage GmailLogin => GetPage<GmailLoginPage>();
        public GmailPasswordPage GmailPassword => GetPage<GmailPasswordPage>();
        public GmailDraftsPage GmailDrafts => GetPage<GmailDraftsPage>();
        public GmailInboxPage GmailInbox => GetPage<GmailInboxPage>();
    }
}
