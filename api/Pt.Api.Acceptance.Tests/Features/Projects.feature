Feature: Projects List

Scenario: Create new project
	Given a project
	| Name | Notes               |
	| Foo  | My new awesome idea |
	When the projects POST endpoint is called
	Then the response should be OK
	And the response should be a non null id