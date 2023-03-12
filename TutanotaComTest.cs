using MailTest;
using MailTest.MailComPages;
using MailTest.TutanotaPages;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium.Support.UI;
using System;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace TutanotaComTest
{
    public class TutanotaComTest
    {
        public class TutanotaComFixture : IDisposable
        {
            private ChromeDriver chromeDriver = new ChromeDriver();
            public TutanotaComSite tutanotaComSite { get; set; }

            public TutanotaComFixture()
            {
                // SetUp handled in each test case
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
        [InlineData("oscar-claude@tutanota.com", "123456", "Воcстановить доступ")]
        [InlineData("oscar-claude@tutanota.com", "", "Воcстановить доступ")]
        [InlineData("", "", "Воcстановить доступ")]

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
    }
}