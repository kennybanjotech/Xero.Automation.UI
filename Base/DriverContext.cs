using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Automation.Capsule.UI.Base
{
    public class DriverContext
    {
        private static IWebDriver _driver;
        public static IWebDriver DynamicDriver()
        {
            switch (ConfigReader.Platform)
            {
                case "Android":
                    return driver;
                default:
                    return WebDriver;

            }
        }


        public static IWebDriver WebDriver { get; set; }
        public static Browser Browser { get; set; }

        public static AndroidDriver<IWebElement> driver { get; set; }

        public static AndroidDriver<IWebElement> GetAndroidDriver()
        {
            var capability = new AppiumOptions();
            capability.AddAdditionalCapability("deviceName", ConfigReader.DeviceName);
            capability.AddAdditionalCapability("platformName", ConfigReader.Platform);
            capability.AddAdditionalCapability("appPackage", ConfigReader.AppPackage);
            capability.AddAdditionalCapability("appActivity", ConfigReader.AppActivity);

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"),capability);
            return driver;
        }


    }

}
