using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTest.MailComPages
{
    public class MailComMyAccountPageMap
    {
        public IWebDriver Driver;

        public WebPageLocator WebPage { get; set; }

        //left panel controls
        public IWebElement MyAccount
        {
            get
            {
                //return WebPage.LocateElement(By.XPath("//*[@id=\"navigation\"]/ul/li[1]"));
                return WebPage.LocateElement(By.XPath("//li[@data-icon=\"my-account\"]"));
            }
        }
        public IWebElement PersonalData
        {
            get
            {
                //return WebPage.LocateElement(By.XPath("//*[@id=\"navigation\"]/ul/li[2]"));
                return WebPage.LocateElement(By.XPath("//li[@data-icon=\"personal-data\"]"));
            }
        }

        //frame
        public readonly string MyAccountFrame = "ciss";

        //my account content
        public IWebElement Name
        {
            get
            {
                //return WebPage.LocateElement(By.XPath("//*[@id=\"id24\"]/h1"));
                return WebPage.LocateElement(By.XPath("//*[@class=\"user-details__primary\"]"));
            }
        }
        public IWebElement Email
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//*[@class=\"user-details__secondary\"]"));
            }
        }

        //personal data content
        public IWebElement Profile
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//*[@id=\"main\"]//div[@class=\"content\"]/div[@class=\"links-menu a-mb-space-6\"]/div[1]"));
            }
        }

        //edit personal data content
        public IWebElement FirstNameField
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//input[contains(@id, \"firstName\")]"));
            }
        }
        public IWebElement LastNameField
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//input[contains(@id, \"lastName\")]"));
            }
        }
        public IWebElement PasswordField
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//input[contains(@id, \"password\")]"));
            }
        }
        public IWebElement SaveChangesButton
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//button[contains(@onclick, \"saveChanges\")]"));
            }
        }

        public MailComMyAccountPageMap(IWebDriver browser)
        {
            Driver = browser;
            WebPage = new WebPageLocator(browser);
        }

        public void SwitchToMyAccountFrame()
        {
            Driver.SwitchTo().Frame(MyAccountFrame);
        }
    }
}
