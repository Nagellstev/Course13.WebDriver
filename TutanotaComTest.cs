using MailTest;
using MailTest.MailComPages;
using MailTest.TutanotaPages;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium.Support.UI;
using System;
using System.Numerics;
using static MailComTest.MailComTest;
using static System.Net.Mime.MediaTypeNames;

namespace TutanotaComTest
{
    public class TutanotaComTest
    {
        public class TutanotaComFixture : IDisposable
        {
            private ChromeDriver chromeDriver;// = new ChromeDriver();
            public TutanotaComSite tutanotaComSite { get; set; }

            public TutanotaComFixture()
            {
                // SetUp handled in each test case
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--disable-notifications"); // to disable notification
                chromeDriver = new ChromeDriver(options);
                tutanotaComSite = new TutanotaComSite(chromeDriver);

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
        [InlineData("Mail. Done. Right. Tutanota Login & Sign up for an Ad-free Mailbox")]

        public void NavigateTest(string expectedTitle)
        {
            //Arrange
            TutanotaComFixture tutanotaComFixture = new TutanotaComFixture();
            TutanotaComSite tutanotaComSite = tutanotaComFixture.tutanotaComSite;

            try
            {
                //Act
                tutanotaComSite.Navigate();

                //Assert
                tutanotaComSite.Validate().Navigate(expectedTitle);
            }
            finally
            {
                tutanotaComFixture.Dispose();
            }
        }

        [Theory]
        [InlineData("oscar-claude@tutanota.com", "SfTxJeeGnhKzk9j")]

        public void ProperLoginTest(string login, string password)
        {
            //Arrange
            TutanotaComFixture tutanotaComFixture = new TutanotaComFixture();
            TutanotaComSite tutanotaComSite = tutanotaComFixture.tutanotaComSite;

            try
            {
                //Act
                tutanotaComSite.Navigate();
                tutanotaComSite.Login(login, password);

                //Assert
                tutanotaComSite.Validate().ProperLogin(login);
            }
            finally
            {
                tutanotaComFixture.Dispose();
            }
        }

        [Theory]
        [InlineData("oscar-claude@tutanota.com", "123456", "��c��������� ������")]
        [InlineData("oscar-claude@tutanota.com", "", "��c��������� ������")]
        [InlineData("", "", "��c��������� ������")]

        public void UnproperLoginTest(string login, string password, string expected)
        {
            //Arrange
            TutanotaComFixture tutanotaComFixture = new TutanotaComFixture();
            TutanotaComSite tutanotaComSite = tutanotaComFixture.tutanotaComSite;

            try
            {
                //Act
                tutanotaComSite.Navigate();
                tutanotaComSite.Login(login, password);

                //Assert
                tutanotaComSite.Validate().UnproperLogin(expected);
            }
            finally
            {
                tutanotaComFixture.Dispose();
            }
        }

        [Theory]
        [InlineData("kazimir@myself.com", "subject", "text")]
        public void SendLetterTest(string to, string subject, string text)
        {
            //Arrange
            TutanotaComFixture tutanotaComFixture = new TutanotaComFixture();
            TutanotaComSite tutanotaComSite = tutanotaComFixture.tutanotaComSite;
            string login = "oscar-claude@tutanota.com";
            string password = "SfTxJeeGnhKzk9j";

            try
            {
                //Act
                tutanotaComSite.Navigate();
                tutanotaComSite.Login(login, password);
                tutanotaComSite.SendLetter(to, subject, text);

                List<string> outcomingLetter = tutanotaComSite.ReadOutcomingLetter();

                //Assert
                tutanotaComSite.Validate().SentLetterCheck("kazimir@"/*to*/, subject, text, outcomingLetter[0], outcomingLetter[1], outcomingLetter[2]);
            }
            finally
            {
                tutanotaComFixture.Dispose();
            }
        }

    }
}