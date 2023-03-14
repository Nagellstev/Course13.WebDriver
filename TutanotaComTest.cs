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
    public class TutanotaComTest : IDisposable
    {
        private ChromeDriver chromeDriver;// = new ChromeDriver();
        private TutanotaComSite tutanotaComSite { get; set; }

        public TutanotaComTest()
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

        [Theory]
        [InlineData("Mail. Done. Right. Tutanota Login & Sign up for an Ad-free Mailbox")]

        public void NavigateTest(string expectedTitle)
        {
            //Arrange

            //Act
            tutanotaComSite.Navigate();

            //Assert
            tutanotaComSite.Validate().Navigate(expectedTitle);
        }

        [Theory]
        [InlineData("pierre-auguste@tutanota.com", "rsKTnpgAd7YjYTY")]
        public void ProperLoginTest(string login, string password)
        {
            //Arrange

            //Act
            tutanotaComSite.Navigate();
            tutanotaComSite.Login(login, password);

            //Assert
            tutanotaComSite.Validate().ProperLogin(login);
        }

        [Theory]
        [InlineData("pierre-auguste@tutanota.com", "123456", "Воcстановить доступ")]
        [InlineData("pierre-auguste@tutanota.com", "", "Воcстановить доступ")]
        [InlineData("", "", "Воcстановить доступ")]
        public void UnproperLoginTest(string login, string password, string expected)
        {
            //Arrange

            //Act
            tutanotaComSite.Navigate();
            tutanotaComSite.Login(login, password);

            //Assert
            tutanotaComSite.Validate().UnproperLogin(expected);
        }

        [Theory]
        [InlineData("kazimir@myself.com", "subject", "text")]
        public void SendLetterTest(string to, string subject, string text)
        {
            //Arrange
            string login = "pierre-auguste@tutanota.com";
            string password = "rsKTnpgAd7YjYTY";

            //Act
            tutanotaComSite.Navigate();
            tutanotaComSite.Login(login, password);
            tutanotaComSite.SendLetter(to, subject, text);

            List<string> outcomingLetter = tutanotaComSite.ReadOutcomingLetter();

            //Assert
            tutanotaComSite.Validate().SentLetterCheck("kazimir@"/*to*/, subject, text, outcomingLetter[0], outcomingLetter[1], outcomingLetter[2]);
        }
    }
}