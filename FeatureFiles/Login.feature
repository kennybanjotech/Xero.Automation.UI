Feature: Login
	Login to the Xero web app

@WebApplication
Scenario: Login to website
	Given I navigate to the application Url
	When I enter the 'email' as 'kennybanjotech@gmail.com'
	And I enter the 'password' as 'Bolajimi1.'
	And I click the 'submitButton' button
	Then User 'Kenny Banjo' should be logged in
	#Then 'KennyBanjotech' should be displayed on the homepage

	#Then I should see 'Kenny Adebanjo' on the screen
