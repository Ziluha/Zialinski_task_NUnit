using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Zialinski_task_NUnit.PageObjects.Base;

namespace Zialinski_task_NUnit.PageObjects.GmailAuthorization
{
    public class GmailLoginPage
    {
        private WebDriverWait _wait;

        [FindsBy(How = How.Id, Using = "identifierId")]
        private IWebElement LoginField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[jsname=B34EJ]")]
        private IWebElement LoginErrorLabel { get; set; }

        [FindsBy(How = How.Id, Using = "identifierNext")]
        private IWebElement SubmitLoginButton { get; set; }
        

        public void InputLogin(string login)
        {
            LoginField.Click();
            LoginField.SendKeys(login);
        }

        public void SubmitLogin()
        {
            SubmitLoginButton.Click();
        }

        public bool IsLoginErrorLabelPresented(IWebDriver driver)
        {
            try
            {
                _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                return _wait.Until(elemDisplayed => LoginErrorLabel.Displayed);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
