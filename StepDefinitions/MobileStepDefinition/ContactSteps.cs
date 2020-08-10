using System;
using System.Configuration;
using CapsuleCRMUI.GenericObjects;
using CapsuleCRMUI.TableEntities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Xero.Automation.UI.StepDefinitions.MobileStepDefinition
{
    [Binding]
    public class ContactSteps
    {
        private GenericMobile GenericMobile => new GenericMobile();

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            GenericMobile.GetMobileButtonById("login_start_button").MobileClick();
            GenericMobile.GetTextBoxByAccessibilityId("Email address").MobileWaitUntilElementDisplayed();
            GenericMobile.GetTextBoxByAccessibilityId("Email address").MobileEnterText(ConfigurationManager.AppSettings["Username"]);
            GenericMobile.GetTextBoxByAccessibilityId("Password").MobileEnterText(ConfigurationManager.AppSettings["Password"]);
            GenericMobile.GetMobileButtonById("xa_login_button").MobileClick();
            GenericMobile.GetMobileButtonById("xa_other_options_button").MobileWaitUntilElementClickable();
            GenericMobile.GetMobileButtonById("xa_other_options_button").MobileClick();
            GenericMobile.GetMobileButtonById("btn_use_password").MobileWaitUntilElementClickable();
            GenericMobile.GetMobileButtonById("btn_use_password").MobileClick();
        }

        [When(@"I add a new contact")]
        public void WhenIAddANewContact(Table table)
        {
            GenericMobile.GetMobileButtonByAccessibilityId("Add").MobileWaitUntilElementClickable();
            GenericMobile.GetMobileButtonByAccessibilityId("Add").Click();

            var user = table.CreateInstance<Contacts>();

        }
        
        [When(@"I enter the folllowing details")]
        public void WhenIEnterTheFolllowingDetails(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the contact '(.*)' should be displayed")]
        public void ThenTheContactShouldBeDisplayed(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
