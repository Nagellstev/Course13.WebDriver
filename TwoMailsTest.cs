using MailTest.MailComPages;
using MailTest.TutanotaPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using MailTest.Utilities;

namespace MailTest
{
    public class TwoMailsTest : IDisposable
    {
        private ChromeDriver chromeDriver = new ChromeDriver();
        private MailComSite mailComSite { get; set; }


        private TutanotaComSite tutanotaComSite { get; set; }

        public TwoMailsTest()
        {
            // SetUp handled in each test case
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications"); // to disable notification
            chromeDriver = new ChromeDriver(options);

            tutanotaComSite = new TutanotaComSite(chromeDriver);

            mailComSite = new MailComSite(chromeDriver);

            chromeDriver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            // Closure handled in each test case
            chromeDriver.Close();
            chromeDriver.Quit();
        }
        /// <summary>
        /// send letter from mail.com to tutanota.com
        /// check if subject and text match
        /// </summary>
        [Fact]
        public void SendFromMailToTutanotaTest()
        {
            //Arrange
            string loginMail = "kazimir@myself.com";
            string passwordMail = "pKiVGd6qAHSb6#D";

            string loginTutanota = "pierre-auguste@tutanota.com";
            string passwordTutanota = "rsKTnpgAd7YjYTY";

            string subject = StringGenerators.SubjectGenerator();
            string text = StringGenerators.RandomStringGenerator();

            //Act
            mailComSite.Navigate();
            mailComSite.Login(loginMail, passwordMail);
            mailComSite.SendLetter(loginTutanota, subject, text);

            tutanotaComSite.Navigate();
            tutanotaComSite.Login(loginTutanota, passwordTutanota);

            List<string> incomingLetter = tutanotaComSite.ReadIncomingLetter();

            //Assert
            tutanotaComSite.Validate().SentLetterCheck(loginMail, subject, text, incomingLetter[0], incomingLetter[1], incomingLetter[2]);
        }

        /// <summary>
        /// send letter from mail.com to tutanota.com
        /// check if subject and text match
        /// respond from tutanota with new alias for mail.com
        /// </summary>
        [Fact]
        public void SendFromMailToTutanotaAndReplyTest()
        {
            
            //Arrange
            string loginMail = "kazimir@myself.com";
            string passwordMail = "pKiVGd6qAHSb6#D";

            string loginTutanota = "pierre-auguste@tutanota.com";
            string passwordTutanota = "rsKTnpgAd7YjYTY";

            string subject = StringGenerators.SubjectGenerator();
            string text = StringGenerators.RandomStringGenerator();

            //Act
            mailComSite.Navigate();
            mailComSite.Login(loginMail, passwordMail);
            mailComSite.SendLetter(loginTutanota, subject, text);

            tutanotaComSite.Navigate();
            tutanotaComSite.Login(loginTutanota, passwordTutanota);

            List<string> incomingLetter = tutanotaComSite.ReadIncomingLetter();

            //Assert
            tutanotaComSite.Validate().SentLetterCheck(loginMail, subject, text, incomingLetter[0], incomingLetter[1], incomingLetter[2]);
            
            //SendFromMailToTutanotaTest();

            //send new alias for mail.com
            string replyText = "Edouard Manet";
            tutanotaComSite.ReplyLetter(replyText);

            List<string> outcomingLetter = tutanotaComSite.ReadOutcomingLetter();

            tutanotaComSite.Validate().SentLetterCheck("kazimir@"/*to*/, subject, replyText, outcomingLetter[0], outcomingLetter[1], outcomingLetter[2]);
        }
    }
}

