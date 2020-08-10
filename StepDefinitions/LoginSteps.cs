using System;
using Automation.Capsule.UI.Base;
using Automation.Capsule.UI.GenericObjects;
using Automation.Capsule.UI.PageObjects;
using CapsuleCRMUI.GenericObjects;
using TechTalk.SpecFlow;
using Xero.Automation.UI.PageObjects;

namespace Xero.Automation.UI.StepDefinitions
{
    [Binding]
    public class LoginSteps:BasePage
    {
        private GenericPage GenericPage => new GenericPage();
        //GenericMobile GenericMobile = new GenericMobile();

        [Given(@"I navigate to the application Url")]
        public void GivenINavigateToTheApplicationUrl()
        {
           // OpenBrowser(Browser.BrowserType.Chrome);
            CurrentPage = GetInstance<LoginPage>();
            CurrentPage.As<LoginPage>().GoToLoginPage();
        }


        [When(@"I enter the '(.*)' as '(.*)'")]
        public void WhenIEnterTheAsAnd(string textfield, string credential)
        {
            CurrentPage = GetInstance<LoginPage>();
            CurrentPage.As<LoginPage>().EnterCredentials(textfield, credential);
        }

        [When(@"I click the '(.*)' button")]
        public void WhenIClickTheButton(string buttonName)
        {
            CurrentPage = GetInstance<LoginPage>();
            CurrentPage.As<LoginPage>().ClickButton(buttonName);
        }

        [Then(@"I should see '(.*)' on the screen")]
        public void ThenIShouldSeeOnTheScreen(string loggedInUser)
        {
            DriverContext.GetAndroidDriver();

            CurrentPage = GetInstance<HomePage>();
            CurrentPage.As<HomePage>().VerifyUserLoggedIn(loggedInUser);
        }


    }

}
