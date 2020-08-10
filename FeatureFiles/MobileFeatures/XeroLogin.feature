Feature: XeroLogin
	As a valid user, i shohuld be able log into the appplication succesfully.

@mobileautomation
Scenario: Login to app
	#Given I launch the contact app
	When I click the 'login_start_button' mobile button
	And I enter 'kennybanjotech@gmail.com' as the 'Email address'
	And I enter 'Bolajimi1.' as the 'Password'
	 And I click the 'xa_login_button' mobile button