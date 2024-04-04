using Automation.Framework.Core.WebUI.WebAbstractions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Automation.Framework.Core.WebUI.Selenium.WebDrivers.LocalWebDriver
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
            return new ChromeDriver(_idefaultVariables.Resources,(ChromeOptions)options);  
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
