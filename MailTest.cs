using MailComTest;
using OpenQA.Selenium.Support.UI;
using System.Numerics;

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
        [InlineData("https://tutanota.com", "Secure email: Tutanota free encrypted email.")]

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

            //Arrange
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

            //Arrange
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

            //Arrange
            Assert.Equal(expected, result);

            mailComFixture.Dispose();
        }

    }
}