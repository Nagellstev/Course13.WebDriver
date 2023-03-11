using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTest
{
    public class WebPageControls
    {
        public IWebDriver driver;
        //public WebDriverWait wait;
        public WebPageControls(IWebDriver browser)
        {
            driver = browser;
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement LocateElement(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait.Until(x => x.FindElement(locator));
        }

        public void PressButton(By buttonLocator)
        {
            LocateElement(buttonLocator).Click();
        }

        public void FillingField(By fieldLocator, string data)
        {
            LocateElement(fieldLocator).SendKeys(data);
        }

        public void SubmitField(By fieldLocator)
        {
            LocateElement(fieldLocator).Submit();
        }

        public string GetText(By locator)
        {
            return LocateElement(locator).Text;
        }

        public string GetAttribute(By locator, string attribute)
        {
            return LocateElement(locator).GetAttribute(attribute);
        }
    }
}
