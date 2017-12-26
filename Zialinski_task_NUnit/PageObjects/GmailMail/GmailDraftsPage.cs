using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Zialinski_task_NUnit.PageObjects.Base;

namespace Zialinski_task_NUnit.PageObjects.GmailMail
{
    public class GmailDraftsPage : BasePage
    {
        private WebDriverWait _wait;
        private const string InDraftCheck = "Drafts";

        [FindsBy(How = How.XPath, Using = "(//div[@role='button']//span[@class='ts'])[last()]")]
        private IWebElement CountOfDrafts { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@role='main']//span[@class='bog']")]
        private IList<IWebElement> DraftSubjectsList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[role=main] div[role=checkbox]>div")]
        private IList<IWebElement> DraftCheckboxesList { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@role='button' and @act='16']/div")]
        private IWebElement DiscardDraftsButton { get; set; }

        public GmailDraftsPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsDraftAdded(string messageSubject)
        {
            return DraftSubjectsList != null && DraftSubjectsList.First().Text == messageSubject;
        }

        public bool IsDraftPageOpened(IWebDriver driver)
        {
            try
            {
                _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                return _wait.Until(elemDisplayed => driver.Title.Contains(InDraftCheck));
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ChooseDraft(int draftNumber)
        {
            IWebElement checkBox = DraftCheckboxesList[draftNumber];
            checkBox.Click();
        }

        public void ClickDiscardDraftsButton()
        {
            DiscardDraftsButton.Click();
        }

        public int GetCountOfDrafts()
        {
            return Int32.Parse(CountOfDrafts.Text);
        }
    }
}
