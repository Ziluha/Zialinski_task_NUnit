using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Zialinski_task_NUnit.Tests.Base;

namespace Zialinski_task_NUnit.Tests.TestCases
{
    [TestFixture]
    [Parallelizable]
    public class GmailFailTest : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowsersToRunWith")]
        public void FailCheck(string browserName)
        {
            InitDriver(browserName);
            Pages.GmailLogin.InputLogin(ConfigurationManager.AppSettings["InvalidLogin"]);
            Pages.GmailLogin.SubmitLogin();
            Assert.True(Pages.GmailPassword.IsLoginApplied(Driver), "Password page is not opened");
        }
    }
}
