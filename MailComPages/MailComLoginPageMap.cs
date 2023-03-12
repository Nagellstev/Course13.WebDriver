using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTest.MailComPages
{
    public class MailComLoginPageMap
    {
        public IWebDriver Driver;

        public WebPageLocator WebPage { get; set; }

        public IWebElement LoginButton
        {
            get
            {
                return WebPage.LocateElement(By.Id("login-button"));
            }
        }
        public IWebElement LoginField
        {
            get
            {
                return WebPage.LocateElement(By.Id("login-email"));
            }
        }
        public IWebElement PasswordField
        {
            get
            {
                return WebPage.LocateElement(By.Id("login-password"));
            }
        }
        //login green button
        public IWebElement SubmitButton 
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//*[@id=\"header-login-box\"]/form/button"));
            }
        }

        public MailComLoginPageMap(IWebDriver browser)
        {
            Driver = browser;
            WebPage = new WebPageLocator(browser);
        }
        /*
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
        */
    }
}
