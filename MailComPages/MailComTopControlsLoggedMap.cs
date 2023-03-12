using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTest.MailComPages
{
    public class MailComTopControlsLoggedMap
    {
        public IWebDriver Driver;

        public WebPageLocator WebPage { get; set; }

        public IWebElement HomeButton
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//*[@id=\"actions-menu-primary\"]/a[@aria-label=\"Home\"]"));
            }
        }
        public IWebElement EmailButton
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//*[@id=\"actions-menu-primary\"]/a[@aria-label=\"E-mail\"]"));
            }
        }
        public IWebElement MoreButton
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//*[@id=\"actions-menu-primary\"]/a[@aria-label=\"More\"]"));
            }
        }

        public MailComTopControlsLoggedMap(IWebDriver browser)
        {
            Driver = browser;
            WebPage = new WebPageLocator(browser);
        }

        /*
        public void SwitchToFrame()
        {
            webPageControls.driver.SwitchTo().DefaultContent();
        }

        public void HomeButtonPress()
        {
            webPageControls.PressButton(homeButtonLocator);
        }

        public void EmailButtonPress()
        {
            webPageControls.PressButton(emailButtonLocator);
        }

        public void MoreButtonPress()
        {
            webPageControls.PressButton(moreButtonLocator);
        }
        */
    }
}
