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

        public MailComMyAccountPageMap(IWebDriver browser)
        {
            Driver = browser;
            WebPage = new WebPageLocator(browser);
        }
    }
}
