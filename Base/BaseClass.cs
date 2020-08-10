using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SeleniumExtras.PageObjects;

namespace Automation.Capsule.UI.Base
{
    public class BaseClass
    {
        private IWebDriver _driver;
        public string url = ConfigReader.GetUrl();
        public string username = ConfigReader.GetUsername();
        public string password = ConfigReader.GetPassword();
        public BasePage CurrentPage { get; set; }

        public void OpenBrowser(Browser.BrowserType browserType)
        {
            switch (browserType)
            {
                case Browser.BrowserType.Chrome:
                    DriverContext.WebDriver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.WebDriver);
                    break;
                case Browser.BrowserType.Firefox:
                    DriverContext.WebDriver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.WebDriver);
                    break;
                case Browser.BrowserType.MicrosoftEdge:
                    DriverContext.WebDriver = new EdgeDriver();
                    DriverContext.Browser = new Browser(DriverContext.WebDriver);
                    break;
            }
        }
        protected TPage GetInstance<TPage>() where TPage:BasePage, new()
        {
            TPage PageInstance = new TPage()
            {
                _driver = DriverContext.WebDriver
            };
            PageFactory.InitElements(DriverContext.WebDriver, PageInstance);
            return PageInstance;
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage) this;
        }
    }
}
