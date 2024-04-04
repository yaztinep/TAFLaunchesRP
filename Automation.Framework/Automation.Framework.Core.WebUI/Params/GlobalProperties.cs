using Automation.Framework.Core.WebUI.Reporting;
using Automation.Framework.Core.WebUI.WebAbstractions;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Automation.Framework.Core.WebUI.Params
{
    public class GlobalProperties : IGlobalProperties
    {
        IDefaultVariables _idefaultVariables;
        ILogging _ilogging;
        IExtentReport _iextentReport;

        public string BrowserType { get; set; }
        string BrowserVersion { get; set; }
        public string GridHubUrl { get; set; }
        string Region { get; set; }
        bool StepScreenShot { get; set; }
        string ExtentReportPortalUrl { get; set; }
        bool ExtentReportToPortal { get; set; }
        string LogLevel { get; set; }
        string DataSetLocation { get; set; }
        public string DownloadedLocation { get; set; }


        public GlobalProperties(IDefaultVariables idefaultVariables, ILogging ilogging, IExtentReport iextentReport) 
        {
            _idefaultVariables = idefaultVariables;
            _ilogging = ilogging;
            _iextentReport = iextentReport;
            Configuration();
        }
        public void Configuration()
        {
            IConfiguration builder = null;
            try
            {
                builder = new ConfigurationBuilder().SetBasePath(_idefaultVariables.Resources)
                               .AddJsonFile("frameworkSetting.json").Build();
            }
            catch (FileNotFoundException ex)
            {
                _ilogging.Error("FrameworkSettings.json doesn't exist" + ex.Message);
                System.Environment.Exit(0);
            }

            BrowserType = string.IsNullOrEmpty(builder["BrowserType"]) ? "chrome" : builder["BrowserType"];
            BrowserVersion = builder["BrowserVersion"];
            GridHubUrl = string.IsNullOrEmpty(builder["GridHubUrl"]) ? _idefaultVariables.GridHubUrl : builder["GridHubUrl"];
            Region = builder["Region"];
            StepScreenShot = builder["StepScreenShot"].ToLower().Equals("on") ? true : false;
            ExtentReportPortalUrl = builder["ExtentReportPortalUrl"];
            ExtentReportToPortal = builder["ExtentReportToPortal"].ToLower().Equals("on") ? true : false;
            LogLevel = builder["LogLevel"];
            DataSetLocation = string.IsNullOrEmpty(builder["DataSetLocation"]) ? _idefaultVariables.filePath : builder["DataSetLocation"];
            DownloadedLocation = string.IsNullOrEmpty(builder["DataSetLocation"]) ? _idefaultVariables.filePath : builder["DownloadedLocation"];

            if(string.IsNullOrEmpty(Region))
            {
                _ilogging.Error("User has not provided application environment information.");
                System.Environment.Exit(0);
            }

            _ilogging.SetLogLevel(LogLevel);

            IConfiguration applicationbuilder = null;
            try
            {
                applicationbuilder = new ConfigurationBuilder().SetBasePath(_idefaultVariables.Resources)
                               .AddJsonFile("applicationRegion.json").Build();
                applicationbuilder.GetSection(Region);
            }
            catch (FileNotFoundException ex)
            {
                _ilogging.Error("applicationRegion.json doesn't exist" + ex.Message);
                System.Environment.Exit(0);
            }

            _iextentReport.InitiliazeExtentReport();

            _ilogging.Debug("********************************************************************************");
            _ilogging.Information("********************************************************************************");
            _ilogging.Information("Configuration |RUN PARAMETERS");
            _ilogging.Information("********************************************************************************");
            _ilogging.Information("Configuration|BROWSER TYPE: " + BrowserType);
            _ilogging.Information("Configuration|BROWSER VERSION: " + BrowserVersion);
            _ilogging.Information("Configuration|GRID HUB URL: " + GridHubUrl);
            _ilogging.Information("Configuration|REGION: " + builder["region"]);
            _ilogging.Information("Configuration|STEP SCREENSHOT: " + builder["StepScreenShot"]);
            _ilogging.Information("Configuration|EXTENT REPORT PORTAL URL: " + ExtentReportPortalUrl);
            _ilogging.Information("Configuration|EXTENT REPORT LOCALLY: " + builder["ExtentReportToPortal"]);
            _ilogging.Information("Configuration|LOG LEVEL: " + LogLevel);
            _ilogging.Information("Configuration|DATA SET LOCATION: " + DataSetLocation);
            _ilogging.Information("Configuration|DOWNLOADED LOCATION: " + DownloadedLocation);
            _ilogging.Information("********************************************************************************");
            _ilogging.Information("********************************************************************************");
        }
    }
}
