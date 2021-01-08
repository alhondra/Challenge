using Challenge.Drivers;
using Challenge.Util;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Challenge.Pages
{
    class SubscriptionPage : SpecflowBaseTest
    {
        private readonly ScenarioContext _scenarioContext;
        private RemoteWebDriver _driver;
        public SubscriptionPage(IWebDriver driver) : base(driver)
        {
            _driver = (RemoteWebDriver)driver;
        }
        #region WebElements

        private By priceFirstElement => By.XPath("//div[@id='productPrice']//span");
        private By closePopUpButton => By.XPath("//div[contains(@data-m,'CloseButton')]");
        private By btnAddToCart => By.XPath("//button[@id='buttonPanel_AddToCartButton']");
        #endregion

        #region Actions

        public void ValidateBothPrices(String priceFromResultsPage)
        {
            _driver.eWaitExists(priceFirstElement);
            String secondItemPrice = _driver.FindElement(priceFirstElement).Text;
            Assert.AreEqual(priceFromResultsPage, secondItemPrice);
            Console.WriteLine("Step 11. Price 1 and 2 are the same");
            _driver.eWaitVisible(closePopUpButton);
            //Close "Sign me up" window
            _driver.FindElement(closePopUpButton).Click();
        }

        public CartPage AddToCart()
        {
            _driver.FindElement(btnAddToCart).Click();
            Thread.Sleep(10000);
            Console.WriteLine("Step 12. I clicked on Add to Cart Button");
            return new CartPage(_driver);
        }
        #endregion
    }
}
