﻿using Automation.Framework.Core.WebAbstractions;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.Selenium.BrowserProfiles
{
    public class FirefoxProfiles : IBrowserProfiles
    {
        IGlobalProperties _iglobalProperties;
        public FirefoxProfiles(IGlobalProperties iglobalProperties)
        {
            _iglobalProperties = iglobalProperties;
        }

        public DriverOptions GetBrowserProfile()
        {
            var options = new FirefoxOptions();
            options.AcceptInsecureCertificates = true;
            options.SetPreference("network.http.phishy-userpass-length", 255);
            options.SetPreference("network.automatic-ntlm-auth.allow-non-fqdn", true);
            options.SetPreference("network.negotiate-auth.allow-non-fqdn", true);
            options.SetPreference("browser.tabs.remote.autostart", false);
            options.SetPreference("browser.tabs.remote.autostart.1", false);
            options.SetPreference("browser.tabs.remote.autostart.2", false);
            options.SetPreference("browser.tabs.remote.force-enable", "false");
            options.SetPreference("browser.download.folderList", 2);
            options.SetPreference("browser.helperApps.alwaysAsk.force", false);
            options.SetPreference("browser.download.manager.showWhenStarting", false);
            options.SetPreference("browser.download.useDownloadDir", true);
            options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            options.SetPreference("browser.download.manager.alertOnEXEOpen", false);
            options.SetPreference("browser.download.manager.focusWhenStarting", false);
            options.SetPreference("browser.download.manager.useWindow", false);
            options.SetPreference("browser.download.manager.showAlertOnComplete", false);
            options.SetPreference("browser.download.manager.closeWhenDone", true);
            options.SetPreference("browser.download.dir", _iglobalProperties.DownloadedLocation);
            return options;

        }

        public bool IsApplicable(Browsers browsers)
        {
            switch (browsers)
            {
                case Browsers.firefox:
                case Browsers.remotefirefox:
                    return true;
                default:
                    return false;
            }
        }
    }
}
