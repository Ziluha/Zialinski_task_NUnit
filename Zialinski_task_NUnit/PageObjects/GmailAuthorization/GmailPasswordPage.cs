using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Zialinski_task_NUnit.PageObjects.GmailAuthorization
{
    public class GmailPasswordPage 
    {
        private readonly WebDriverWait _wait;

        [FindsBy(How = How.CssSelector, Using = "div[jsname=B34EJ]")]
        private IWebElement PasswordErrorLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[id=password] div[jsname=YRMmle]")]
        private IWebElement InputPasswordLabel { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement PasswordField { get; set; }

        [FindsBy(How = How.Id, Using = "passwordNext")]
        private IWebElement SubmitPasswordButton { get; set; }

        public GmailPasswordPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void InputPassword(string password)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(PasswordField))
                .Click();
            PasswordField.SendKeys(password);
        }

        public void SubmitPassword()
        {
            SubmitPasswordButton.Click();
        }

        public bool IsPasswordErrorLabelPresented()
        {
            try
            {
                return _wait.Until(elemDisplayed => PasswordErrorLabel.Displayed);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsLoginApplied()
        {
            try
            {
                return _wait.Until(elemDisplayed => InputPasswordLabel.Displayed);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}