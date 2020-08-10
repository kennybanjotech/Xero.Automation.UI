using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Capsule.UI.Base;
using Automation.Capsule.UI.WebElementObjects;
using Automation.Capsule.UI.WebElementObjects.Interfaces;
using Automation.Capsule.UI.WebElementObjects.WebElements;
using CapsuleCRMUI.WebElementObjects.WebElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace CapsuleCRMUI.GenericObjects
{
   public class GenericMobile:PageObjectBase

    {
        public GenericMobile( bool useWaitForAjax = true) : base(DriverContext.WebDriver, useWaitForAjax)
        {
        }

        [WebElementLocatorAttributes(LocatorTypeEnum.Id, "")]
        public MobileButton GenericButton;

        [WebElementLocatorAttributes(LocatorTypeEnum.Xpath, "")]
        public TextField GenericTextBox;

        public MobileButton GetMobileButtonById(string entityText)
        {
            GenericButton.ByLocator = MobileBy.Id(entityText);
            return GenericButton;
        }

        public TextField GetMobileTextBoxById(string entityText)
        {
            GenericTextBox.ByLocator = MobileBy.Id(entityText);
            return GenericTextBox;
        }

        public MobileButton GetMobileButtonByAccessibilityId(string entityText)
        {
            GenericButton.ByLocator = MobileBy.AccessibilityId(entityText);
            return GenericButton;
        }

        public TextField GetTextBoxByAccessibilityId(string id)
        {
            GenericTextBox.ByLocator = MobileBy.AccessibilityId(id);
            return GenericTextBox;
        }

        public TextField GetTextFieldByClassName(string className)
        {
            GenericTextBox.ByLocator = MobileBy.ClassName(className);
            return GenericTextBox;
        }

       
    }
}
