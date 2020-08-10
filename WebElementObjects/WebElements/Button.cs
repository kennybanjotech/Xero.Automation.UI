using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Capsule.UI.Interfaces;
using OpenQA.Selenium.Interactions;

namespace Automation.Capsule.UI.WebElementObjects.WebElements
{
    public class Button: WebElementObjectBase, IClickable
    {
        public void Click()
        {
            //WaitForElement();
            var actions = new Actions(Driver);
            actions.MoveToElement(GetElement()).Click().Perform();
        }

        public new string GetType()
        {
            return GetElement().GetAttribute("type");
        }

        public string GetText()
        {
            return GetElement().Text;
        }

        public void RightClick()
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(GetElement());
            actions.ContextClick(GetElement()).Build().Perform();
        }
    }
}
