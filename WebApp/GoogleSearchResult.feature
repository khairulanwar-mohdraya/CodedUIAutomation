Feature: GoogleSearchResult
	In order to search Google
	As a User
	I want to get a search result of an Iphone.

@GoogleSearchResult
Scenario: Enter a keyword
	Given I have entered a keyword in input field
	When I press search
	Then the result should be display
