using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;

namespace Challenge.Drivers
{
    [Binding]
    public abstract class SpecflowBaseTest : TechTalk.SpecFlow.Steps
    {
        protected IWebDriver Driver { get; }

        public SpecflowBaseTest(IWebDriver driver)
        {
            Driver = driver;
        }

        public void NavigateToURL(string URL)
        {
            Driver.Navigate().GoToUrl(URL);
        }

        public static explicit operator RemoteWebDriver(SpecflowBaseTest v)
        {
            throw new NotImplementedException();
        }

        public abstract void getPageTitle();
        public abstract void getPageFooter();
    }
}
