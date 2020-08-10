using System;
using System.Threading;
using Automation.Capsule.UI.Base;
using CapsuleCRMUI.GenericObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using TechTalk.SpecFlow;

namespace Xero.Automation.UI.StepDefinitions
{
    [Binding]
    public class XeroLoginSteps
    {
        private GenericMobile GenericMobile => new GenericMobile();

        [When(@"I click the '(.*)' mobile button")]
        public void WhenIClickTheMobileButton(string buttonName)
        {
            GenericMobile.GetMobileButtonById(buttonName).MobileClick();
        }


        [When(@"I enter '(.*)' as the '(.*)'")]
        public void WhenIEnterAsThe(string username, string textField)
        { 
            GenericMobile.GetTextBoxByAccessibilityId(textField).MobileWaitUntilElementDisplayed();
            GenericMobile.GetTextBoxByAccessibilityId(textField).MobileEnterText(username);
        }
    }
}
