using Challenge.Drivers;
using Challenge.Util;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using BoDi;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;

namespace Challenge.Hooks
{
    [Binding]
    public sealed class Hooks
    {

        private readonly IObjectContainer _container;
        private static DriverFactory _driverFactory;
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private static ExtentHtmlReporter _extentHtmlReporter;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(IObjectContainer container, ScenarioContext scenarioContext)
        {
            this._container = container;
            _scenarioContext = scenarioContext;
        }

        //Generate Extent Report at the begining of the Test
        [BeforeTestRun]
        public static void InitializeReport()
        {
            //Driver >> Generate Driver Factory
            _driverFactory = new DriverFactory();

            //Extent Report >>Generate Extent Report structure 

            _extentHtmlReporter = new ExtentHtmlReporter(ConfigurationHelper.ExtentReportOutputPath);
            _extentHtmlReporter.LoadConfig(Path.Combine(ConfigurationHelper.ExtentReportOutputPath, "extent_config.xml"));
            extent = new ExtentReports();
            extent.AttachReporter(_extentHtmlReporter);
        }

        //Once the test has run, we need to flesh the extent report
        [AfterTestRun]
        public static void TearDownReport()
        {
            //Extent Report >> Flush Report
            extent.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            //ExtentReport >> Create the features
            if (null != featureContext)
            {
                featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
            }

        }

        [AfterStep]
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {

            //ExtentReport >> Fill out report information based on Test Results
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            ScenarioBlock scenarioBlock = scenarioContext.CurrentScenarioBlock;

            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    if (scenarioContext.TestError != null)
                    {
                        var screenshot = ((ITakesScreenshot)Driver.driver).GetScreenshot().AsBase64EncodedString;
                        var mediaEntity = MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, ScenarioStepContext.Current.StepInfo.Text).Build();
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.InnerException, mediaEntity);
                    }
                    else
                    {
                        scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
                        string[,] data = new string[2,2];
                        data[0,0] = "Field 1";
                        data[0,1] = "Field 2";
                        data[1,0] = "data1";
                        data[1,1] = "data2";
                        IMarkup m = MarkupHelper.CreateTable(data);
                        scenario.Info(m);
                    }
                    break;
                case ScenarioBlock.When:
                    if (scenarioContext.TestError != null)
                    {
                        var screenshot = ((ITakesScreenshot)Driver.driver).GetScreenshot().AsBase64EncodedString;
                        var mediaEntity = MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, ScenarioStepContext.Current.StepInfo.Text).Build();
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.InnerException,mediaEntity);
                    }
                    else
                    {

                        scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text);
                        string[,] data = new string[2, 2];
                        data[0, 0] = "Field 1";
                        data[0, 1] = "Field 2";
                        data[1, 0] = "data1";
                        data[1, 1] = "data2";
                        IMarkup m = MarkupHelper.CreateTable(data);
                        scenario.Info(m);
                        var screenshot = ((ITakesScreenshot)Driver.driver).GetScreenshot().AsBase64EncodedString;
                        //  var mediaEntity = MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, ScenarioStepContext.Current.StepInfo.Text).Build();
                        scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
                            //.Pass(scenarioContext.StepContext.StepInfo.MultilineText, mediaEntity);

                    }
                    break;
                case ScenarioBlock.Then:
                    if (scenarioContext.TestError != null)
                    {
                        //screenshot in the Base64 format
                        var screenshot = ((ITakesScreenshot)Driver.driver).GetScreenshot().AsBase64EncodedString;
                        var mediaEntity = MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, ScenarioStepContext.Current.StepInfo.Text).Build();

                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message,mediaEntity);
                    }
                    else
                    {
                        scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);

                    }
                    break;
                default:
                    if (scenarioContext.TestError != null)
                    {
                        var screenshot = ((ITakesScreenshot)Driver.driver).GetScreenshot().AsBase64EncodedString;
                        var mediaEntity = MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, ScenarioStepContext.Current.StepInfo.Text).Build();
                        scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.InnerException, mediaEntity);
                    }
                    else
                    {
                        scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text);
                        string[,] data = new string[2, 2];
                        data[0, 0] = "Field 1";
                        data[0, 1] = "Field 2";
                        data[1, 0] = "data1";
                        data[1, 1] = "data2";
                        IMarkup m = MarkupHelper.CreateTable(data);
                        scenario.Info(m);
                        var screenshot = ((ITakesScreenshot)Driver.driver).GetScreenshot().AsBase64EncodedString;
                        var mediaEntity = MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, ScenarioStepContext.Current.StepInfo.Text).Build();
                        scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text).Pass(scenarioContext.StepContext.StepInfo.MultilineText, mediaEntity);

                    }
                    break;
            }



        }

        [BeforeScenario]
        public void CreateWebDriver(ScenarioContext scenarioContext)
        {
            // Driver >> Create and configure a concrete instance of IWebDriver, use the Driver
            Driver.driver = _driverFactory.CreateDriver();

            // Driver >> Make this instance available to all other step definitions
            _container.RegisterInstanceAs(Driver.driver);

            DriverActions.InitializeDriver(Driver.driver);

            //ExtentReport >> Create the scenarios
            if (null != scenarioContext)
            {

                scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title, scenarioContext.ScenarioInfo.Description);
            }

        }

        [AfterScenario]
        public void DestroyWebDriver(ScenarioContext scenarioContext)
        {     
            DriverActions.FinalizeDriver(Driver.driver);
        }
    }
}
