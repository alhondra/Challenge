using Challenge.Util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Challenge.Drivers
{
    public static class DriverActions
    {
        public static void InitializeDriver(this IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }

        public static void eWaitExists(this IWebDriver driver,By element)
        {
            WebDriverWait eWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            eWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(element));
        }

        public static void eWaitVisible(this IWebDriver driver, By element)
        {
            WebDriverWait eWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            eWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
        }

        public static void eWaitClickable(this IWebDriver driver, By element)
        {
            WebDriverWait eWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            eWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }       

        public static void WaitSeconds(this IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigurationHelper.WaitTimeInSeconds);
        }

        public static void NavigateToURL(this IWebDriver driver, string URL)
        {
            driver.Navigate().GoToUrl(URL);
        }

        public static void FinalizeDriver(this IWebDriver driver)
        {
            driver.Close();
            driver.Dispose();
        }

        //Method to improve the explicit waits
        public static IWebElement ElementIsPresent(this IWebDriver driver,By locator)
        {
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var flag = wait.Until(ExpectedConditions.ElementIsVisible(locator));              
                WaitSeconds(driver);
                return flag;
        }

    }
}
