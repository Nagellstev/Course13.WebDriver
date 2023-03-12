using TutanotaComTest;
using OpenQA.Selenium.Support.UI;
using System.Numerics;

namespace TutanotaComTest
{
    public class TutanotaComTest1
    {
        public class TutanotaComFixture1 : IDisposable
        {
            public TutanotaComPage tutanotaComPage { get; set; } 

            public TutanotaComFixture1()
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
        [InlineData("https://mail.tutanota.com", "tutanota login")]

        public void GotoUrlTest(string url, string expectedTitle)
        {
            //Arrange
            TutanotaComFixture1 tutanotaComFixture = new TutanotaComFixture1();
            TutanotaComPage page = tutanotaComFixture.tutanotaComPage;

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
            Assert.Contains(expectedTitle, result.ToLower());

            tutanotaComFixture.Dispose();
        }

        [Theory]
        [InlineData("https://mail.tutanota.com", "oscar-claude@tutanota.com", "SfTxJeeGnhKzk9j")]

        public void ProperLoginTest(string url, string login, string password)
        {
            //Arrange
            TutanotaComFixture1 tutanotaComFixture = new TutanotaComFixture1();
            TutanotaComPage page = tutanotaComFixture.tutanotaComPage;

            //Act
            string result = "";

            try
            {
                page.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                //page.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
                WebDriverWait wait = new WebDriverWait(page.driver, TimeSpan.FromSeconds(10));

                page.OpenBrowser();
                page.GotoUrl(url);

                page.Login(login, password);

                //result = page.driver.Title;
                result = page.driver.FindElement(By.XPath("//div[@class=\"sidebar-section mb\"]/div/small")).Text;
                //result = page.driver.FindElement(By.XPath("//head/title")).Text;
            }
            catch (Exception exeption)
            {
                result = $"Error: {exeption.Message}";
            }

            //Assert
            Assert.Contains(login, result.ToLower());
            //Assert.Equal(login, result);

            tutanotaComFixture.Dispose();
        }

        [Theory]
        [InlineData("https://mail.tutanota.com", "oscar-claude@tutanota.com", "123456", "Не подошли данные для доступа.  Попробуйте ещё.")]
        [InlineData("https://mail.tutanota.com", "oscar-claude@tutanota.com", "", "Не подошли данные для доступа.  Попробуйте ещё.")]
        [InlineData("https://mail.tutanota.com", "", "", "Не подошли данные для доступа.  Попробуйте ещё.")]

        public void UnproperLoginTest(string url, string login, string password, string expected)
        {
            //Arrange
            TutanotaComFixture1 mailComFixture = new TutanotaComFixture1();
            TutanotaComPage page = mailComFixture.tutanotaComPage;

            //Act
            string result = "";

            try
            {
                page.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                //page.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
                WebDriverWait wait = new WebDriverWait(page.driver, TimeSpan.FromSeconds(10));

                page.OpenBrowser();
                page.GotoUrl(url);

                page.Login(login, password);

                Thread.Sleep(TimeSpan.FromSeconds(2));

                result = page.driver.FindElement(By.XPath("//div/form/p[@class=\"center statusTextColor\"]/small")).Text;
            }
            catch (Exception exeption)
            {
                result += $"Error: {exeption.Message}";
            }

            //Assert
            Assert.Contains(expected, result);

            mailComFixture.Dispose();
        }

    }
}