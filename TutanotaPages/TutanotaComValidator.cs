﻿using MailTest.MailComPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTest.TutanotaPages
{
    public class TutanotaComValidator
    {
        #region Declarations

        private readonly IWebDriver Driver;
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

        public TutanotaComValidator(IWebDriver browser)
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
            Assert.Equal(expected.ToLower(), tutanotaComEmailPageMap.EmailAddress.Text.ToLower());
        }

        public void UnproperLogin(string expected)
        {
            Assert.Equal(expected.ToLower(), tutanotaComLoginPageMap.ErrorMessage.Text.ToLower());
        }

        public void SentLetterCheck(
            string expectedTo, string expectedSubject, string expectedText,
            string realTo, string realSubject, string realText
            )
        {
            //to check
            Assert.Contains(expectedTo.ToLower(), realTo);

            //subject check
            Assert.Contains(expectedSubject, realSubject);

            //text check
            Assert.Contains(expectedText, realText);
            //Assert.Contains(expectedText.ToLower(), realText);
        }

        #endregion
    }
}
