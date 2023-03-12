using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTest.MailComPages
{
    public class MailComLoginErrorPageMap
    {
        public IWebDriver Driver;

        public WebPageLocator WebPage { get; set; }

        public IWebElement ErrorMessageHeader
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//div[@class=\"text-wrapper\"]/h1"));
            }
        }

        public MailComLoginErrorPageMap(IWebDriver browser)
        {
            Driver = browser;
            WebPage = new WebPageLocator(browser);
        }
 
        /*
        public void SwitchToFrame()
        {
            webPageControls.driver.SwitchTo().DefaultContent();
        }

        public string ErrorMessageHeader()
        {
            return webPageControls.GetText(errorMessageHeader);
        }
        */
    }
}
