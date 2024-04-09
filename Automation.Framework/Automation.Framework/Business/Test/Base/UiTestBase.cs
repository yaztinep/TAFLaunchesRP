using Automation.Framework.Core.WebAbstractions;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Automation.Framework.Business.Test.Base
{
    public class UiTestBase : TestBase, IUiTestBase
    {
        IDefaultVariables _idefaultVariables;
        IGlobalProperties _iglobalProperties;
        IBrowserType _ibrowserType;
        IEnumerable<IBrowserProfiles> _ibrowserProfiles;
        IEnumerable<IDriver> _idriver;
        IWebDriver _iwebDriver;
        public UiTestBase(IDefaultVariables idefaultVariables, IGlobalProperties iglobalProperties
            , IBrowserType ibrowserType, IEnumerable<IBrowserProfiles> ibrowserProfiles
            , IEnumerable<IDriver> idriver)
        {
            _idefaultVariables = idefaultVariables;
            _iglobalProperties = iglobalProperties;
            _ibrowserType = ibrowserType;
            _ibrowserProfiles = ibrowserProfiles;
            _idriver = idriver;
        }

        public IWebDriver GetWebDriver()
        {
            if (_iwebDriver == null)
            {
                GetNewWebDriver();
            }
            return _iwebDriver;
        }
        private void GetNewWebDriver()
        {
            DriverOptions driverOptions = null;

            foreach (var driver in _idriver)
            {
                if (driver.IsApplicable(_ibrowserType.GetBrowser(_iglobalProperties.BrowserType.ToLower())))
                {
                    foreach (var profile in _ibrowserProfiles)
                    {
                        if (profile.IsApplicable(_ibrowserType.GetBrowser(_iglobalProperties.BrowserType.ToLower())))
                        {
                            driverOptions = profile.GetBrowserProfile();
                            break;
                        }
                    }
                    _iwebDriver = driver.GetWebDriver(driverOptions);
                    break;
                }
            }
        }
    }
}
