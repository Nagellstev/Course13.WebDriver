using MailComTest;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using System;
using System.Numerics;
using TutanotaComTest;
using static System.Net.Mime.MediaTypeNames;

namespace TwoMailsTest
{
    public class TwoMailsTest
    {
        public class MailComFixture : IDisposable
        {
            public MailComPage mailComPage { get; set; }

            public MailComFixture()
            {
                // SetUp handled in each test case
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--disable-notifications"); // to disable notification
                mailComPage = new MailComPage(new ChromeDriver(options));
                mailComPage.OpenBrowser();
            }

            public void Dispose()
            {
                // Closure handled in each test case
                mailComPage.CloseBrowser();
            }
        }

        public class TutanotaComFixture : IDisposable
        {
            public TutanotaComPage tutanotaComPage { get; set; }

            public TutanotaComFixture()
            {
                // SetUp handled in each test case
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--disable-notifications"); // to disable notification
                tutanotaComPage = new TutanotaComPage(new ChromeDriver(options));
                tutanotaComPage.OpenBrowser();
            }

            public void Dispose()
            {
                // Closure handled in each test case
                tutanotaComPage.CloseBrowser();
            }
        }

        [Theory]
        [InlineData("")]
        //[InlineData("https://www.mail.com", "kazimir@myself.com", "pKiVGd6qAHSb6#D")]
        //[InlineData("https://mail.tutanota.com", "oscar-claude@tutanota.com", "SfTxJeeGnhKzk9j")]

        public void SendAndCheckEmailTest(string arg)
        {
            string urlMailCom = "https://www.mail.com";
            string loginMailCom = "kazimir@myself.com";
            string passwordMailCom = "pKiVGd6qAHSb6#D";

            string urlTutanotaCom = "https://mail.tutanota.com";
            string loginTutanotaCom = "oscar-claude@tutanota.com";
            string passwordTutanotaCom = "SfTxJeeGnhKzk9j";

            string email = "oscar-claude@tutanota.com";
            string subject = "Hi from fan";

            //generating random text
            Random random = new Random();
            int symbolsQuantity = random.Next(10, 22);
            string text = "";
            for (int i = 0; i < symbolsQuantity; i++)
            {
                text += (char)random.Next(33, 127);
            }

            //Arrange
            MailComFixture mailComFixture = new MailComFixture();
            MailComPage mailComPage = mailComFixture.mailComPage;

            TutanotaComFixture tutanotaComFixture = new TutanotaComFixture();
            TutanotaComPage tutanotaComPage = tutanotaComFixture.tutanotaComPage;

            //Act
            //sending email from mail.com to tutanota.com
            mailComPage.OpenBrowser();
            mailComPage.GotoUrl(urlMailCom);

            mailComPage.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(mailComPage.driver, TimeSpan.FromSeconds(10));

            mailComPage.Login(loginMailCom, passwordMailCom);
            wait = new WebDriverWait(mailComPage.driver, TimeSpan.FromSeconds(10));

            mailComPage.driver.SwitchTo().Frame("home");

            mailComPage.EnterEmailWriter();

            mailComPage.driver.SwitchTo().DefaultContent();
            mailComPage.driver.SwitchTo().Frame("mail");

            mailComPage.ToInput(email);

            mailComPage.SubjectInput(subject);

            mailComPage.driver.SwitchTo().Frame(mailComPage.driver.FindElement(By.XPath("//div[@id=\"cke_1_contents\"]/iframe")));//[@class=\"cke_wysiwyg_frame cke_reset\"")));

            mailComPage.TextInput(text);

            mailComPage.driver.SwitchTo().DefaultContent();
            mailComPage.driver.SwitchTo().Frame("mail");
            mailComPage.SendClick();

            //mailComFixture.Dispose();

            //checking received email on tutanota.com

            //tutanotaComPage.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //WebDriverWait tutaWait = new WebDriverWait(tutanotaComPage.driver, TimeSpan.FromSeconds(10));

            tutanotaComPage.OpenBrowser();
            tutanotaComPage.GotoUrl(urlTutanotaCom);

            tutanotaComPage.Login(loginTutanotaCom, passwordTutanotaCom);

            tutanotaComPage.LastLetterClick();

            string result = tutanotaComPage.driver.FindElement(By.Id("mail-body")).Text;

            /*
            IWebElement shadowHost = tutanotaComPage.driver.FindElement(By.Id("mail-body"));
            ISearchContext shadowRoot = shadowHost.GetShadowRoot();
            result = shadowRoot.FindElement(By.XPath("//div")).GetAttribute("class");//"//div/div/div")).Text;
            */

            //Assert
            //Assert.Contains(text, result);
            Assert.Equal(text, result);

            mailComFixture.Dispose();
            tutanotaComFixture.Dispose();
        }

        /*
        [Theory]
        [InlineData("")]
        //[InlineData("https://www.mail.com", "kazimir@myself.com", "pKiVGd6qAHSb6#D")]
        //[InlineData("https://mail.tutanota.com", "oscar-claude@tutanota.com", "SfTxJeeGnhKzk9j")]

        public void RespondWithNewNicknameTest(string arg)
        {
            string urlMailCom = "https://www.mail.com";
            string loginMailCom = "kazimir@myself.com";
            string passwordMailCom = "pKiVGd6qAHSb6#D";

            string urlTutanotaCom = "https://mail.tutanota.com";
            string loginTutanotaCom = "oscar-claude@tutanota.com";
            string passwordTutanotaCom = "SfTxJeeGnhKzk9j";

            string email = "oscar-claude@tutanota.com";
            string subject = "Hi from fan";

            string newNickname = "Edouard Manet";

            //generating random text
            Random random = new Random();
            int symbolsQuantity = random.Next(10, 22);
            string text = "";
            for (int i = 0; i < symbolsQuantity; i++)
            {
                text += (char)random.Next(33, 127);
            }

            //Arrange
            MailComFixture mailComFixture = new MailComFixture();
            MailComPage mailComPage = mailComFixture.mailComPage;

            TutanotaComFixture tutanotaComFixture = new TutanotaComFixture();
            TutanotaComPage tutanotaComPage = tutanotaComFixture.tutanotaComPage;

            //Act
            //sending email from mail.com to tutanota.com
            mailComPage.OpenBrowser();
            mailComPage.GotoUrl(urlMailCom);

            mailComPage.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(mailComPage.driver, TimeSpan.FromSeconds(10));

            mailComPage.Login(loginMailCom, passwordMailCom);
            wait = new WebDriverWait(mailComPage.driver, TimeSpan.FromSeconds(10));

            mailComPage.driver.SwitchTo().Frame("home");

            mailComPage.EnterEmailWriter();

            mailComPage.driver.SwitchTo().DefaultContent();
            mailComPage.driver.SwitchTo().Frame("mail");

            mailComPage.ToInput(email);

            mailComPage.SubjectInput(subject);

            mailComPage.driver.SwitchTo().Frame(mailComPage.driver.FindElement(By.XPath("//div[@id=\"cke_1_contents\"]/iframe")));//[@class=\"cke_wysiwyg_frame cke_reset\"")));

            mailComPage.TextInput(text);

            mailComPage.driver.SwitchTo().DefaultContent();
            mailComPage.driver.SwitchTo().Frame("mail");
            mailComPage.SendClick();

            //checking received email on tutanota.com

            tutanotaComPage.OpenBrowser();
            tutanotaComPage.GotoUrl(urlTutanotaCom);

            tutanotaComPage.Login(loginTutanotaCom, passwordTutanotaCom);

            tutanotaComPage.LastLetterClick();

            tutanotaComPage.RespondButtonClick();

            tutanotaComPage.RespondWriting(newNickname);

            tutanotaComPage.SendButtonClick();

            //checking received nickname on mail.com
            try
            {
                mailComPage.CloseSucsessMessage();
            }
            catch
            {
                //
            }

            mailComPage.EnterInbox();

            try
            {
                mailComPage.LastSentLetterCheck();
            }
            catch (StaleElementReferenceException exeption)
            {
                mailComPage.LastSentLetterCheck();
            }

            string result = tutanotaComPage.driver.FindElement(By.Id("mail-body")).Text;

            //Assert
            //Assert.Contains(text, result);
            Assert.Equal(newNickname, result);

            mailComFixture.Dispose();
            tutanotaComFixture.Dispose();
        }
        */

        [Theory]
        [InlineData("")]
        //[InlineData("https://www.mail.com", "kazimir@myself.com", "pKiVGd6qAHSb6#D")]
        //[InlineData("https://mail.tutanota.com", "oscar-claude@tutanota.com", "SfTxJeeGnhKzk9j")]

        public void RespondWithNewNicknameTest(string arg)
        {
            SendAndCheckEmailTest(arg);

            string urlTutanotaCom = "https://mail.tutanota.com";
            string loginTutanotaCom = "oscar-claude@tutanota.com";
            string passwordTutanotaCom = "SfTxJeeGnhKzk9j";

            string email = "oscar-claude@tutanota.com";
            string subject = "New nickname";
            string newNickname = "Edouard Manet";

            //Arrange
            TutanotaComFixture tutanotaComFixture = new TutanotaComFixture();
            TutanotaComPage tutanotaComPage = tutanotaComFixture.tutanotaComPage;

            //Act
            //sending new nickname from tutanota.com to mail.com
            tutanotaComPage.OpenBrowser();
            tutanotaComPage.GotoUrl(urlTutanotaCom);

            tutanotaComPage.Login(loginTutanotaCom, passwordTutanotaCom);

            tutanotaComPage.LastLetterClick();

            tutanotaComPage.RespondButtonClick();

            tutanotaComPage.RespondWriting(newNickname);

            tutanotaComPage.SendButtonClick();

            //checking letter in sent

            //tutanotaComPage.SentClick();

            //tutanotaComPage.LastLetterClick();

            //string result = tutanotaComPage.driver.FindElement(By.Id("mail-body")).Text;

            ////Assert
            //Assert.Contains(newNickname, result);

            tutanotaComFixture.Dispose();
        }

        [Theory]
        [InlineData("")]
        //[InlineData("https://www.mail.com", "kazimir@myself.com", "pKiVGd6qAHSb6#D")]
        //[InlineData("https://mail.tutanota.com", "oscar-claude@tutanota.com", "SfTxJeeGnhKzk9j")]

        public void CheckingNewNicknameTest(string arg)
        {
            //Arrange
            MailComFixture mailComFixture = new MailComFixture();
            MailComPage mailComPage = mailComFixture.mailComPage;

            string urlMailCom = "https://www.mail.com";
            string loginMailCom = "kazimir@myself.com";
            string passwordMailCom = "pKiVGd6qAHSb6#D";

            //Act
            //checking last mail inbox mail.com

            mailComPage.OpenBrowser();
            mailComPage.GotoUrl(urlMailCom);

            mailComPage.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(mailComPage.driver, TimeSpan.FromSeconds(10));

            mailComPage.Login(loginMailCom, passwordMailCom);
            wait = new WebDriverWait(mailComPage.driver, TimeSpan.FromSeconds(10));
            mailComPage.driver.SwitchTo().Frame("home");

            mailComPage.EnterInbox();

            mailComPage.driver.SwitchTo().DefaultContent();
            mailComPage.driver.SwitchTo().Frame("mail");

            mailComPage.LastSentLetterCheck();

            mailComPage.driver.SwitchTo().Frame("mail-display-content");

            string result = mailComPage.driver.FindElement(By.XPath("//html/body/div[1]")).Text;

            //Assert

            Assert.Contains("Edouard Manet", result);

            mailComFixture.Dispose();
        }
    }
}