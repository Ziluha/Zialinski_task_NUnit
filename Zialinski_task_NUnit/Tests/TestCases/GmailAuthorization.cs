using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Zialinski_task_NUnit.Tests.Base;

namespace Zialinski_task_NUnit.Tests.TestCases
{
    [TestFixture]
    [Parallelizable]
    public class GmailAuthorization : BaseTest
    {
        public static IEnumerable<string> Brws()
        {
            string[] browsers = {"Chrome", "Firefox"};

            foreach (var brow in browsers)
            {
                yield return brow;
            }
        }

        [Test]
        [TestCaseSource("Brws")]
        public void AuthWithValidData(string browserName)
        {
            InitDriver(browserName);
            Pages.GmailLogin.InputLogin(ConfigurationManager.AppSettings["ValidLogin"]);
            Pages.GmailLogin.SubmitLogin();
            Pages.GmailPassword.InputPassword(ConfigurationManager.AppSettings["ValidPassword"], Driver);
            Pages.GmailPassword.SubmitPassword();
            Assert.True(Pages.GmailInbox.IsLoginSucceed(Driver), "User was not logged in");
        }
    }
}
