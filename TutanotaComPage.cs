using OpenQA.Selenium.Support.UI;
using System.Security.Claims;
using System.Xml.Linq;

namespace TutanotaComTest
{
    public class TutanotaComPage
    {
        public IWebDriver driver;

        public TutanotaComPage(IWebDriver browser)
        {
            driver = browser;
        }

        public void OpenBrowser()
        {
            driver.Manage().Window.Maximize();
        }

        public void GotoUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void CloseBrowser()
        {
            driver.Close();
            driver.Quit();
        }

        public void SwitchToFrame(string frame)
        {
            driver.SwitchTo().Frame(frame);
        }

        public void Login(string login, string password)
        {
            //on the page find and fill login and password fields and submit
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement loginField = wait.Until(x => x.FindElement(By.XPath("//input[@type=\"email\"]")));
            loginField.SendKeys(login);
            IWebElement passwordField = driver.FindElement(By.XPath("//input[@type=\"password\"]"));
            passwordField.SendKeys(password);
            passwordField.Submit();

            //find and click Login Button
            IWebElement loginButton = wait.Until(x => x.FindElement(By.XPath("//div[@class=\"pt\"]/button")));
            loginButton.Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //driver.SwitchTo().Frame("home");
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //IWebElement iframe = wait.Until(x => x.FindElement(By.Id("thirdPartyFrame_home")));
            //driver.SwitchTo().Frame("home");
        }

        public void LastLetterClick()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement lastLetter = wait.Until(x => x.FindElement(By.XPath("//div[@class=\"flex-grow min-width-0\"]")));
            lastLetter.Click();
        }

        public void NewLetterSending(string email, string subject, string text)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement newLetter = wait.Until(x => x.FindElement(By.XPath("//button[@class=\"bg-transparent button-height full-width noselect limit-width border-radius-small\"]")));
            newLetter.Click();

            IWebElement toField = wait.Until(x => x.FindElement(By.XPath("//div[@class=\"rel\"]/div/div/div/div/div/div[@class=\"flex-grow rel\"]/input")));
            toField.SendKeys(email);
            toField.Submit();

            IWebElement subjectField = driver.FindElement(By.XPath("//div[@class=\"row\"]/div/div/div/div/div[@class =\"flex-grow rel\"]/input"));
            subjectField.SendKeys(subject);
            subjectField.Submit();

            IWebElement textField = driver.FindElement(By.XPath("//div[@class=\"pt-s text scroll-x break-word-links flex flex-column flex-grow\"]/div/div[1]/br"));
            textField.SendKeys(text);
            textField.Submit();

            IWebElement sendButton = driver.FindElement(By.XPath("//div[@class=\"flex-third overflow-hidden mr-negative-s flex justify-end\"]/button"));
            sendButton.Click();
        }

        public void RespondButtonClick()
        {
            //LastLetterClick();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement respondButton = wait.Until(x => x.FindElement(By.XPath("//div[@class=\"header mlr-safe-inset\"]/div[@class=\"flex click pl-l\"]/div[@class=\"flex-end items-center ml-between-s mt-xs\"]/button[1]")));
            respondButton.Click();
        }

        public void RespondWriting(/*string email, string subject, */string text)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement textField = driver.FindElement(By.XPath("//div[@class=\"pt-s text scroll-x break-word-links flex flex-column flex-grow\"]/div/div[1]/br"));
            //textField.Clear();
            textField.SendKeys(text);
        }

        public void SendButtonClick()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement sendButton = driver.FindElement(By.XPath("//div[@class=\"flex-third overflow-hidden mr-negative-s flex justify-end\"]/button"));
            sendButton.Click();
        }

        public void SentClick()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement sentButton = wait.Until(x => x.FindElement(By.XPath("//div[@class=\"sidebar-section mb\"]/div[4]")));//div[3]/a")));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(sentButton));
            //IWebElement sentButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class=\"sidebar-section mb\"]/div[4]")));//.ElementToBeClickable(sentButton));
            sentButton.Click();
            //Actions actions = new Actions(driver);
            //actions.MoveToElement(sentButton).Click().Build().Perform();
        }
    }
}
