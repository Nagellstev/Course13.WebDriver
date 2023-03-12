using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTest.MailComPages
{
    public class MailComEmailPage
    {
        public IWebDriver driver;

        public WebPageControls webPageControls { get; set; }

        private string frame = "mail";
        private By composeEmailButton = By.XPath("//div[@id=\"section-0\"]/div[@class=\"navigation-container-top\"]");
        private By inboxButton = By.XPath("//div[@class=\"navigation\"]/ul/li[@data-webdriver=\"INBOX\"]");
        private By sentButton = By.XPath("//div[@class=\"panel-body\"]/ul/li[@data-webdriver=\"SENT\"]");
        private By toField = By.XPath("//div[@class=\"form-element-multiobjecttextfield js-component\"]/div[@class=\"select2-container select2-container-multi js-select2\"]/ul[@class=\"select2-choices\"]/li[@class=\"select2-search-field\"]/input[@type=\"text\"]");
        private By subjectField = By.XPath("//div[@class=\"compose-header_item compose-header_subject mailobjectpanel-textfield js-component mailobjectpanel\"]/div[@class=\"mailobjectpanel_content\"]/input[@type=\"text\"]");
        private By textEditorFrame = By.XPath("//div[@id=\"cke_1_contents\"]/iframe");
        private By textEditorInput = By.XPath("//html/body/div/br");
        private By sendButton = By.Id("compose-send-button");
        private By closeSucsess = By.XPath("//div[@id=\"system-message\"]/div[@class=\"system-message is-success\"]/a[@data-webdriver=\"closeLink\"]");
        private By lastLetter = By.XPath("//table[@id=\"mail-list\"]/tbody/tr/td[@class=\"last\"]");
        private By letterSubject = By.XPath("//div[@id=\"mail-head\"]/div/div[@class=\"mail-head-area mail-head-data icon-count-0\"]/dl/dd/span");
        private By letterFrom = By.XPath("//div[@id=\"mail-details\"]/div/ul/li/div/dl[@class=\"mail-sender form-objc\"]/dd/a");
        private By letterTo = By.XPath("//div[@id=\"mail-details\"]/div/ul/li/div/dl[@class=\"mail-recipient form-objc\"]/dd/a");

        public MailComEmailPage(IWebDriver browser)
        {
            webPageControls = new WebPageControls(browser);
            driver = webPageControls.driver;
        }

        public IWebElement LetterSubject()
        {
            By letterSubject = By.XPath("//div[@id=\"mail-head\"]/div/div[@class=\"mail-head-area mail-head-data icon-count-0\"]/dl/dd/span");
            return webPageControls.LocateElement(letterSubject);
        }

        public void SwitchToFrame()
        {
            webPageControls.driver.SwitchTo().Frame(frame);
        }

        public void ComposeEmailButtonClick()
        {
            webPageControls.PressButton(composeEmailButton);
        }

        public void ToInput(string to)
        {
            webPageControls.FillingField(toField, to);
        }

        public void SubjectInput(string subject)
        {
            webPageControls.FillingField(subjectField, subject);
        }

        public void TextInput(string text)
        {
            driver.SwitchTo().Frame(driver.FindElement(textEditorFrame));
            webPageControls.FillingField(textEditorInput, text);
            driver.SwitchTo().ParentFrame();
        }

        public void SendClick()
        {
            webPageControls.PressButton(sendButton);
        }

        public void CloseSucsessMessage()
        {
            webPageControls.PressButton(closeSucsess);
        }

        public void InboxClick()
        {
            webPageControls.PressButton(inboxButton);
        }

        public void SentClick()
        {
            webPageControls.PressButton(sentButton);
        }

        public void LastLetterClick()
        {
            webPageControls.PressButton(lastLetter);
        }

        public string EmailText()
        {
            driver.SwitchTo().Frame("mail-display-content");
            string result = webPageControls.GetText(By.XPath("//html/body/div/div"));
            driver.SwitchTo().ParentFrame();
            return result;
        }

        public string FromCheck()
        {
            return webPageControls.GetAttribute(letterFrom, "title");
        }

        public string ToCheck()
        {
            return webPageControls.GetAttribute(letterTo, "title");
        }

        //Sending e-mail scenario
        public void SendEmail(string to, string subject, string text)
        {
            webPageControls.driver.SwitchTo().Frame(frame);
            webPageControls.PressButton(composeEmailButton);
            webPageControls.FillingField(toField, to);
            webPageControls.FillingField(subjectField, subject);

            //text field is settled in the separate iframe. switch to this frame
            driver.SwitchTo().Frame(driver.FindElement(textEditorFrame));
            webPageControls.FillingField(textEditorInput, text);

            //switch to parent frame to press "send" button
            driver.SwitchTo().ParentFrame();
            webPageControls.PressButton(sendButton);
        }
    }
}
