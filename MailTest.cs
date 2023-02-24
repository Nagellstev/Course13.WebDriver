using MailComTest;
using OpenQA.Selenium.Support.UI;

namespace MailTest
{
    public class MailTest
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }

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
            page.GotoUrl(url);
            string result = page.driver.Title;

            //Arrange
            Assert.Equal(result, expectedTitle);

            mailComFixture.Dispose();
        }

        [Theory]
        [InlineData("https://www.mail.com", "kazimir@myself.com", "pKiVGd6qAHSb6#D")]
        //[InlineData("https://www.mail.com", "kazimir@myself.com", "123456")]
        //[InlineData("https://www.mail.com", "kazimir@myself.com", "")]
        //[InlineData("https://tutanota.com", "oscar-claude@tutanota.com", "SfTxJeeGnhKzk9j")]
        //[InlineData("https://tutanota.com", "oscar-claude@tutanota.com", "123456")]
        //[InlineData("https://tutanota.com", "oscar-claude@tutanota.com", "")]

        public void LoginTest(string url, string login, string password)
        {

            //Arrange
            MailComFixture mailComFixture = new MailComFixture();
            MailComPage page = mailComFixture.mailComPage;

            //Act
            Driver.Manage().Window.Maximize();
            page.GotoUrl(url);
            page.Login(login, password);
            page.driver.SwitchTo().Frame("home");

            string result = "";

            WebDriverWait wait = new WebDriverWait(page.driver, TimeSpan.FromSeconds(5));

            try
            {
                result = page.driver.FindElement(By.XPath("//span[@class=\"username\"]")).Text;
            }
            catch (Exception exeption)
            {
                result += $"Error: {exeption.Message}";
            }

            //Arrange
            Assert.Equal(login, result);

            mailComFixture.Dispose();
        }

        [Theory]
        [InlineData("https://www.mail.com", "kazimir@myself.com", "pKiVGd6qAHSb6#D")]
        public void OldLoginTest(string url, string login, string password)
        {
            //Arrange
            // Local Selenium WebDriver
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Driver.Navigate().GoToUrl(url);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement query = Driver.FindElement(By.Id("login-button"));
            new Actions(Driver).MoveToElement(query).Click().Perform();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Driver.FindElement(By.Id("login-email")).SendKeys(login);
            query = Driver.FindElement(By.Id("login-password"));
            query.SendKeys(password);
            query.Submit();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            Driver.SwitchTo().Frame("home");
            string result = "";

            //Act
            result = Driver.FindElement(By.XPath("//span[@class=\"username\"]")).Text;

            //Arrange
            Assert.Equal(login, result);
            Driver.Close();
            Driver.Quit();
        }

        [Theory]
        [InlineData("https://www.mail.com", "kazimir@myself.com", "pKiVGd6qAHSb6#D")]
        public void Old2LoginTest(string url, string login, string password)
        {
            //Arrange
            // Local Selenium WebDriver
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Driver.Navigate().GoToUrl(url);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement query = Driver.FindElement(By.Id("login-button"));
            new Actions(Driver).MoveToElement(query).Click().Perform();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Driver.FindElement(By.Id("login-email")).SendKeys(login);
            query = Driver.FindElement(By.Id("login-password"));
            query.SendKeys(password);
            query.Submit();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            Driver.SwitchTo().Frame("home");
            string result = "";

            //Act
            result = Driver.FindElement(By.XPath("//span[@class=\"username\"]")).Text;

            //Arrange
            Assert.Equal(login, result);
            Driver.Close();
            Driver.Quit();
        }
    }
}