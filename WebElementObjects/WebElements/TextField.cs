using System;
using Automation.Capsule.UI.WebElementObjects;
using Automation.Capsule.UI.WebElementObjects.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Automation.Capsule.UI.WebElementObjects.Interfaces
{
    public class TextField : WebElementObjectBase, ITypable
    {
        public void EnterText(string text)
        {
            GetElement().SendKeys(text);
        }
        public void MobileEnterText(string text)
        {
            MobileGetElement().SendKeys(text);
        }
        public void Click()
        {
            WaitForElement();
            var actions = new Actions(Driver);
            actions.MoveToElement(GetElement()).Click();
        }
        public string GetText()
        {
            throw new NotImplementedException();
        }

        public void Enter()
        {
            EnterText(Keys.Enter);
        }

        public void ClearText()
        {
            GetElement().Clear();
        }

        public void MobileClearText()
        {
            MobileGetElement().Clear();
        }
    }
}