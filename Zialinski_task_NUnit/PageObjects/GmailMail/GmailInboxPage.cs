using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Zialinski_task_NUnit.PageObjects.Base;

namespace Zialinski_task_NUnit.PageObjects.GmailMail
{
    public class GmailInboxPage 
    {
        private readonly WebDriverWait _wait;
        private const string SavedLableXPath = "//td[contains(@class, 'HE')]//span[contains(text(), 'Saved')]";

        [FindsBy(How = How.XPath, Using = "//div[@jscontroller='DUNnfe']//div[@role='button']")]
        private IWebElement ComposeButton { get; set; }

        [FindsBy(How = How.Name, Using = "subjectbox")]
        private IWebElement MessageSubjectBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@role='navigation']//a[@href='https://mail.google.com/mail/#drafts']")]
        private IWebElement DraftsLink { get; set; }

        public GmailInboxPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        
        public void ClickComposeButton()
        {
            ComposeButton.Click();
        }

        public void InputMessageSubject(string messageSubject)
        {
            MessageSubjectBox.Click();
            MessageSubjectBox.SendKeys(messageSubject);
        }

        public bool IsLoginSucceed(IWebDriver driver)
        {
            try
            {
                return _wait.Until(elemDisplayed => ComposeButton.Displayed);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsSavedLabelDisplayed(IWebDriver driver)
        {
            try
            {
                _wait.Until(ExpectedConditions.ElementExists(By.XPath(SavedLableXPath)));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void GoToDrafts()
        {
            DraftsLink.Click();
        }
    }
}
