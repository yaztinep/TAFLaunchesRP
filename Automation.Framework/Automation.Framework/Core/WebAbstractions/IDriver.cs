using OpenQA.Selenium;

namespace Automation.Framework.Core.WebAbstractions
{
    public interface IDriver
    {
        IWebDriver GetWebDriver(DriverOptions options);

        bool IsApplicable(Browsers browsers);
    }
}
