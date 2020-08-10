using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Capsule.UI.Base;
using Automation.Capsule.UI.GenericObjects;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Shouldly;

namespace Automation.Capsule.UI.PageObjects
{
    public class HomePage:BasePage
    {
        GenericPage GenericPage = new GenericPage();

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'KennyBanjotech')]")]
        private IWebElement LoggedInUser;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'KennyBanjotech')]")]
        private IWebElement AccountName;
       

        public void ClickNavBarButton(string buttonName)
        {
            GenericPage.GetButtonByDataAutomationid(buttonName).WaitUntilElementIsDisplayed();
            GenericPage.GetButtonByDataAutomationid(buttonName).Click();
        }

        //public void ClickButtonById(string buttonName)
        //{
        //    GenericPage.GetButtonByDataAutomationid(buttonName).WaitUntilElementIsDisplayed();
        //    GenericPage.GetButtonByDataAutomationid(buttonName).Click();
        //}

        public HomePage VerifyUserLoggedIn(string loggedInUser)
        {
          GenericPage.GetLabelByDataAutomationId(loggedInUser).WaitUntilElementIsDisplayed();
          GenericPage.GetLabelByDataAutomationId(loggedInUser).IsDisplayed().ShouldBeTrue($"{loggedInUser} is not displayed");
          return new HomePage();
        }

        
    }
}
