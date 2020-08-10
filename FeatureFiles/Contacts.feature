Feature: Contacts
Create and maintain contacts.
System administrator should be able to add and view a contact

Background: 
Given I login as a system administrator

Scenario: System administrator adds a person
	When I create a new contact
	And I add the following details
	| FirstName | LastName | Email               | ContactName      | Phone Number |
	| John      | Bishop   | J.bishoop@gmail.com | Samsung PLC | 01234567891  |

	Then the company 'Samsung PLC' should be displayed
