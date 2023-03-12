using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTest.MailComPages
{
    public class MailComEmailPageMap
    {
        public IWebDriver Driver;

        public WebPageLocator WebPage { get; set; }

        public string Frame
        {
            get
            {
                return "home";
            }
        }

        //left bar controls
        public IWebElement ComposeEmailButton
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//div[@id=\"section-0\"]/div[@class=\"navigation-container-top\"]"));
            }
        }
        public IWebElement InboxButton
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//div[@id=\"section-0\"]/div[@class=\"navigation-container-top\"]"));
            }
        }
        public IWebElement SentButton
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//div[@class=\"panel-body\"]/ul/li[@data-webdriver=\"SENT\"]"));
            }
        }

        //letter storage controls
        public IWebElement LastLetter
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//table[@id=\"mail-list\"]/tbody/tr/td[@class=\"last\"]"));
            }
        }
        public IWebElement LetterSubject
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//div[@id=\"mail-head\"]/div/div[@class=\"mail-head-area mail-head-data icon-count-0\"]/dl/dd/span"));
            }
        }
        public IWebElement LetterFrom
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//div[@id=\"mail-details\"]/div/ul/li/div/dl[@class=\"mail-sender form-objc\"]/dd/a"));
            }
        }
        public IWebElement LetterTo
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//div[@id=\"mail-details\"]/div/ul/li/div/dl[@class=\"mail-recipient form-objc\"]/dd/a"));
            }
        }
        public IWebElement LetterText
        {
            get
            {
                //switch to "mail-display-content" frame before using this element
                return WebPage.LocateElement(By.XPath("//html/body/div/div"));
            }
        }

        //compose email controls
        public IWebElement ToField
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//div[@class=\"form-element-multiobjecttextfield js-component\"]/div[@class=\"select2-container select2-container-multi js-select2\"]/ul[@class=\"select2-choices\"]/li[@class=\"select2-search-field\"]/input[@type=\"text\"]"));
            }
        }
        public IWebElement SubjectField
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//div[@class=\"compose-header_item compose-header_subject mailobjectpanel-textfield js-component mailobjectpanel\"]/div[@class=\"mailobjectpanel_content\"]/input[@type=\"text\"]"));
            }
        }
        public IWebElement TextEditorFrame
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//div[@id=\"cke_1_contents\"]/iframe"));
            }
        }
        public IWebElement TextEditorField
        {
            get
            {
                //switch to TextEditorFrame before using this element
                return WebPage.LocateElement(By.XPath("//html/body/div/br"));
            }
        }
        public IWebElement SendButton
        {
            get
            {
                return WebPage.LocateElement(By.Id("compose-send-button"));
            }
        }
        public IWebElement CloseSucsessMessage
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//div[@id=\"system-message\"]/div[@class=\"system-message is-success\"]/a[@data-webdriver=\"closeLink\"]"));
            }
        }


        public MailComEmailPageMap(IWebDriver browser)
        {
            Driver = browser;
            WebPage = new WebPageLocator(browser);
            //driver = webPageControls.driver;
        }

        public void NewLetterTextInput(string text)
        {
            Driver.SwitchTo().Frame(TextEditorFrame);
            TextEditorField.SendKeys(text);
            Driver.SwitchTo().ParentFrame();
        }

        public string EmailTextRead()
        {
            Driver.SwitchTo().Frame("mail-display-content");
            string result = LetterText.Text;
            Driver.SwitchTo().ParentFrame();
            return result;
        }
        /*
        public string FromCheck()
        {
            return webPageControls.GetAttribute(letterFrom, "title");
        }

        public string ToCheck()
        {
            return webPageControls.GetAttribute(letterTo, "title");
        }
        */
        //Sending e-mail scenario
        public void SendEmail(string to, string subject, string text)
        {
            WebPage.Driver.SwitchTo().Frame(Frame);
            ComposeEmailButton.Click();
            ToField.SendKeys(to);
            SubjectField.SendKeys(subject);

            //text field is settled in the separate iframe. switch to this frame
            Driver.SwitchTo().Frame(TextEditorFrame);
            TextEditorField.SendKeys(text);

            //switch to parent frame to press "send" button
            Driver.SwitchTo().ParentFrame();
            SendButton.Click();
        }
    }
}
