using Automation.Framework.Core.WebUI.WebAbstractions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Automation.Framework.Core.WebUI.Selenium.BrowserProfiles
{
    public class ChromeProfiles : IBrowserProfiles
    {
        IGlobalProperties _iglobalProperties;
        public ChromeProfiles(IGlobalProperties iglobalProperties) 
        { 
            _iglobalProperties = iglobalProperties;
        }
        public DriverOptions GetBrowserProfile()
        {
            var options = new ChromeOptions();
            options.AcceptInsecureCertificates = true;
            options.AddArgument("disable-extensions");
            options.AddArgument("disable-infobars");
            options.AddArgument("disable-notifications");
            options.AddArgument("disable-web-security");
            options.AddArgument("dns-prefetch-disable");
            options.AddArgument("disable-browser-side-navigation");
            options.AddArgument("disable-gpu");
            options.AddArgument("always-authorize-plugins");
            options.AddArgument("load-extensions=src/main/resoruces/chrome_load_stopper");
            options.AddUserProfilePreference("download.default_directory",_iglobalProperties.DownloadedLocation);
            return options;
        }

        public bool IsApplicable(Browsers browsers)
        {
            switch (browsers)
            {
                case Browsers.chrome:
                case Browsers.remotechrome:
                    return true;
                default:
                    return false;
            }
        }
    }
}
