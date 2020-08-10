using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Capsule.UI.WebElementObjects;
using Automation.Capsule.UI.WebElementObjects.Interfaces;
using OpenQA.Selenium.Support.UI;

namespace CapsuleCRMUI.WebElementObjects.WebElements
{
    public class DropDownBox:WebElementObjectBase, IDropdown
    {
        public void Select(string stateToChoose)
        {
            var dropdown = new SelectElement(GetElement());
            dropdown.SelectByText(stateToChoose);
        }

        public void SelectByValue(string stateToChoose)
        {
            var dropdown = new SelectElement(GetElement());
            dropdown.SelectByValue(stateToChoose);
        }
    }
}
