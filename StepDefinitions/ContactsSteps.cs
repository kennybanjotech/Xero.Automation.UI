using System;
using Automation.Capsule.UI.Base;
using Automation.Capsule.UI.GenericObjects;
using Automation.Capsule.UI.PageObjects;
using CapsuleCRMUI.PageObjects;
using CapsuleCRMUI.TableEntities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xero.Automation.UI.PageObjects;

namespace CapsuleCRMUI.StepDefinitions
{
    [Binding]
    public class ContactsSteps:BasePage
    {
        private GenericPage GenericPage => new GenericPage();
        [Given(@"I login as a system administrator")]
        public void GivenILoginAsASystemAdministrator()
        {
            CurrentPage = GetInstance<LoginPage>();
            CurrentPage.As<LoginPage>().SystemAdministratorLogin(ConfigReader.GetUsername(), ConfigReader.GetPassword());
        }
        
        [When(@"I go to '(.*)' from the nav bar")]
        public void WhenIGoToFromTheNavBar(string buttonName)
        {
            CurrentPage = GetInstance<HomePage>();
            CurrentPage.As<HomePage>().ClickNavBarButton(buttonName);
        }
        
        [When(@"I create a new contact")]
        public void WhenICreateANewContact()
        {
            CurrentPage = GetInstance<ContactsPage>();
            CurrentPage.As<ContactsPage>().AddContact();
        }
        
        [When(@"I add the following details")]
        public void WhenIAddTheFollowingDetails(Table table)
        {
            CurrentPage = GetInstance<ContactsPage>();
            CurrentPage.As<ContactsPage>().EnterContactDetails(table);
        }
        
        [Then(@"the company '(.*)' should be displayed")]
        public void ThenThePersonShouldBeDisplayed(string element)
        {
            CurrentPage = GetInstance<ContactsPage>();
            CurrentPage.As<ContactsPage>().VerifyCompany(element);
        }
    }
}
