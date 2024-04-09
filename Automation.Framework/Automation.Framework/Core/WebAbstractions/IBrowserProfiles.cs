using OpenQA.Selenium;

namespace Automation.Framework.Core.WebAbstractions
{
    public interface IBrowserProfiles
    {
        DriverOptions GetBrowserProfile();

        bool IsApplicable(Browsers browsers);
    }
}
