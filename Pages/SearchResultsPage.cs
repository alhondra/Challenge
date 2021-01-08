using Challenge.Drivers;
using Challenge.Util;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace Challenge.Pages
{
    class SearchResultsPage : SpecflowBaseTest
    {
        private readonly ScenarioContext _scenarioContext;
        private RemoteWebDriver _driver;

        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
            _driver = (RemoteWebDriver)driver;
        }

        #region WebElements
        private By lstPrices => By.XPath("//*[contains(text(),'Visual')]/parent::div//span[@itemprop='price']");
        #endregion

        #region Actions

        public void PrintOutInConsoleThePricesForTheFirstThreeElements()
        {
            _driver.eWaitVisible(lstPrices);
            IList<IWebElement> imgSearchResults = _driver.FindElements(lstPrices);
            Console.WriteLine("There are {0} Search Results", imgSearchResults.Count());

            for (int i = 0; i < 3; i++)
            {
                String price = imgSearchResults[i].Text;
                Console.WriteLine("Step 8. The price for the element {0} from the search results is: {1}", (i + 1), price);
            }
        }

        public String SaveFirstPrice()
        {
            String firstItemPrice, secondItemPrice;
            IList<IWebElement> imgSearchResults = _driver.FindElements(lstPrices);
            firstItemPrice = imgSearchResults[0].Text;
            Console.WriteLine("Step 9. I have stored the First price displayed for the First Item");
            return firstItemPrice;
        }

        public SubscriptionPage NavigateToFirstResult()
        {
            IList<IWebElement> imgSearchResults = _driver.FindElements(lstPrices);
            imgSearchResults[0].Click();
            Console.WriteLine("Step 10. I have selected the First Item from the search results");
            Thread.Sleep(8);
            return new SubscriptionPage(_driver);
        }
        #endregion
    }
}
