using Automation.Framework.Core.WebUI.WebAbstractions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace Automation.Framework.Core.WebUI.Selenium.WebDrivers.RemoteDriver
{
    public class RemoteDriver : IDriver
    {
        IGlobalProperties _iglobalProperties;
        public RemoteDriver(IGlobalProperties iglobalProperties) 
        {
            _iglobalProperties = iglobalProperties;
        }
        public IWebDriver GetWebDriver(DriverOptions options)
        {
            return new RemoteWebDriver(new Uri(_iglobalProperties.GridHubUrl),options);
        }

        public bool IsApplicable(Browsers browsers)
        {
            switch (browsers)
            {
                case Browsers.firefox:
                case Browsers.chrome: 
                case Browsers.remotechrome:
                case Browsers.remotefirefox:
                    return true;
                default:
                    return false;
            }
        }
    }
}
