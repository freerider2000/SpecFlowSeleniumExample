Feature: Google Search

As an internet user
I want to be able to search about topics I am interested in 
So I can become better informed about these topics 

Scenario Outline: Get the results for any given topic
Given I am on the Google home page
When I search for <topic>
Then Each of the results should contain the <topic>

Examples: 
| topic   |
| testing |
| weather |
 