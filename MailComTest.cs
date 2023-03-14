using MailTest;
using MailTest.MailComPages;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium.Support.UI;
using System;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace MailComTest
{
    public class MailComTest : IDisposable
    {
        private ChromeDriver chromeDriver = new ChromeDriver();
        private MailComSite mailComSite { get; set; }

        public MailComTest()
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

        [Theory]
        [InlineData("Free email accounts | Register today at mail.com")]

        public void NavigateTest(string expectedTitle)
        {
            //Arrange

            //Act
            mailComSite.Navigate();

            //Assert
            mailComSite.Validate().Navigate(expectedTitle);
        }

        [Theory]
        [InlineData("kazimir@myself.com", "pKiVGd6qAHSb6#D")]

        public void ProperLoginTest(string login, string password)
        {
            //Arrange

            //Act
            mailComSite.Navigate();
            mailComSite.Login(login, password);

            //Assert
            mailComSite.Validate().ProperLogin(login);
        }

        [Theory]
        [InlineData("kazimir@myself.com", "123456", "PLEASE TRY AGAIN!")]
        [InlineData("kazimir@myself.com", "", "PLEASE TRY AGAIN!")]
        [InlineData("", "", "PLEASE TRY AGAIN!")]

        public void UnproperLoginTest(string login, string password, string expected)
        {
            //Arrange

            //Act
            mailComSite.Navigate();
            mailComSite.Login(login, password);

            //Assert
            mailComSite.Validate().UnproperLogin(expected);
        }

        [Theory]
        [InlineData("pierre-auguste@tutanota.com", "subject", "text")]

        public void SendLetterTest(string to, string subject, string text)
        {
            //Arrange
            string login = "kazimir@myself.com";
            string password = "pKiVGd6qAHSb6#D";

            //Act
            mailComSite.Navigate();
            mailComSite.Login(login, password);
            mailComSite.SendLetter(to, subject, text);

            List<string> outcomingLetter = mailComSite.ReadOutcomingLetter();

            //Assert
            mailComSite.Validate().SentLetterCheck(to, subject, text, outcomingLetter[0], outcomingLetter[1], outcomingLetter[2]);
        }

        [Fact]
        public void ChangeNameTest()
        {
            //Arrange
            string login = "kazimir@myself.com";
            string password = "pKiVGd6qAHSb6#D";

            //Act
            mailComSite.Navigate();
            mailComSite.Login(login, password);
            string text = mailComSite.ReadIncomingLetter()[2];

            string[] newName = text.Split(' ', '\n', '\t', '\r', '\b', ',', '.');

            string firstName = newName[0];
            string lastName = newName[1];

            mailComSite.ChangeName(firstName, lastName, password);

            string realName = mailComSite.ReadName();

            //Assert
            mailComSite.Validate().ChangedNameCheck($"{firstName} {lastName}", realName);
        }
    }
}