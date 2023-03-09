using MailComTest;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium.Support.UI;
using System;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace MailTest
{
    public class MailTest
    {
        public class MailComFixture : IDisposable
        {
            public MailComPage mailComPage { get; set; } 

            public MailComFixture()
            {
                // SetUp handled in each test case
                mailComPage = new MailComPage(new ChromeDriver());
                mailComPage.OpenBrowser();
            }

            public void Dispose()
            {
                // Closure handled in each test case
                mailComPage.CloseBrowser();
            }
        }

        [Theory]
        [InlineData("https://www.mail.com", "Free email accounts | Register today at mail.com")]

        public void GotoUrlTest(string url, string expectedTitle)
        {
            //Arrange
            MailComFixture mailComFixture = new MailComFixture();
            MailComPage page = mailComFixture.mailComPage;

            //Act
            string result = "";

            try
            {
                page.GotoUrl(url);
                result = page.driver.Title;
            }
            catch (Exception exeption)
            {
                result = $"Error: {exeption.Message}";
            }

            //Assert
            Assert.Equal(result, expectedTitle);

            mailComFixture.Dispose();
        }

        [Theory]
        [InlineData("https://www.mail.com", "kazimir@myself.com", "pKiVGd6qAHSb6#D")]

        public void ProperLoginTest(string url, string login, string password)
        {
            //Arrange
            MailComFixture mailComFixture = new MailComFixture();
            MailComPage page = mailComFixture.mailComPage;

            //Act
            string result = "";

            try
            {
                page.OpenBrowser();
                page.GotoUrl(url);

                page.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                WebDriverWait wait = new WebDriverWait(page.driver, TimeSpan.FromSeconds(10));

                page.Login(login, password);
                wait = new WebDriverWait(page.driver, TimeSpan.FromSeconds(10));
                page.driver.SwitchTo().Frame("home");

                result = page.driver.FindElement(By.XPath("//span[@class=\"username\"]")).Text;
            }
            catch (Exception exeption)
            {
                result = $"Error: {exeption.Message}";
            }

            //Assert
            Assert.Equal(login, result);

            mailComFixture.Dispose();
        }

        [Theory]
        [InlineData("https://www.mail.com", "kazimir@myself.com", "123456", "PLEASE TRY AGAIN!")]
        [InlineData("https://www.mail.com", "kazimir@myself.com", "", "PLEASE TRY AGAIN!")]
        [InlineData("https://www.mail.com", "", "", "PLEASE TRY AGAIN!")]

        public void UnproperLoginTest(string url, string login, string password, string expected)
        {
            //Arrange
            MailComFixture mailComFixture = new MailComFixture();
            MailComPage page = mailComFixture.mailComPage;

            //Act
            string result = "";

            try
            {
                page.OpenBrowser();
                page.GotoUrl(url);

                page.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                WebDriverWait wait = new WebDriverWait(page.driver, TimeSpan.FromSeconds(10));

                page.Login(login, password);
                wait = new WebDriverWait(page.driver, TimeSpan.FromSeconds(10));

                result = page.driver.FindElement(By.XPath("//div[@class=\"text-wrapper\"]/h1")).Text;
            }
            catch (Exception exeption)
            {
                result += $"Error: {exeption.Message}";
            }

            //Assert
            Assert.Equal(expected, result);

            mailComFixture.Dispose();
        }

        [Theory]
        [InlineData("https://www.mail.com", "kazimir@myself.com", "pKiVGd6qAHSb6#D")]

        public void EnterEmailTest(string url, string login, string password)
        {
            //Arrange
            MailComFixture mailComFixture = new MailComFixture();
            MailComPage page = mailComFixture.mailComPage;

            //Act
            string result = "";

            try
            {
                page.OpenBrowser();
                page.GotoUrl(url);

                page.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                WebDriverWait wait = new WebDriverWait(page.driver, TimeSpan.FromSeconds(10));

                page.Login(login, password);
                wait = new WebDriverWait(page.driver, TimeSpan.FromSeconds(10));
                page.driver.SwitchTo().Frame("home");

                page.EnterEmailWriter();

                page.driver.SwitchTo().DefaultContent();

                page.driver.SwitchTo().Frame("mail");//page.driver.FindElement(By.Id("thirdPartyFrame_mail")));

                result = page.driver.FindElement(By.XPath("//option[@selected=\"selected\"]")).Text;
            }
            catch (Exception exeption)
            {
                result += $"Error: {exeption.Message}";
            }

            //Assert
            Assert.Contains(login, result.ToLower());

            mailComFixture.Dispose();
        }
        [Theory]
        [InlineData("https://www.mail.com", "kazimir@myself.com", "pKiVGd6qAHSb6#D")]

        public void SendEmailTest(string url, string login, string password)
        {
            //Arrange
            MailComFixture mailComFixture = new MailComFixture();
            MailComPage page = mailComFixture.mailComPage;

            //Act
            string result = "";

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

            mailComFixture.Dispose();
        }
    }
}