Feature: Wiggle Automation

Scenario: 01 - Navigate to the Wiggle Website
	Given I have navigated to the wiggle website
	Then the wiggle website is displayed

Scenario: 02 - Add Item to basket
	Given I have navigated to the wiggle website
	When I  search for 'head torch'
	And I add the item to my basket
	When I navigate to my basket 
	Then the item I have added is show