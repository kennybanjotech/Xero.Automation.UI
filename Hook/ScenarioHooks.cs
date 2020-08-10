using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Automation.Capsule.UI.Base;
using Automation.Capsule.UI.WebElementObjects;
using LogManager.Interfaces;
using log4net;
using log4net.Core;
using TechTalk.SpecFlow;
using ILog = log4net.ILog;

namespace CapsuleCRMUI.Hook
{
    [Binding]
    public class ScenarioHooks:BaseClass
    {
        [BeforeScenario(@"WebApplication")]
        public void StartBrowser()
        {
            OpenBrowser(Browser.BrowserType.Firefox);
            DriverContext.WebDriver.Manage().Window.Maximize();
            DriverContext.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [AfterScenario(@"WebApplication")]
        public void CloseBrowser()
        {
            DriverContext.WebDriver.Wait(5000);
            DriverContext.WebDriver.Quit();
        }

        [BeforeScenario(@"mobileautomation")]
        public void LaunchMobileApp()
        {
            DriverContext.GetAndroidDriver();
        }


    }
}
