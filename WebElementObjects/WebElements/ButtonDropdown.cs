using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Capsule.UI.WebElementObjects;
using Automation.Capsule.UI.WebElementObjects.Interfaces;
using OpenQA.Selenium;

namespace Automation.Capsule.UI.WebElementObjects.WebElements
{
   public class ButtonDropdown:WebElementObjectBase, IDropdown
    {
        public void Select(string itemToSelect)
        {
            var dropdownItem = GetElement().FindElement(By.CssSelector($"{itemToSelect}"));
            dropdownItem.Click();
        }
    }
}
