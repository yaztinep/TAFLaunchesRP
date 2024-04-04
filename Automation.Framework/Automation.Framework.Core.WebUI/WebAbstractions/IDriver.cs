using OpenQA.Selenium;

namespace Automation.Framework.Core.WebUI.WebAbstractions
{
    public interface IDriver
    {
        IWebDriver GetWebDriver(DriverOptions options);

        bool IsApplicable(Browsers browsers);
    }
}
