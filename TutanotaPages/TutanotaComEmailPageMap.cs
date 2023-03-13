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

        //left panel controls
        private string LeftPanelXPath = "div[@id=\"mail\"]/div/div[class=\"view-columns flex-grow rel\"]/div[@class=\"view-column overflow-x-hidden fill-absolute list-border-right\"]/div/div";
        //public IWebElement LeftPanel
        //{
        //    get
        //    {
        //        return WebPage.LocateElement(By.XPath("//div[@id=\"mail\"]/div/div[class=\"view-columns flex-grow rel\"]/div[@class=\"view-column overflow-x-hidden fill-absolute list-border-right\"]/div/div"));
        //    }
        //}
        public IWebElement NewLetterButton
        {
            get
            {
                //return LeftPanel.FindElement(By.XPath("//div[@class=\"plr-button-double mt mb\"]/button"));
                //return WebPage.LocateElement(By.XPath("//div[@id=\"mail\"]/div/div[class=\"view-columns flex-grow rel\"]/div[@class=\"view-column overflow-x-hidden fill-absolute list-border-right\"]/div/div/div[@class=\"plr-button-double mt mb\"]/button"));
                //return WebPage.LocateElement(By.XPath($"//{LeftPanelXPath}/div[@class=\"plr-button-double mt mb\"]/button"));
                return WebPage.LocateElement(By.XPath($"//div[@class=\"plr-button-double mt mb\"]/button"));
            }
        }
        public IWebElement EmailAddress
        {
            get
            {
                //return LeftPanel.FindElement(By.XPath("//div[@class=\"scroll overflow-x-hidden flex col flex-grow\"]/div[@class=\"sidebar-section mb\"]/div/small"));
                return WebPage.LocateElement(By.XPath("//div[@class=\"sidebar-section mb\"]/div/small"));
                //return WebPage.LocateElement(By.XPath($"//{LeftPanelXPath}/div[@class=\"scroll overflow-x-hidden flex col flex-grow\"]/div[@class=\"sidebar-section mb\"]/div/small"));
            }
        }
        public IWebElement IncomingButton
        {
            get
            {
                //return LeftPanel.FindElement(By.XPath("//div[@class=\"scroll overflow-x-hidden flex col flex-grow\"]/div[@class=\"sidebar-section mb\"]/div[2]"));
                //return WebPage.LocateElement(By.XPath($"//{LeftPanelXPath}/div[@class=\"scroll overflow-x-hidden flex col flex-grow\"]/div[@class=\"sidebar-section mb\"]/div[2]"));
                return WebPage.LocateElement(By.XPath("//div[@class=\"sidebar-section mb\"]/div[2]"));
            }
        }
        public IWebElement SentButton
        {
            get
            {
                //return LeftPanel.FindElement(By.XPath("//div[@class=\"scroll overflow-x-hidden flex col flex-grow\"]/div[@class=\"sidebar-section mb\"]/div[4]"));
                return WebPage.LocateElement(By.XPath("//div[@class=\"sidebar-section mb\"]/div[4]"));
                //return WebPage.LocateElement(By.XPath($"//{LeftPanelXPath}/div[@class=\"scroll overflow-x-hidden flex col flex-grow\"]/div[@class=\"sidebar-section mb\"]/div[4]"));
            }
        }

        //letters storage
        //private string LetterStorageXPath = "div[@id=\"mail\"]/div/div[class=\"view-columns flex-grow rel\"]/div[@role=\"main\"]/div/div/div/div[@class=\"rel flex-grow\"]/div/ul";
        private string LetterStorageXPath = "div[@class=\"rel flex-grow\"]/div/ul";
        public IWebElement LastLetter
        {
            get
            {
                return WebPage.LocateElement(By.XPath($"//{LetterStorageXPath}/li[1]"));
            }
        }

        //letter reader
        private string LetterReaderXPath = "div[@id=\"mail\"]/div/div[class=\"view-columns flex-grow rel\"]/div[@role=\"main\"]/div/div/div/div[@class=\"rel flex-grow\"]/div/ul";
        public IWebElement LetterSubject
        {
            get
            {
                return WebPage.LocateElement(By.XPath($"//div[@class=\"mail\"]/div/div[@class=\"fill-absolute scroll\"]/div[1]"));
            }
        }
        public IWebElement LetterTo
        {
            get
            {
                //return WebPage.LocateElement(By.XPath($"//div[@class=\"mail\"]/div/div[@class=\"fill-absolute scroll\"]/div[2]/div[@class=\"header mlr-safe-inset\"]/div[2]/div[2]/div[1]/div[2]"));
                return WebPage.LocateElement(By.XPath($"//div[@class=\"header mlr-safe-inset\"]/div[2]/div[2]/div[1]/div[2]"));
            }
        }
        public IWebElement LetterFrom
        {
            get
            {
                return WebPage.LocateElement(By.XPath($"//div[@class=\"small flex flex-wrap items-start\"]/span[@class=\"text-break\"]"));
                //return WebPage.LocateElement(By.XPath($"//div[@class=\"header mlr-safe-inset\"]/div[2]/div[@class=\"small flex flex-wrap items-start\"]/span"));
                //return WebPage.LocateElement(By.XPath($"//div[@class=\"header mlr-safe-inset\"]/div[2]/div[@class=\"flex\"]/div/div[@class=class=\"text-ellipsis\"]"));
            }
        }
        //public IWebElement SentLetterFrom
        //{
        //    get
        //    {
        //        //return WebPage.LocateElement(By.XPath($"//div[@class=\"mail\"]/div/div[@class=\"fill-absolute scroll\"]/div[2]/div[@class=\"header mlr-safe-inset\"]/div[2]/div/span"));
        //        return WebPage.LocateElement(By.XPath($"//div[@class=\"header mlr-safe-inset\"]/div[2]/div[@class=\"flex\"]/div/div[@class=class=\"text-ellipsis\"]"));
        //    }
        //}
        public IWebElement ReplyButton
        {
            get
            {
                //return WebPage.LocateElement(By.XPath($"//div[@class=\"mail\"]/div/div[@class=\"fill-absolute scroll\"]/div[2]/div[@class=\"header mlr-safe-inset\"]/div[1]/div/button[1]"));
                return WebPage.LocateElement(By.XPath($"//div[@class=\"flex-end items-center ml-between-s mt-xs\"]/button[1]"));
            }
        }
        public IWebElement LetterText
        {
            get
            {
                //return WebPage.LocateElement(By.XPath($"//div[@class=\"mail\"]/div/div[@class=\"fill-absolute scroll\"]/div[2]/div[@class=\"flex-grow mlr-safe-inset scroll-x pt pb border-radius-big  plr-l\"]/div[@id=\"mail-body\"]"));
                return WebPage.LocateElement(By.Id("mail-body"));
            }
        }

        //new email controls
        public IWebElement ToField
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//div[@id=\"mail-editor\"]/div[@class=\"rel\"]/div/div/div/div/div/div[@class=\"flex-grow rel\"]/input"));
                //return WebPage.LocateElement(By.XPath("//div[@id=\"mail-editor\"]/div[1]/div/div/div"));
            }
        }
        public IWebElement SubjectField
        {
            get
            {
                // WebPage.LocateElement(By.XPath("//div[@id=\"mail-editor\"]/div[@class=\"row\"]/div/div/div/div/div[@class=\"flex-grow rel\"]/input"));
                return WebPage.LocateElement(By.XPath("//div[@id=\"mail-editor\"]/div[@class=\"row\"]/div/div/div/div/div[@class=\"flex-grow rel\"]/input"));
            }
        }
        public IWebElement ConfidentialButton
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//div[@id=\"mail-editor\"]/div[@class=\"row\"]/div/div/div/div/div[@class=\"flex-end items-center\"]/div/button[1]"));
            }
        }
        public IWebElement TextEditorField
        {
            get
            {
                //return WebPage.LocateElement(By.XPath("//div[@id=\"mail-editor\"]/div/div[@role=\"textbox\"]/div/br"));
                //return WebPage.LocateElement(By.XPath("//div[@id=\"mail-editor\"]/div[@class=\"pt-s text scroll-x break-word-links flex flex-column flex-grow\"/div[@role=\"textbox\"]"));
                return WebPage.LocateElement(By.XPath("//div[@id=\"mail-editor\"]/div/div[@role=\"textbox\"]"));
            }
        }
        public IWebElement SendButton
        {
            get
            {
                return WebPage.LocateElement(By.XPath("//div[@class=\"button-content flex items-center primary plr-button justify-center\"]"));
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
