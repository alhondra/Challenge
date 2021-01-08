using Challenge.Pages;
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
using ACTinium.Pages;

namespace Challenge.Pages
{

    class OfficialHomePage : SpecflowBaseTest
    {
        private readonly ScenarioContext _scenarioContext;
        private RemoteWebDriver _driver;

        public OfficialHomePage(IWebDriver driver) : base(driver)
        {
            _driver = (RemoteWebDriver)driver;
        }

        #region WebElements

        private By optOffice => By.XPath("//a[@id='shellmenu_1']");
        private By optWindows => By.XPath("//a[@id='shellmenu_2']");
        private By optSurface => By.XPath("//a[@id='shellmenu_3']");
        private By optXBox => By.XPath("//a[@id='shellmenu_4']");
        private By optDeals => By.XPath("//a[@id='shellmenu_5']");
        private By optSupport => By.XPath("//a[@id='l1_support']");

        #endregion

        #region Actions

        public void ValidateMenuItems()
        {
            _driver.eWaitExists(optOffice);
            Assert.AreEqual("Office", _driver.FindElement(optOffice).Text);
            Console.WriteLine("I found the MenuOption {0}", _driver.FindElement(optOffice).Text);
            _driver.eWaitExists(optWindows);
            Assert.AreEqual("Windows", _driver.FindElement(optWindows).Text);
            Console.WriteLine("I found the MenuOption {0}", _driver.FindElement(optWindows).Text);
            _driver.eWaitExists(optSurface);
            Assert.AreEqual("Surface", _driver.FindElement(optSurface).Text);
            Console.WriteLine("I found the MenuOption {0}", _driver.FindElement(optSurface).Text);
            _driver.eWaitExists(optXBox);
            Assert.AreEqual("Xbox", _driver.FindElement(optXBox).Text);
            Console.WriteLine("I found the MenuOption {0}", _driver.FindElement(optXBox).Text);
            _driver.eWaitExists(optDeals);
            Assert.AreEqual("Deals", _driver.FindElement(optDeals).Text);
            Console.WriteLine("I found the MenuOption {0}", _driver.FindElement(optDeals).Text);
            _driver.eWaitExists(optSupport);
            Assert.AreEqual("Support", _driver.FindElement(optSupport).Text);
            Console.WriteLine("I found the MenuOption {0}", _driver.FindElement(optSupport).Text);
        }

        public WindowsPage ClickOnWindowsOption()
        {
            _driver.FindElement(optWindows).Click();
            Thread.Sleep(3000);
            Console.WriteLine("Step 3. I selected Windows top menu.");
            return new WindowsPage(_driver);
        }

        #endregion

    }
}
