Feature: ChallengeMSNPage
The purpose of this feature is to complete the challenge of 14 steps and accessing to MSN page
And perform some actions.


@smoke
Scenario: This scenario is the series of 14 steps to cover the challenge
	Given On Official Home Page  
	When I validate all the menu items are present
	And  I click on Windows I get redirected to Windows page
	And  On Windows page I click on Windows 10 Menu
	And I print all the Elements from the dropdown
	And I go to Search located next to the Shopping Cart
	And I search for Visual Studio
	And I print the price for the first 3 elements listed from the Search Results
	And I store the price of the first element listed
	And I clck on the first one in order to go to the details page
	And Once the details page is displayed I validate both prices are the same
	And I click Add to Cart button
	And I Verify that all the three price amounts listed on the last pate are the same
	And On the number of items dropdown I select twenty Option and validate that the total amount is the Unit price multiplied by twenty