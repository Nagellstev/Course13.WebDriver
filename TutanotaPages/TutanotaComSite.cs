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

        public void SendLetter(string to, string subject, string text)
        {
            tutanotaComEmailPageMap.NewLetterButton.Click();
            Thread.Sleep(1000);
            tutanotaComEmailPageMap.ToField.SendKeys(to);//"kazimir@myself.com");
            tutanotaComEmailPageMap.SubjectField.SendKeys(subject);

            if (tutanotaComEmailPageMap.ConfidentialButton.GetAttribute("toggled") == "true")
            {
                tutanotaComEmailPageMap.ConfidentialButton.Click();
            }

            tutanotaComEmailPageMap.TextEditorField.Clear();
            tutanotaComEmailPageMap.TextEditorField.SendKeys(text);
            tutanotaComEmailPageMap.SendButton.Click();
        }

        public List<string> ReadIncomingLetter()
        {
            List<string> letter = new List<string>();
            Thread.Sleep(5000);
            tutanotaComEmailPageMap.IncomingButton.Click();
            tutanotaComEmailPageMap.LastLetter.Click();
            letter.Add(tutanotaComEmailPageMap.LetterFrom.Text);
            letter.Add(tutanotaComEmailPageMap.LetterSubject.Text);
            letter.Add(tutanotaComEmailPageMap.LetterText.Text);
            return letter;
            //return ReadLetter(tutanotaComEmailPageMap.IncomingButton);
        }

        public List<string> ReadOutcomingLetter()
        {
            List<string> letter = new List<string>();
            Thread.Sleep(5000);
            tutanotaComEmailPageMap.SentButton.Click();
            Thread.Sleep(5000);
            tutanotaComEmailPageMap.LastLetter.Click();
            letter.Add(tutanotaComEmailPageMap.LetterTo.Text);
            letter.Add(tutanotaComEmailPageMap.LetterSubject.Text);
            letter.Add(tutanotaComEmailPageMap.LetterText.Text);
            return letter;
            //return ReadLetter(tutanotaComEmailPageMap.SentButton);
        }

        public void ReplyLetter(string text)
        {
            tutanotaComEmailPageMap.ReplyButton.Click();
            Thread.Sleep(5000);
            //tutanotaComEmailPageMap.LetterText.Clear();
            tutanotaComEmailPageMap.LetterText.FindElement(By.XPath("//br")).SendKeys(text);
            tutanotaComEmailPageMap.SendButton.Click();
        }

        private List<string> ReadLetter(IWebElement button)
        {
            List<string> letter = new List<string>();
            button.Click();
            tutanotaComEmailPageMap.LastLetter.Click();
            letter.Add(tutanotaComEmailPageMap.LetterTo.Text);
            letter.Add(tutanotaComEmailPageMap.LetterSubject.Text);
            letter.Add(tutanotaComEmailPageMap.LetterText.Text);
            return letter;
        }

        #endregion
    }
}
