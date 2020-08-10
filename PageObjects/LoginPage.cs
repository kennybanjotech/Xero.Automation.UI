using System;
using System.Security.Policy;
using Automation.Capsule.UI.WebElementObjects;
using Automation.Capsule.UI.WebElementObjects.Interfaces;
using Automation.Capsule.UI.WebElementObjects.WebElements;
using Automation.Capsule.UI.Base;
using Automation.Capsule.UI.GenericObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageFactory = SeleniumExtras.PageObjects.PageFactory;
using Should;

namespace Xero.Automation.UI.PageObjects
{
    public class 
        LoginPage: BasePage
    {
        GenericPage GenericPage => new GenericPage();

        [FindsBy(How = How.Id, Using = "login:usernameDecorate:username")]
        private IWebElement Username;

        [FindsBy(How = How.Id, Using = "login:passwordDecorate:password")]
        private IWebElement Password;

        [FindsBy(How = How.Id, Using = "login:login")]
        private IWebElement LoginBTN;

        
    

        public LoginPage GoToLoginPage()
        {
            DriverContext.WebDriver.Url = url;
            return new LoginPage();
        }

        public LoginPage EnterCredentials(string textfield, string credential)
        {
            GenericPage.GetTextFieldByID(textfield).WaitUntilElementIsDisplayed();
            GenericPage.GetTextFieldByID(textfield).IsDisplayed().ShouldBeTrue("Username textfield is not displayed");
            GenericPage.GetTextFieldByID(textfield).EnterText(credential);
            return new LoginPage();
        }

        public void ClickButton(string buttonName)
        {
            GenericPage.GetButtonByID(buttonName).WaitUntilElementIsEnabled();
            GenericPage.GetButtonByID(buttonName).Click();
            
        }


        public void SystemAdministratorLogin(string username, string password)
        {
            GoToLoginPage();
            EnterLoginInformation(username, password);

        }

        public  void EnterLoginInformation(string username, string password)
        {
            GenericPage.GetTextFieldByID("email").WaitUntilElementIsDisplayed();
            GenericPage.GetTextFieldByID("email").EnterText(username);
            GenericPage.GetTextFieldByID("password").WaitUntilElementIsDisplayed();
            GenericPage.GetTextFieldByID("password").EnterText(password);
            ClickButton("submitButton");
        }

        

    }
}