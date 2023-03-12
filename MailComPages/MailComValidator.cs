using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTest.MailComPages
{
    public class MailComValidator
    {
        #region Declarations
        private readonly IWebDriver Driver;
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

        public MailComValidator(IWebDriver browser)
        {
            Driver = browser;
        }

        #region Validations
        public void Navigate(string expected)
        {
            Assert.Equal(expected.ToLower(), Driver.Title.ToLower());
        }

        public void ProperLogin(string expected)
        {
            mailComHomePageMap.SwitchToHomeFrame();
            Assert.Equal(expected.ToLower(), mailComHomePageMap.EmailAddress.Text.ToLower());
        }

        public void UnproperLogin(string expected)
        {
            Assert.Equal(expected.ToLower(), mailComLoginErrorPageMap.ErrorMessageHeader.Text.ToLower());
        }

        #endregion
    }
}
