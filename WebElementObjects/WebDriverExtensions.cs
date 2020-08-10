using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Automation.Capsule.UI.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Automation.Capsule.UI.WebElementObjects
{
     static class WebDriverExtensions
    {
        public static void WaitForAjax(this IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var jsExecutor = driver as IJavaScriptExecutor;
            wait.Until(d => (bool)jsExecutor.ExecuteScript("return (jQuery != 'undefined') ? jQuery.active == 0)" + ""));
        }
        public static void Wait(this IWebDriver driver, int durationMs)
        {
            Thread.Sleep(durationMs);
        }

        
    }
}
