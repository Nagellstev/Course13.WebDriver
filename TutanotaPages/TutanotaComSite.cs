using MailTest.MailComPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTest.TutanotaPages
{
    public class TutanotaComSite
    {
        #region Declarations

        private readonly IWebDriver Driver;
        private readonly string url = @"https://mail.tutanota.com";

        protected TutanotaComEmailPageMap tutanotaComEmailPageMap
        {
            get
            {
                return new TutanotaComEmailPageMap(Driver);
            }
        }
        protected TutanotaComLoginPageMap tutanotaComLoginPageMap
        {
            get
            {
                return new TutanotaComLoginPageMap(Driver);
            }
        }

        #endregion

        public TutanotaComSite(IWebDriver browser)
        {
            Driver = browser;
        }

        public TutanotaComValidator Validate()
        {
            return new TutanotaComValidator(Driver);
        }

        #region User scenarios

        public void Navigate()
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void Login(string login, string password)
        {
            tutanotaComLoginPageMap.LoginField.SendKeys(login);
            tutanotaComLoginPageMap.PasswordField.SendKeys(password);
            tutanotaComLoginPageMap.PasswordField.Submit();
            tutanotaComLoginPageMap.SubmitButton.Click();
        }

        #endregion
    }
}
