using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTest.MailComPages
{
    public class MailComTopControlsLogged
    {
        public IWebDriver driver;

        public WebPageControls webPageControls { get; set; }

        private By homeButtonLocator = By.XPath("//*[@id=\"actions-menu-primary\"]/a[@aria-label=\"Home\"]");
        private By emailButtonLocator = By.XPath("//*[@id=\"actions-menu-primary\"]/a[@aria-label=\"E-mail\"]");
        private By moreButtonLocator = By.XPath("//*[@id=\"actions-menu-primary\"]/a[@aria-label=\"More\"]");

        public MailComTopControlsLogged(IWebDriver browser)
        {
            webPageControls = new WebPageControls(browser);
            driver = webPageControls.driver;
        }

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
    }
}
