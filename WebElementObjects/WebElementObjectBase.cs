using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Capsule.UI.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;

namespace Automation.Capsule.UI.WebElementObjects
{
    public class WebElementObjectBase
    {
        WebDriverWait MobileWaitObject = new WebDriverWait(DriverContext.WebDriver, TimeSpan.FromSeconds(10));
        private WebDriverWait WaitObject => new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
        public By ByLocator { get; set; }
        public MobileBy MobileByLocator { get; set; }
        public string Locator { get; set; }

        public IWebDriver Driver { get; set; }
        public AndroidDriver<IWebElement> AndroidDriver { get; set; }
        public AndroidElement AndroidElement { get; set; }
        public AndroidDriver<AndroidElement> RootAndroidElement { get; set; }
        public IWebElement Element { get; set; }

        public string BindedDataAttribute { get; set; }

        public bool IsMandatory { get; set; }

        public string Url { get; set; }

        public string ViewModelBinding { get; set; }

        public bool UseWaitForAjax { get; set; }

        public IWebElement RootElement { get; set; }

        public bool ReturnIsMandatory()
        {
            return IsMandatory;
        }

        public string ReturnBindedDataAttribute()
        {
            return BindedDataAttribute;
        }

        public virtual IWebElement GetElement()
        {
            return GetElement(10);
        }

       
        public virtual IWebElement MobileGetElement()
        {
            return DriverContext.driver.FindElement(ByLocator);
        }
        public virtual IWebElement GetElement( int seconds)
        {
            
            try
            {
                if (UseWaitForAjax)
                {
                    Driver.WaitForAjax();
                }

                Element = RootElement != null
                    ? WaitObject.Until(d =>RootElement.FindElement(ByLocator))
                    : WaitObject.Until(d => d.FindElement(ByLocator));

                return Element;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
            catch (NoSuchWindowException)
            {
                return null;
            }

        }

        public void WaitForElement(IWebElement element)
        {
            //Presumably you would only wait for an element if you plan on interacting with it,
            //which would mean it needs to be enabled:
            if (IsDisplayed(ByLocator) && IsEnabled())
                return;
            WaitUntilElementIsDisplayed();
            if (!IsEnabled())
            {
                WaitUntilElementIsEnabled();
            }
        }

        public void WaitForElement()
        {
            WaitForElement(Element);
        }

        public bool IsDisplayed()
        {
            return IsDisplayed(ByLocator);
        }

        public bool IsDisplayed(By byLocator)
        {
            return WaitObject.Until(d =>
            {
                try
                {
                    return d.FindElement(byLocator).Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return d.FindElement(byLocator).Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });

        }

        public bool IsEnabled()
        {

            try
            {
                return GetElement().Enabled;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public  void MobileWaitUntilElementDisplayed()
        {
            MobileWaitObject.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ByLocator));
        }
        public void MobileWaitUntilElementClickable()
        {
            MobileWaitObject.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ByLocator));
        }
        public void WaitUntilElementIsDisplayed()
        {
            WaitObject.Until(ExpectedConditions.ElementIsVisible(ByLocator));
        }

        public void WaitUntilElementIsEnabled()
        {
            WaitObject.Until(ExpectedConditions.ElementToBeClickable(ByLocator));
        }
    }
}
