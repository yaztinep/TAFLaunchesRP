Feature: LoginRP

A short summary of the feature

Scenario: Login to Report Portal
	Given Im on the login page "<#url#>"
	When I enter the username "username"
	And I enter the password "username"
	And I click on the login button
	Then I should be redirected to the home page
