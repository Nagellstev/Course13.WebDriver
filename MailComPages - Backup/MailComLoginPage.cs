using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTest.MailComPages
{
    public class MailComLoginPage
    {
        public IWebDriver driver;

        public WebPageControls webPageControls { get; set; }

        private By loginButtonLocator = By.Id("login-button");
        private By loginFieldLocator = By.Id("login-email");
        private By passwordFieldLocator = By.Id("login-password");
        private By loginGreenButtonLocator = By.XPath("//*[@id=\"header-login-box\"]/form/button");

        public MailComLoginPage(IWebDriver browser)
        {
            webPageControls = new WebPageControls(browser);
            driver = webPageControls.driver;
        }

        public void SwitchToFrame()
        {
            webPageControls.driver.SwitchTo().DefaultContent();
        }

        public void LoginButtonPress() 
        { 
            webPageControls.PressButton(loginButtonLocator);
        }

        public void LoginFieldInput(string login)
        {
            webPageControls.FillingField(loginFieldLocator, login);
        }

        public void PasswordFieldInput(string password)
        {
            webPageControls.FillingField(passwordFieldLocator, password);
        }

        public void PasswordFieldSubmit()
        {
            webPageControls.SubmitField(passwordFieldLocator);
        }

        public void LoginSubmitButton()
        {
            webPageControls.PressButton(loginGreenButtonLocator);
        }

        //Login scenario
        public void Login(string login, string password)
        {
            webPageControls.driver.SwitchTo().DefaultContent();
            webPageControls.PressButton(loginButtonLocator);
            webPageControls.FillingField(loginFieldLocator, login);
            webPageControls.FillingField(passwordFieldLocator, password);
            webPageControls.SubmitField(passwordFieldLocator);
        }
    }
}
