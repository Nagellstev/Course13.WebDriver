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

        public void SendLetter(string to, string subject, string text)
        {
            mailComEmailPageMap.SwitchToDefaultContent();
            mailComTopControlsLoggedMap.EmailButton.Click();
            mailComEmailPageMap.SwitchToMailFrame();
            mailComEmailPageMap.ComposeEmailButton.Click();
            mailComEmailPageMap.ToField.SendKeys(to);
            mailComEmailPageMap.SubjectField.SendKeys(subject);
            mailComEmailPageMap.NewLetterTextInput(text);
            mailComEmailPageMap.SendButton.Click();
            mailComEmailPageMap.CloseSucsessMessage.Click();
            mailComEmailPageMap.SwitchToDefaultContent();
        }

        public List<string> ReadIncomingLetter()
        {
            List<string> letter = new List<string>();
            mailComEmailPageMap.SwitchToDefaultContent();
            mailComTopControlsLoggedMap.EmailButton.Click();
            mailComEmailPageMap.SwitchToMailFrame();
            mailComEmailPageMap.InboxButton.Click();
            Thread.Sleep(5000);
            mailComEmailPageMap.LastLetter.Click();
            //try
            //{
            //    mailComEmailPageMap.LastLetter.Click();
            //}
            //catch (StaleElementReferenceException)
            //{
            //    mailComEmailPageMap.LastLetter.Click();
            //}
            letter.Add(mailComEmailPageMap.LetterFrom.Text);
            letter.Add(mailComEmailPageMap.LetterSubject.Text);
            letter.Add(mailComEmailPageMap.EmailTextRead());
            mailComEmailPageMap.SwitchToDefaultContent();
            return letter;
        }

        public List<string> ReadOutcomingLetter()
        {
            List<string> letter = new List<string>();
            mailComEmailPageMap.SwitchToDefaultContent();
            mailComTopControlsLoggedMap.EmailButton.Click();
            mailComEmailPageMap.SwitchToMailFrame();
            mailComEmailPageMap.SentButton.Click();
            try
            {
                mailComEmailPageMap.LastLetter.Click();
            }
            catch (StaleElementReferenceException)
            {
                mailComEmailPageMap.LastLetter.Click();
            }
            letter.Add(mailComEmailPageMap.LetterTo.GetAttribute("title"));
            letter.Add(mailComEmailPageMap.LetterSubject.Text);
            letter.Add(mailComEmailPageMap.EmailTextRead());
            mailComEmailPageMap.SwitchToDefaultContent();
            return letter;
        }

        public void ChangeName(string firstName, string lastName, string password)
        {
            mailComEmailPageMap.SwitchToDefaultContent();
            mailComTopControlsLoggedMap.MoreButton.Click();
            mailComTopControlsLoggedMap.MyAccountButton.Click();
            mailComMyAccountPageMap.SwitchToMyAccountFrame();
            mailComMyAccountPageMap.PersonalData.Click();
            mailComMyAccountPageMap.Profile.Click();
            mailComMyAccountPageMap.FirstNameField.Clear();
            mailComMyAccountPageMap.FirstNameField.SendKeys(firstName);
            mailComMyAccountPageMap.LastNameField.Clear();
            mailComMyAccountPageMap.LastNameField.SendKeys(lastName);
            mailComMyAccountPageMap.PasswordField.SendKeys(password);
            mailComMyAccountPageMap.SaveChangesButton.Click();
            mailComEmailPageMap.SwitchToDefaultContent();
        }

        public string ReadName()
        {
            mailComEmailPageMap.SwitchToDefaultContent();
            mailComTopControlsLoggedMap.MoreButton.Click();
            mailComTopControlsLoggedMap.MyAccountButton.Click();
            mailComMyAccountPageMap.SwitchToMyAccountFrame();
            mailComMyAccountPageMap.MyAccount.Click();
            string name = mailComMyAccountPageMap.Name.Text;
            mailComEmailPageMap.SwitchToDefaultContent();
            return name;
        }

        #endregion
    }
}
