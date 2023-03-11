using MailComTest;
using MailTest.MailComPages;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium.Support.UI;
using System;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace MailTest
{
    public class MailComTest
    {
        public class MailComFixture : IDisposable
        {
            private ChromeDriver chromeDriver = new ChromeDriver();
            public MailComLoginPage mailComLoginPage { get; set; }
            public MailComLoginErrorPage mailComLoginErrorPage { get; set; }
            public MailComHomePage mailComHomePage { get; set; }
            public MailComEmailPage mailComEmailPage { get; set; }
            public MailComTopControlsLogged mailComTopControlsLogged { get; set; }

            public MailComFixture()
            {
                // SetUp handled in each test case
                mailComLoginPage = new MailComLoginPage(chromeDriver);
                mailComLoginErrorPage = new MailComLoginErrorPage(chromeDriver);
                mailComHomePage = new MailComHomePage(chromeDriver);
                mailComEmailPage = new MailComEmailPage(chromeDriver);
                mailComTopControlsLogged = new MailComTopControlsLogged(chromeDriver);

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
        [InlineData("https://www.mail.com", "Free email accounts | Register today at mail.com")]

        public void GotoUrlTest(string url, string expectedTitle)
        {
            //Arrange
            MailComFixture mailComFixture = new MailComFixture();
            MailComLoginPage page = mailComFixture.mailComLoginPage;

            string result = "";

            //Act
            page.driver.Navigate().GoToUrl(url);

            try
            {
                result = page.driver.Title;
            }
            finally
            {
                //Assert
                Assert.Equal(result, expectedTitle);

                mailComFixture.Dispose();
            }
        }

        [Theory]
        [InlineData("https://www.mail.com", "kazimir@myself.com", "pKiVGd6qAHSb6#D")]

        public void ProperLoginTest(string url, string login, string password)
        {
            //Arrange
            MailComFixture mailComFixture = new MailComFixture();
            MailComLoginPage loginPage = mailComFixture.mailComLoginPage;
            MailComHomePage homePage = mailComFixture.mailComHomePage;

            string result = "";

            //Act
            loginPage.driver.Navigate().GoToUrl(url);

            try
            {
                loginPage.Login(login, password);

                homePage.SwitchToFrame();
                result = homePage.GetCurrentEmail();

                //Assert
                Assert.Equal(login, result);
            }
            finally
            {
                mailComFixture.Dispose();
            }
        }

        [Theory]
        [InlineData("https://www.mail.com", "kazimir@myself.com", "123456", "PLEASE TRY AGAIN!")]
        [InlineData("https://www.mail.com", "kazimir@myself.com", "", "PLEASE TRY AGAIN!")]
        [InlineData("https://www.mail.com", "", "", "PLEASE TRY AGAIN!")]

        public void UnproperLoginTest(string url, string login, string password, string expected)
        {
            //Arrange
            MailComFixture mailComFixture = new MailComFixture();
            MailComLoginPage loginPage = mailComFixture.mailComLoginPage;
            MailComLoginErrorPage loginErrorPage = mailComFixture.mailComLoginErrorPage;

            string result = "";

            //Act
            loginPage.driver.Navigate().GoToUrl(url);

            try
            {
                loginPage.Login(login, password);

                result = loginErrorPage.ErrorMessageHeader();

                //Assert
                Assert.Equal(expected, result);
            }
            finally
            {
                mailComFixture.Dispose();
            }
        }

        [Theory]
        [InlineData("https://www.mail.com", "kazimir@myself.com", "pKiVGd6qAHSb6#D")]

        public void SendEmailTest(string url, string login, string password)
        {
            //Arrange
            MailComFixture mailComFixture = new MailComFixture();
            MailComLoginPage loginPage = mailComFixture.mailComLoginPage;
            MailComEmailPage emailPage = mailComFixture.mailComEmailPage; 
            MailComTopControlsLogged topControlsLogged = mailComFixture.mailComTopControlsLogged;

            string email = "OSCAR-CLAUDE@TUTANOTA.COM";
            string subject = "Hi from fan";
            string text = "Hey, Oscar! You're cool!";
            string result = "";

            //Act
            loginPage.driver.Navigate().GoToUrl(url);

            loginPage.Login(login, password);

            topControlsLogged.EmailButtonPress();

            emailPage.SendEmail(email, subject, text);

            emailPage.CloseSucsessMessage();

            emailPage.SentClick();

            emailPage.LastLetterClick();

            emailPage.FromCheck();

            emailPage.;
            /*

            page.OpenBrowser();
            page.GotoUrl(url);

            page.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(page.driver, TimeSpan.FromSeconds(10));

            page.Login(login, password);
            wait = new WebDriverWait(page.driver, TimeSpan.FromSeconds(10));

            page.driver.SwitchTo().Frame("home");

            page.EnterEmailWriter();

            string email = "OSCAR-CLAUDE@TUTANOTA.COM";
            string subject = "Hi from fan";
            string text = "Hey, Oscar! You're cool!";

            page.driver.SwitchTo().DefaultContent();
            page.driver.SwitchTo().Frame("mail");

            page.ToInput(email);

            page.SubjectInput(subject);

            page.driver.SwitchTo().Frame(page.driver.FindElement(By.XPath("//div[@id=\"cke_1_contents\"]/iframe")));//[@class=\"cke_wysiwyg_frame cke_reset\"")));

            page.TextInput(text);

            page.driver.SwitchTo().DefaultContent();
            page.driver.SwitchTo().Frame("mail");
            page.SendClick();

            try
            {
                page.CloseSucsessMessage();
            }
            catch
            {
                //ignore
            }

            //check sent e-mail in "sent" folder
            page.SentClick();

            try
            {
                page.LastSentLetterCheck();
            }
            catch (StaleElementReferenceException exeption)
            {
                page.LastSentLetterCheck();
            }

            page.driver.SwitchTo().Frame("mail-display-content");
            result += page.driver.FindElement(By.XPath("//html/body/div/div")).Text;

            //Assert
            Assert.Equal(text.ToLower(), result.ToLower());

            mailComFixture.Dispose();*/
        }
    }
}