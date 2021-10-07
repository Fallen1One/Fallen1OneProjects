Feature: GoogleSearchResultsPanelTest
	
@GSRP @Smoke @Done
Scenario: Perform Google search for the given keyword and verify that “About results” panel is displayed
	 When I open http://www.google.com
	  And I type random year from the second millennium into SearchInputField
	  And I click GoogleSearchButton
	 Then I see ResultStatsPanel is displayed