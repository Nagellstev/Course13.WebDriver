using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTest
{
    public class WebPageLocator
    {
        public IWebDriver Driver;
        public WebDriverWait Wait;
        public WebPageLocator(IWebDriver browser)
        {
            Driver = browser;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        public WebPageLocator(IWebDriver browser, double seconds)
        {
            Driver = browser;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
        }

        public IWebElement LocateElement(By locator)
        {
            return Wait.Until(x => x.FindElement(locator));
        }
    }
}
