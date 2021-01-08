using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Challenge.Drivers;
using Challenge.Pages;
using Challenge.Util;
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ACTinium.Pages;

namespace Challenge.Steps
{
    [Binding]
    public sealed class ChallengeSteps : SpecflowBaseTest
    {

        private readonly ScenarioContext _scenarioContext;   
        private OfficialHomePage page { get; }
        public SpecflowBaseTest currentPage { get; set; }
        public ChallengeSteps(ScenarioContext scenarioContext, IWebDriver driver) : base(driver)
        {
            this.page = new OfficialHomePage(driver);
            _scenarioContext = scenarioContext;
        }
        [Given(@"On Official Home Page")]
        public void GivenOnOfficialHomePage()
        {
            NavigateToURL(ConfigurationHelper.ACTionURL);
        }

        [When(@"I validate all the menu items are present")]
        public void WhenIValidateAllTheMenuItemsArePresent()
        {
            page.ValidateMenuItems();
        }

        [When(@"I click on Windows I get redirected to Windows page")]
        public void WhenIClickOnWindowsIGetRedirectedToWindowsPage()
        {
            currentPage = page.ClickOnWindowsOption();
        }

        [When(@"On Windows page I click on Windows (.*) Menu")]
        public void WhenOnWindowsPageIClickOnWindowsMenu(int p0)
        {
            ((WindowsPage)currentPage).ClickOnWindows10Option();
        }

        [When(@"I print all the Elements from the dropdown")]
        public void WhenIPrintAllTheElementsFromTheDropdown()
        {
            ((WindowsPage)currentPage).PrintAllElementsWithinWindows10Option();
        }

        [When(@"I go to Search located next to the Shopping Cart")]
        public void WhenIGoToSearchLocatedNextToTheShoppingCart()
        {
            ((WindowsPage)currentPage).ClickOnSearchButton();
        }

        [When(@"I search for Visual Studio")]
        public void WhenISearchForVisualStudio()
        {
            currentPage = ((WindowsPage)currentPage).SearchForVisualStudio();
        }

        [When(@"I print the price for the first (.*) elements listed from the Search Results")]
        public void WhenIPrintThePriceForTheFirstElementsListedFromTheSearchResults(int p0)
        {
            ((SearchResultsPage)currentPage).PrintOutInConsoleThePricesForTheFirstThreeElements();
        }

        [When(@"I store the price of the first element listed")]
        public void WhenIStoreThePriceOfTheFirstElementListed()
        {
            _scenarioContext["firstPriceOfTheFirstElementListed"] = ((SearchResultsPage)currentPage).SaveFirstPrice();
        }

        [When(@"I clck on the first one in order to go to the details page")]
        public void WhenIClckOnTheFirstOneInOrderToGoToTheDetailsPage()
        {
            currentPage = ((SearchResultsPage)currentPage).NavigateToFirstResult();
        }

        [When(@"Once the details page is displayed I validate both prices are the same")]
        public void WhenOnceTheDetailsPageIsDisplayedIValidateBothPricesAreTheSame()
        {
            ((SubscriptionPage)currentPage).ValidateBothPrices((string)_scenarioContext["firstPriceOfTheFirstElementListed"]);
        }

        [When(@"I click Add to Cart button")]
        public void WhenIClickAddToCartButton()
        {
            currentPage=((SubscriptionPage)currentPage).AddToCart();
        }

        [When(@"I Verify that all the three price amounts listed on the last pate are the same")]
        public void WhenIVerifyThatAllTheThreePriceAmountsListedOnTheLastPateAreTheSame()
        {
            ((CartPage)currentPage).verifyThreeAmounts();
        }

        [When(@"On the number of items dropdown I select twenty Option and validate that the total amount is the Unit price multiplied by twenty")]
        public void WhenOnTheNumberOfItemsDropdownISelectTwentyOptionAndValidateThatTheTotalAmountIsTheUnitPriceMultipliedByTwenty()
        {
            ((CartPage)currentPage).validateAmounts();
        }
    }
}
