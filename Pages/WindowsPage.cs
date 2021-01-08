using Challenge.Drivers;
using Challenge.Pages;
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

namespace ACTinium.Pages
{

    class WindowsPage : SpecflowBaseTest
    {
        private readonly ScenarioContext _scenarioContext;
        private RemoteWebDriver _driver;
        public WindowsPage(IWebDriver driver) : base(driver)
        {
            _driver = (RemoteWebDriver)driver;
        }

        #region WebElements
        private By optWindows10 => By.XPath("//a[@id='shellmenu_0']");
        private By optWindows10ListOfElements => By.XPath("//button[@id='c-shellmenu_54']/following-sibling::ul/li");
        private By subMenuOption => By.XPath("//button[@id='c-shellmenu_54']/following-sibling::ul/li//a[@id='c-shellmenu_55']");
        private By btnSearch => By.XPath("//button[@id='search']");
        private By txtSearch => By.XPath("//input[@id='cli_shellHeaderSearchInput']");
        private By btnContinueOnUSA => By.XPath("//button[@title='Permanecer en United States - English']");
        #endregion

        #region Actions

        public void ClickOnWindows10Option()
        {
            _driver.eWaitExists(optWindows10);
            _driver.FindElement(By.XPath("//button[@id='c-shellmenu_54']")).Click();
            Console.WriteLine("Step 4. Once on Windows page, clicked on Windows 10 Menu");
        }

        public void PrintAllElementsWithinWindows10Option()
        {
            IList<IWebElement> ddlWindows10Options = _driver.FindElements(optWindows10ListOfElements);
            Console.WriteLine("Step 5. There are {0} subMenu Options under Windows10 and those are: ", ddlWindows10Options.Count());
            _driver.eWaitClickable(subMenuOption);
            foreach (IWebElement option in ddlWindows10Options)
            {
                String subMenu = option.FindElement(By.TagName("a")).Text;
                Console.WriteLine("subMenu Option Name: {0}", subMenu);
            }
        }

        public void ClickOnSearchButton()
        {
            _driver.FindElement(btnSearch).Click();
            Console.WriteLine("Step 6. Clicked Search button located next the shopping cart");
        }

        public SearchResultsPage SearchForVisualStudio()
        {
            Thread.Sleep(4);
            _driver.eWaitVisible(txtSearch);
            _driver.FindElement(txtSearch).EnterText("Visual Studio");
            _driver.FindElement(txtSearch).SendKeys(Keys.Enter);
            Console.WriteLine("Step 7. Searched for Visual Studio");
            Thread.Sleep(4);

            //Close the message "continue navigating to US"
            if (_driver.FindElement(btnContinueOnUSA).Enabled)
            {
                _driver.FindElement(btnContinueOnUSA).Click();
            }

            return new SearchResultsPage(_driver);
        }
        #endregion
    }
}
