using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Automation.Capsule.UI.WebElementObjects.Interfaces;

namespace Automation.Capsule.UI.WebElementObjects.WebElements
{
    public class Label:WebElementObjectBase, IReadable
    {
        public string GetValue()
        {
            Element = GetElement();
            IsDisplayed();
            return Element.GetAttribute("value");
        }

       
    }
}
