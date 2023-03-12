using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTest.TutanotaPages
{
    public class TutanotaComEmailPageMap
    {
        #region Declarations

        public IWebDriver Driver;

        public WebPageLocator WebPage { get; set; }

        public IWebElement EmailAddress
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//div[@class=\"sidebar-section mb\"]/div/small"));
            }
        }

        #endregion

        public TutanotaComEmailPageMap(IWebDriver browser)
        {
            Driver = browser;
            WebPage = new WebPageLocator(browser);
        }
    }
}
