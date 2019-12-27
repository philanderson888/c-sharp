Feature: BBCLogin
    In order to login to my account
    As a user
    I want to see my account page

@mytag
Scenario: Invalid password
	Given I am on the login page
	And I have entered a valid username
	And I have entered an invalid password
	When I press login
	Then I should see the appropriate error







 

