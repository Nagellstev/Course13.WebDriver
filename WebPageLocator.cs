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
        private IWebDriver driver;
        private WebDriverWait wait;
        public WebPageLocator(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        public WebPageLocator(IWebDriver browser, double seconds)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
        }

        public IWebElement LocateElement(By locator)
        {
            return wait.Until(x => x.FindElement(locator));
        }
    }
}
