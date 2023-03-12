using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTest.TutanotaPages
{
    public class TutanotaComLoginPageMap
    {
        public IWebDriver Driver;

        public WebPageLocator WebPage { get; set; }

        public IWebElement LoginField
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//input[@type=\"email\"]"));
            }
        }
        public IWebElement PasswordField
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//input[@type=\"password\"]"));
            }
        }
        public IWebElement SubmitButton
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//div[@class=\"pt\"]/button"));
            }
        }
        public IWebElement ErrorMessage
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//form/p/small/a"));//a[@href=\"/recover\"]"));
            }
        }

        public TutanotaComLoginPageMap(IWebDriver browser)
        {
            Driver = browser;
            WebPage = new WebPageLocator(browser);
        }
    }
}
