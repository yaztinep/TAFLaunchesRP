using OpenQA.Selenium;

namespace Automation.Framework.Core.WebUI.WebAbstractions
{
    public interface IBrowserProfiles
    {
        DriverOptions GetBrowserProfile();

        bool IsApplicable(Browsers browsers);
    }
}
