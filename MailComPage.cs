namespace MailComTest
{
    public class MailComPage
    {
        public IWebDriver driver;

        public MailComPage(IWebDriver browser)
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
            //find and click Login Button
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement loginButton = wait.Until(x => x.FindElement(By.Id("login-button")));
            loginButton.Click();

            //on the next page find and fill login and password fields and submit
            IWebElement loginField = wait.Until(x => x.FindElement(By.Id("login-email")));
            loginField.SendKeys(login);
            IWebElement passwordField = driver.FindElement(By.Id("login-password"));
            passwordField.SendKeys(password);
            passwordField.Submit();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //driver.SwitchTo().Frame("home");
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //IWebElement iframe = wait.Until(x => x.FindElement(By.Id("thirdPartyFrame_home")));
            //driver.SwitchTo().Frame("home");
        }
    }
}
