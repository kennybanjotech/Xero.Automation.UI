using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Automation.Capsule.UI.WebElementObjects;
using Automation.Capsule.UI.WebElementObjects.Interfaces;
using Automation.Capsule.UI.WebElementObjects.WebElements;
using Automation.Capsule.UI.Base;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Label = Automation.Capsule.UI.WebElementObjects.WebElements.Label;

namespace Automation.Capsule.UI.GenericObjects
{
    public class GenericPage:PageObjectBase
    {
        public GenericPage(bool useWaitForAjax = true) : base(DriverContext.WebDriver, useWaitForAjax)
        {
        }
        [WebElementLocatorAttributes(LocatorTypeEnum.Id, "")]
        public Button GenericMainWindowButton;

        [WebElementLocatorAttributes(LocatorTypeEnum.Id, "")]
        public TextField GenericTextfield;

        [WebElementLocatorAttributes(LocatorTypeEnum.Xpath, "")]
        public Label GenericLabel;

        [WebElementLocatorAttributes(LocatorTypeEnum.Id, "")]
        public ButtonDropdown GenericDropDown;
        public Button GetButtonByID(string entityName)
        {
            GenericMainWindowButton.ByLocator = By.Id($"{entityName}");
            return GenericMainWindowButton;
        }

        public Button GetButtonByDataTestId(string buttonName)
        {
            GenericMainWindowButton.ByLocator = By.CssSelector($"[data-test-id= '{buttonName}'], #{buttonName}");
            return GenericMainWindowButton;
        }

        public TextField GetTextFieldByID(string textfield)
        {
            GenericTextfield.ByLocator = By.Id($"{textfield}");
            return GenericTextfield;
        }

        public Button GetButtonByDataAutomationid(string buttonName)
        {
            GenericMainWindowButton.ByLocator = By.CssSelector($"[data-automationid = '{buttonName}']");
            return GenericMainWindowButton;
        }

        public Button GetButtonByDataName(string elementName)
        {
            GenericMainWindowButton.ByLocator = By.CssSelector($"[data-name = '{elementName}']");
            return GenericMainWindowButton;
        }

        public Label GetLabelByDataAutomationId(string elementName)
        {
            GenericLabel.ByLocator = By.CssSelector($"[data-automationid = '{elementName}']," +
                                                    $"[title = '{elementName}']");
            return GenericLabel;
        }

        public Label GetLabelByXpath(string element)
        {
            GenericLabel.ByLocator = By.XPath($"//a[text()='{element}']");
            return GenericLabel;
        }

        public ButtonDropdown GetDropdownById(string itemToSelect)
        {
            GenericDropDown.ByLocator = By.Id($"{itemToSelect}");
            return GenericDropDown;
        }
        
    }
}
