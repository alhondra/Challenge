using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Configuration;

namespace Challenge.Drivers
{
    public class DriverFactory
    {
        public IWebDriver CreateDriver()
        {
                string browser = (Environment.GetEnvironmentVariable("BROWSER") ?? "CHROME").ToUpperInvariant();
                switch (browser)
                {
                    case "FIREFOX":
                        return new FirefoxDriver();
                    case "CHROME":
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("no-sandbox");

                        ChromeDriver drv = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
                        drv.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));

                        return drv;
                    case "IE":
                        return new InternetExplorerDriver();
                    case "EDGE":
                        var edgeOptions = new EdgeOptions()
                        {
                            UseChromium = true
                        };

                        return new EdgeDriver(edgeOptions);
                    default:
                        throw new ArgumentException($"Browser not yet implemented: {browser}");
                }
        }

        public static explicit operator RemoteWebDriver(DriverFactory v)
        {
            throw new NotImplementedException();
        }
    }
}
