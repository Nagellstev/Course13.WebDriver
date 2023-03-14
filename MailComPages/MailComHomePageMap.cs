using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTest.MailComPages
{
    public class MailComHomePageMap
    {
        private readonly IWebDriver Driver;

        public WebPageLocator WebPage { get; set; }

        public string Frame
        {
            get
            {  
                return "home";
            }
        }

        public IWebElement EmailAddress
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//span[@class=\"username\"]"));
            }
        }

        public MailComHomePageMap(IWebDriver browser)
        {
            Driver = browser;
            WebPage = new WebPageLocator(browser);
        }

        public void SwitchToHomeFrame()
        {
            Driver.SwitchTo().Frame(Frame);
        }

        public void SwitchToDefaultContent()
        {
            Driver.SwitchTo().DefaultContent();
        }
    }
}
