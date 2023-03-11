using System.ComponentModel;
using System.Runtime.Intrinsics.X86;

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
        }

        public void EnterEmailWriter()
        {
            //find and click "Compose Email"
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement composeEmail = wait.Until(x => x.FindElement(By.XPath("//div[@id=\"navigation\"]/ul/li[@class=\"item\"]/a[@class=\"iac mail_compose\"]")));
            composeEmail.Click();
        }

        public void EnterInbox()
        {
            //find and click "Compose Email"
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement composeEmail = wait.Until(x => x.FindElement(By.XPath("//div[@id=\"navigation\"]/ul/li[@class=\"item top-fade\"]/a[@class=\"mail\"]")));
            composeEmail.Click();
        }

        public void ToInput(string to)
        {
            //find and fill input line"
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement toInput = wait.Until(x => x.FindElement(By.XPath("//div[@class=\"form-element-multiobjecttextfield js-component\"]/div[@class=\"select2-container select2-container-multi js-select2\"]/ul[@class=\"select2-choices\"]/li[@class=\"select2-search-field\"]/input[@type=\"text\"]")));
            toInput.SendKeys(to);
        }

        public void SubjectInput(string subject)
        {
            //find and fill input line"
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement subjectInput = driver.FindElement(By.XPath("//div[@class=\"compose-header_item compose-header_subject mailobjectpanel-textfield js-component mailobjectpanel\"]/div[@class=\"mailobjectpanel_content\"]/input[@type=\"text\"]"));
            subjectInput.SendKeys(subject);
        }

        public void TextInput(string text)
        {
            //find and fill input line"
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement textInput = driver.FindElement(By.XPath("//html/body/div/br"));
            textInput.SendKeys(text);
        }

        public void SendClick()
        {
            //find and click "send" button
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement sendButton = driver.FindElement(By.Id("compose-send-button"));
            sendButton.Click();
        }

        public void CloseSucsessMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement sentButton = wait.Until(x => x.FindElement(By.XPath("//div[@id=\"system-message\"]/div[@class=\"system-message is-success\"]/a[@data-webdriver=\"closeLink\"]")));
            sentButton.Click();
        }

        public void SentClick()
        {
            //find and click "sent" button on the left menu
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement sentButton = wait.Until(x => x.FindElement(By.XPath("//div[@class=\"panel-body\"]/ul/li[@data-webdriver=\"SENT\"]")));
            sentButton.Click();
        }

        public void LastSentLetterCheck()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement lastLetter = wait.Until(x => x.FindElement(By.XPath("//table[@id=\"mail-list\"]/tbody/tr/td[@class=\"last\"]")));
            lastLetter.Click();
        }

        public void SendEmail(string email, string subject, string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //Enter to email text editor
            driver.SwitchTo().DefaultContent();
            EnterEmailWriter();
            driver.SwitchTo().DefaultContent();

            //fill "to" field
            driver.SwitchTo().Frame("mail");
            ToInput(email);

            //input subject
            SubjectInput(subject);

            //input text
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@class=\"cke_wysiwyg_frame cke_reset\"")));
            TextInput(text);

            //click "send" button
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame("mail");
            SendClick();
        }
    }
}
