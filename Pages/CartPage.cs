using Challenge.Drivers;
using Challenge.Util;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace Challenge.Pages
{
    class CartPage : SpecflowBaseTest
    {
        private readonly ScenarioContext _scenarioContext;
        private RemoteWebDriver _driver;
        public CartPage(IWebDriver driver) : base(driver)
        {
            _driver = (RemoteWebDriver)driver;
        }

        #region WebElements
        private By lblItemPrice => By.XPath("//*[@id='store-cart-root']/div/div/div/section[1]/div/div/div/div/div/div[2]/div[2]/div[2]/div/span/span[2]/span");
        private By lblItemSubtotal => By.XPath("//*[@id='store-cart-root']/div/div/div/section[2]/div/div/div[1]/div/span[1]/span[2]/div/span/span[2]/span");
        private By lblTotalPrice => By.XPath("//*[@id='store-cart-root']/div/div/div/section[2]/div/div/div[2]/div/span/span[2]/strong/span");

        private By ddlElementToSelect = By.XPath("//select[@aria-label='Visual Studio Professional Subscription  Quantity selection']");
        #endregion

        #region Actions

        public void verifyThreeAmounts()
        {
            String itemPrice, itemSubtotal, totalPrice;
            itemPrice = _driver.FindElement(lblItemPrice).Text;
            itemSubtotal = _driver.FindElement(lblItemSubtotal).Text;
            totalPrice = _driver.FindElement(lblTotalPrice).Text;

            Assert.AreEqual(itemPrice, itemSubtotal);
            Assert.AreEqual(itemSubtotal, totalPrice);
            Console.WriteLine("Step 13. The three amounts displayed on this page are the same");
        }

        public void validateAmounts()
        {
            String itemPrice, itemSubtotal, totalPrice;
            _driver.FindElement(ddlElementToSelect).Click();
            _driver.FindElement(ddlElementToSelect).SendKeys("20");
            _driver.FindElement(ddlElementToSelect).SendKeys(Keys.Tab);
            Thread.Sleep(4000);
            itemPrice = _driver.FindElement(lblItemPrice).Text;
            totalPrice = _driver.FindElement(lblTotalPrice).Text;            

            string pattern = @"(\p{Sc}\s?)?(\d+\.?((?<=\.)\d+)?)(?(1)|\s?\p{Sc})?";
            string replacement = "$2";
            Regex rgx = new Regex(pattern);
            Double totalPriceNumeric = Convert.ToDouble(rgx.Replace(totalPrice, replacement));
            Double itemPriceNumeric = Convert.ToDouble(rgx.Replace(itemPrice, replacement));

            Assert.AreEqual(totalPriceNumeric, (itemPriceNumeric * 20));

            Console.WriteLine("Step 14. the Total amount matches the Unit Price multiplied by 20 ");
        }

        #endregion
    }
}
