using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Challenge.Util
{
    public static class SeleniumSetMethods
    {
        //Method used to Enter a Text
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        //Method used to Click into a button/Checkbox/option etc
        public static void Clicks(this IWebElement element)
        {
            element.Submit();
        }

        public static void ClickOnElement(this IWebElement element)
        {
            element.Click();
        }

        //Method used when Selecting a dropdown control

        public static void SelectDropDown(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }

        //public void switchtoDefaultFrame()
        //{
        //    try
        //    {
        //        _driver.SwitchTo().DefaultContent();
        //        Console.WriteLine("Navigated back to webpage from frame");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("unable to navigate back to main webpage from frame " + e.StackTrace);
        //    }
        //}

        //public void switchToFrame(String ParentFrame, String ChildFrame)
        //{
        //    try
        //    {
        //        _driver.SwitchTo().Frame(ParentFrame).SwitchTo().Frame(ChildFrame);
        //        Console.WriteLine("Navigated to innerframe with id " + ChildFrame + " which is present on frame with id" + ParentFrame);

        //    }
        //    catch (NoSuchFrameException e)
        //    {
        //        Console.WriteLine("Unable to locate frame with id " + ParentFrame
        //                + " or " + ChildFrame + e.StackTrace);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Unable to navigate to innerframe with id "
        //                + ChildFrame + "which is present on frame with id"
        //                + ParentFrame + e.StackTrace);
        //    }
        //}

    }
}
