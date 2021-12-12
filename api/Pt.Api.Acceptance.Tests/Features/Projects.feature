Feature: Projects List

Scenario: Create new project
	Given a project
	| Name | Notes               |
	| Foo  | My new awesome idea |
	When the projects POST endpoint is called
	Then the response should be OK
	And the response should be a non null id
	
Scenario: Create new project and query it by id 
	Given a project
	| Name    | Notes   |
	| <Name>  | <Notes> |
 	When the projects POST endpoint is called
 	Then the response should be OK
 	When the projects GET endpoint is called with the context Id
 	Then the response should be OK
 	And the response project should be the same
    | Name   | Notes   |
    | <Name> | <Notes> |

 	Examples: 
 	| Name | Notes                 |
    | Bar  | Not such a great idea |
    
Scenario: Create new project and query all projects 
	Given a project
	  | Name   | Notes   |
	  | <Name> | <Notes> |
	When the projects POST endpoint is called
	Then the response should be OK
	When the projects GET endpoint is called
	Then the response should be OK
	And the response should contain a project like this
	  | Name   | Notes   |
	  | <Name> | <Notes> |

	Examples: 
	  | Name | Notes                   |
	  | Baz  | Running out of names 😅 |