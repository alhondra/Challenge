using System;
using System.Configuration;

namespace Challenge.Util
{
    public static class ConfigurationHelper
    {
        public static string ExtentReportOutputPath 
        {
            get { return ConfigurationManager.AppSettings["ExtentReportOutputPath"]?.ToString(); }
        }

        public static string ACTionURL
        {
            get { return ConfigurationManager.AppSettings["ACTionURL"]?.ToString(); }
        }

        public static double WaitTimeInSeconds
        {
            get { return Convert.ToDouble(ConfigurationManager.AppSettings["WaitTimeInSeconds"]?.ToString()); } 
        }
        
        public static string TestData
        {
            get { return ConfigurationManager.AppSettings["TestData"]?.ToString(); }
        }
    }
}
