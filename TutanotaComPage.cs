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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement lastLetter = wait.Until(x => x.FindElement(By.XPath("//div[@class=\"flex-grow min-width-0\"]")));
            lastLetter.Click();
        }
    }
}
