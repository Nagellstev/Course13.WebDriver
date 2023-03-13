using MailTest;
using MailTest.MailComPages;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium.Support.UI;
using System;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace MailComTest
{
    public class MailComTest
    {
        public class MailComFixture : IDisposable
        {
            private ChromeDriver chromeDriver = new ChromeDriver();
            public MailComSite mailComSite { get; set; }

            public MailComFixture()
            {
                // SetUp handled in each test case
                mailComSite = new MailComSite(chromeDriver);

                chromeDriver.Manage().Window.Maximize();
            }

            public void Dispose()
            {
                // Closure handled in each test case
                chromeDriver.Close();
                chromeDriver.Quit();
            }
        }

        [Theory]
        [InlineData("Free email accounts | Register today at mail.com")]

        public void NavigateTest(string expectedTitle)
        {
            //Arrange
            MailComFixture mailComFixture = new MailComFixture();
            MailComSite mailComSite = mailComFixture.mailComSite;


            try
            {
                //Act
                mailComSite.Navigate();

                //Assert
                mailComSite.Validate().Navigate(expectedTitle);
            }
            finally
            {
                mailComFixture.Dispose();
            }
        }

        [Theory]
        [InlineData("kazimir@myself.com", "pKiVGd6qAHSb6#D")]

        public void ProperLoginTest(string login, string password)
        {
            //Arrange
            MailComFixture mailComFixture = new MailComFixture();
            MailComSite mailComSite = mailComFixture.mailComSite;

            try
            {
                //Act
                mailComSite.Navigate();
                mailComSite.Login(login, password);

                //Assert
                mailComSite.Validate().ProperLogin(login);
            }
            finally
            {
                mailComFixture.Dispose();
            }
        }

        [Theory]
        [InlineData("kazimir@myself.com", "123456", "PLEASE TRY AGAIN!")]
        [InlineData("kazimir@myself.com", "", "PLEASE TRY AGAIN!")]
        [InlineData("", "", "PLEASE TRY AGAIN!")]

        public void UnproperLoginTest(string login, string password, string expected)
        {
            //Arrange
            MailComFixture mailComFixture = new MailComFixture();
            MailComSite mailComSite = mailComFixture.mailComSite;

            try
            {
                //Act
                mailComSite.Navigate();
                mailComSite.Login(login, password);

                //Assert
                mailComSite.Validate().UnproperLogin(expected);
            }
            finally
            {
                mailComFixture.Dispose();
            }
        }

        [Theory]
        [InlineData("oscar-claude@tutanota.com", "subject", "text")]

        public void SendLetterTest(string to, string subject, string text)
        {
            //Arrange
            MailComFixture mailComFixture = new MailComFixture();
            MailComSite mailComSite = mailComFixture.mailComSite;
            string login = "kazimir@myself.com";
            string password = "pKiVGd6qAHSb6#D";

            try
            {
                //Act
                mailComSite.Navigate();
                mailComSite.Login(login, password);
                mailComSite.SendLetter(to, subject, text);

                List<string> outcomingLetter = mailComSite.ReadOutcomingLetter();

                //Assert
                mailComSite.Validate().SentLetterCheck(to, subject, text, outcomingLetter[0], outcomingLetter[1], outcomingLetter[2]);
            }
            finally
            {
                mailComFixture.Dispose();
            }
        }
    }
}