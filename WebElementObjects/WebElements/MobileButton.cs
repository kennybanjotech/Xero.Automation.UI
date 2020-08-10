using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Capsule.UI.Interfaces;
using Automation.Capsule.UI.WebElementObjects;
using OpenQA.Selenium;

namespace CapsuleCRMUI.WebElementObjects.WebElements
{
    public class MobileButton:WebElementObjectBase, IClickable
    {
        
        public void Click()
        {
            
            GetElement().Click();
        }

        public void MobileClick()
        {
            
            MobileGetElement().Click();
        }
        //public override string GetText()
        //{
        //    return GetElement().Text;
        //}
    }
}
