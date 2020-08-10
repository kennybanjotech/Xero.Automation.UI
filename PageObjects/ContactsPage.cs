using Automation.Capsule.UI.Base;
using Automation.Capsule.UI.GenericObjects;
using Automation.Capsule.UI.WebElementObjects;
using CapsuleCRMUI.TableEntities;
using CapsuleCRMUI.WebElementObjects.WebElements;
using SeleniumExtras.PageObjects;
using Should;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CapsuleCRMUI.PageObjects
{
    public class ContactsPage:BasePage
    {
        GenericPage GenericPage => new GenericPage();
       
        public void AddContact()
        {
            GenericPage.GetButtonByDataAutomationid("xrh-addon-quicklaunch-iconbutton").WaitUntilElementIsDisplayed();
            GenericPage.GetButtonByDataAutomationid("xrh-addon-quicklaunch-iconbutton").IsDisplayed().ShouldBeTrue("Button is not displayed");
            GenericPage.GetButtonByDataAutomationid("xrh-addon-quicklaunch-iconbutton").Click();
            GenericPage.GetButtonByDataName("addons-menu/quicklaunch/create-new/contact").IsDisplayed().ShouldBeTrue("Contact button is not displayed");
            GenericPage.GetButtonByDataName("addons-menu/quicklaunch/create-new/contact").Click();
        }

        public void EnterContactDetails(Table table)
        {
            var user = table.CreateInstance<Contacts>();
            GenericPage.GetTextFieldByID("Name").WaitUntilElementIsDisplayed();
            GenericPage.GetTextFieldByID("Name").IsDisplayed().ShouldBeTrue("Company name field not displayed");
            GenericPage.GetTextFieldByID("Name").EnterText(user.ContactName);
            GenericPage.GetTextFieldByID("FirstName").EnterText(user.FirstName);
            GenericPage.GetTextFieldByID("LastName").EnterText(user.LastName);
            GenericPage.GetTextFieldByID("EmailAddress").EnterText(user.Email);
            GenericPage.GetTextFieldByID("DefaultNumber").EnterText(user.PhoneNumber);
            GenericPage.GetButtonByDataAutomationid("Save-button").Click();
        }

        public void VerifyCompany(string element)
        {
            GenericPage.GetButtonByDataName("navigation-menu/contacts").Click();
            GenericPage.GetButtonByDataName("navigation-menu/contacts/all-contacts").Click();
            GenericPage.GetLabelByXpath(element).WaitUntilElementIsDisplayed();
            GenericPage.GetLabelByXpath(element).IsDisplayed().ShouldBeTrue($"{element} is not displayed");
        }
    }
}