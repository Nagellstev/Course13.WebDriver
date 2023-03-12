using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTest.MailComPages
{
    public class MailComLoginErrorPage
    {
        public IWebDriver driver;

        public WebPageControls webPageControls { get; set; }

        private By errorMessageHeader = By.XPath("//div[@class=\"text-wrapper\"]/h1");

        public MailComLoginErrorPage(IWebDriver browser)
        {
            webPageControls = new WebPageControls(browser);
            driver = webPageControls.driver;
        }

        public void SwitchToFrame()
        {
            webPageControls.driver.SwitchTo().DefaultContent();
        }

        public string ErrorMessageHeader()
        {
            return webPageControls.GetText(errorMessageHeader);
        }
    }
}
