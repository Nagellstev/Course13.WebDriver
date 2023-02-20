using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace MailTest
{
    public class MailTest
    {
        public static string MailComUrl = "https://www.mail.com";
        public static string TutanotaComUrl = "https://tutanota.com/";

        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }

        public class ParallelTests : IDisposable
        {
            public ParallelTests()
            {
                // SetUp handled in each test case

            }

            public void Dispose()
            {
                // Closure handled in each test case

            }
        }

        [Theory]
        [InlineData("https://www.mail.com", "Free email accounts | Register today at mail.com")]
        [InlineData("https://tutanota.com", "Secure email: Tutanota free encrypted email.")]

        public void UrlTest(string url, string expectedTitle)
        {
            //Arrange
            // Local Selenium WebDriver
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Driver.Navigate().GoToUrl(url);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //Act
            string result = Driver.Title;
            //Arrange
            Assert.Equal(result, expectedTitle);

            Driver.Close();
            Driver.Quit();
        }

    }
}