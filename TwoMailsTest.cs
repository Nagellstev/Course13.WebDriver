using MailTest.MailComPages;
using MailTest.TutanotaPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MailTest
{
    public class TwoMailsTest
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

        /// <summary>
        /// send letter from mail.com to tutanota.com
        /// check if subject and text match
        /// </summary>
        [Theory]
        [InlineData("")]
        public void SendFromMailToTutanotaTest(string arg)
        {
            //Arrange
            MailComFixture mailComFixture = new MailComFixture();
            MailComSite mailComSite = mailComFixture.mailComSite;
            string loginMail = "kazimir@myself.com";
            string passwordMail = "pKiVGd6qAHSb6#D";

            TutanotaComFixture tutanotaComFixture = new TutanotaComFixture();
            TutanotaComSite tutanotaComSite = tutanotaComFixture.tutanotaComSite;
            string loginTutanota = "oscar-claude@tutanota.com";
            string passwordTutanota = "SfTxJeeGnhKzk9j";

            string subject = SubjectGenerator();
            string text = RandomStringGenerator();

            try
            {
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
            finally
            {
                mailComFixture.Dispose();
                tutanotaComFixture.Dispose();
            }
        }

        /// <summary>
        /// send letter from mail.com to tutanota.com
        /// check if subject and text match
        /// respond from tutanota with new alias for mail.com
        /// </summary>
        [Theory]
        [InlineData("")]
        public void SendFromMailToTutanotaAndReplyTest(string arg)
        {
            //Arrange
            MailComFixture mailComFixture = new MailComFixture();
            MailComSite mailComSite = mailComFixture.mailComSite;
            string loginMail = "kazimir@myself.com";
            string passwordMail = "pKiVGd6qAHSb6#D";

            TutanotaComFixture tutanotaComFixture = new TutanotaComFixture();
            TutanotaComSite tutanotaComSite = tutanotaComFixture.tutanotaComSite;
            string loginTutanota = "oscar-claude@tutanota.com";
            string passwordTutanota = "SfTxJeeGnhKzk9j";

            string subject = SubjectGenerator();
            string text = RandomStringGenerator();

            try
            {
                //Act
                mailComSite.Navigate();
                mailComSite.Login(loginMail, passwordMail);
                mailComSite.SendLetter(loginTutanota, subject, text);

                tutanotaComSite.Navigate();
                tutanotaComSite.Login(loginTutanota, passwordTutanota);

                List<string> incomingLetter = tutanotaComSite.ReadIncomingLetter();

                //Assert
                tutanotaComSite.Validate().SentLetterCheck(loginMail, subject, text, incomingLetter[0], incomingLetter[1], incomingLetter[2]);

                //send new alias for mail.com
                tutanotaComSite.ReplyLetter("Edouard Manet");
            }
            finally
            {
                mailComFixture.Dispose();
                tutanotaComFixture.Dispose();
            }
        }

        private string RandomStringGenerator()
        {
            Random random = new Random();
            int symbolsQuantity = random.Next(10, 22);
            string text = "";
            for (int i = 0; i < symbolsQuantity; i++)
            {
                text += (char)random.Next(33, 127);
            }
            return text;
        }
        private string SubjectGenerator()
        {
            return $"Letter from {DateTime.Now}";
        }
    }
}
