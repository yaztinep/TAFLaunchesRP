using Automation.Framework.Core.WebAbstractions;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace Automation.Framework.Core.Selenium.WebDrivers.LocalWebDriver
{
    public class FirefoxWebDriver : IDriver
    {
        IDefaultVariables _idefaultVariables;
        public FirefoxWebDriver(IDefaultVariables idefaultVariables)
        {
            _idefaultVariables = idefaultVariables;
        }
        public IWebDriver GetWebDriver(DriverOptions options)
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver(_idefaultVariables.Resources, (FirefoxOptions)options);
        }

        public bool IsApplicable(Browsers browsers)
        {
            switch (browsers)
            {
                case Browsers.firefox:
                    return true;
                default:
                    return false;
            }
        }
    }
}
