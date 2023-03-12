using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTest.MailComPages
{
    public class MailComHomePage
    {
        public IWebDriver driver;

        public WebPageControls webPageControls { get; set; }

        private By emailAddress = By.XPath("//span[@class=\"username\"]");
        private string frame = "home";

        public MailComHomePage(IWebDriver browser)
        {
            webPageControls = new WebPageControls(browser);
            driver = webPageControls.driver;
        }

        public void SwitchToFrame()
        {
            webPageControls.driver.SwitchTo().Frame(frame);
        }

        public string GetCurrentEmail()
        {
            return webPageControls.GetText(emailAddress);
        }
    }
}
