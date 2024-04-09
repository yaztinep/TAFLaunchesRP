using Automation.Framework.Core.WebAbstractions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
namespace Automation.Framework.Core.Selenium.WebDrivers.LocalWebDriver
{
    public class ChromeWebDriver : IDriver
    {
        IDefaultVariables _idefaultVariables;
        public ChromeWebDriver(IDefaultVariables idefaultVariables)
        {
            _idefaultVariables = idefaultVariables;
        }
        public IWebDriver GetWebDriver(DriverOptions options)
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver(_idefaultVariables.Resources, (ChromeOptions)options);
        }

        public bool IsApplicable(Browsers browsers)
        {
            switch (browsers)
            {
                case Browsers.chrome:
                    return true;
                default:
                    return false;
            }
        }
    }
}
