Feature: BBCLogin
    In order to login to my account
    As a user
    I want to see my account page

@mytag
Scenario Outline: Invalid password
	Given I am on the login page
	And I have entered a valid <username>
	And I have entered an invalid <password>
	When I press login
	Then I should see the appropriate <error>

	Examples:
	| username         | password | error                                                      |
	| user@testing.com | 12345678 | Sorry, that password isn't valid. Please include a letter. |
    | user@testing.com | 123      | Sorry, that password is too short. It needs to be eight characters or more. |
    | user@testing.com | @@@@@@@@ | Sorry, that password isn't valid. Please include a letter.                  |



 

