using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTest.MailComPages
{
    public class MailComSite
    {
        #region Declarations

        private readonly IWebDriver Driver;
        private readonly string url = @"https://www.mail.com/";
        protected MailComEmailPageMap mailComEmailPageMap
        {
            get
            {
                return new MailComEmailPageMap(Driver);
            }
        }
        protected MailComHomePageMap mailComHomePageMap
        {
            get
            {
                return new MailComHomePageMap(Driver);
            }
        }
        protected MailComLoginErrorPageMap mailComLoginErrorPageMap
        {
            get
            {
                return new MailComLoginErrorPageMap(Driver);
            }
        }
        protected MailComLoginPageMap mailComLoginPageMap
        {
            get
            {
                return new MailComLoginPageMap(Driver);
            }
        }
        protected MailComMyAccountPageMap mailComMyAccountPageMap
        {
            get
            {
                return new MailComMyAccountPageMap(Driver);
            }
        }
        protected MailComTopControlsLoggedMap mailComTopControlsLoggedMap
        {
            get
            {
                return new MailComTopControlsLoggedMap(Driver);
            }
        }

        #endregion

        public MailComSite(IWebDriver browser)
        {
            Driver = browser;
        }

        public MailComValidator Validate()
        {
            return new MailComValidator(Driver);
        }

        #region User scenarios

        public void Navigate()
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void Login(string login, string password)
        {
            mailComLoginPageMap.LoginButton.Click();
            mailComLoginPageMap.LoginField.SendKeys(login);
            mailComLoginPageMap.PasswordField.SendKeys(password);
            mailComLoginPageMap.PasswordField.Submit();
        }

        #endregion
    }
}
