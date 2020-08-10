using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Capsule.UI.Base;
using Automation.Capsule.UI.PageObjects;
using TechTalk.SpecFlow;

namespace CapsuleCRMUI.StepDefinitions
{
    [Binding]
    public class HomePageSteps:BasePage
    {
        [Then(@"'(.*)' should be displayed on the homepage")]
        public void ThenKennyBanjotechShouldBeDisplayedOnTheHomepage(string loggedInUser)
        {
            CurrentPage = GetInstance<HomePage>();
            CurrentPage.As<HomePage>().VerifyUserLoggedIn(loggedInUser);
        }

        [Then(@"User '(.*)' should be logged in")]
        public void ThenUserShouldBeLoggedIn(string loggedInUser)
        {
            CurrentPage = GetInstance<HomePage>();
            CurrentPage.As<HomePage>().VerifyUserLoggedIn(loggedInUser);
        }


    }
}
