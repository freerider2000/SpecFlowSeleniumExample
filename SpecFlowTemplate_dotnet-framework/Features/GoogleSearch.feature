Feature: Google Search

As an internet user
I want to be able to search about topics I am interested in 
So I can become better informed about these topics 

@Browser_Chrome
Scenario Outline: Get the results for any given topic
Given I am on the Google home page
When I search for <topic>
Then Each of the results should contain the <topic>

Examples: 
| topic   |
| testing |
| running |

@Browser_Chrome
@Browser_IE
@Browser_Edge
@Browser_Firefox
Scenario Outline: Check that the number of results is returned
Given I am on the Google home page
When I search for <topic>
Then validate the number of results is returned

Examples: 
| topic   |
| testing |
