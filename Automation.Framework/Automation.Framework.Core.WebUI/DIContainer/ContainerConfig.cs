using Automation.Framework.Core.WebUI.Params;
using Automation.Framework.Core.WebUI.Reporting;
using Automation.Framework.Core.WebUI.Selenium.BrowserProfiles;
using Automation.Framework.Core.WebUI.Selenium.WebDrivers.LocalWebDriver;
using Automation.Framework.Core.WebUI.Selenium.WebDrivers.RemoteDriver;
using Automation.Framework.Core.WebUI.Test.Base;
using Automation.Framework.Core.WebUI.Test.Type;
using Automation.Framework.Core.WebUI.WebAbstractions;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium.Chrome;
using System;

namespace Automation.Framework.Core.WebUI.DIContainer
{
    public class ContainerConfig
    {
        public static IServiceProvider ConfigureService()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IDefaultVariables, DefaultVariables>();
            serviceCollection.AddSingleton<ILogging, Logging>();
            serviceCollection.AddSingleton<IGlobalProperties, GlobalProperties>();
            serviceCollection.AddSingleton<IExtentReport, ExtentReport>();
            serviceCollection.AddTransient<IUiTestBase,UiTestBase>();
            serviceCollection.AddTransient<ITestBase,TestBase>();
            serviceCollection.AddTransient<ITestBaseManager, TestBaseManager>();
            serviceCollection.AddTransient<IBrowserType, BrowserType>();
            serviceCollection.AddTransient<IBrowserProfiles, ChromeProfiles>();
            serviceCollection.AddTransient<IBrowserProfiles, FirefoxProfiles>();
            serviceCollection.AddTransient<IDriver, ChromeWebDriver>();
            serviceCollection.AddTransient<IDriver, FirefoxWebDriver>();
            serviceCollection.AddTransient<IDriver, RemoteDriver>();
            serviceCollection.AddTransient<IExtentFeatureReport, ExtentFeatureReport>();
            return serviceCollection.BuildServiceProvider();
        }
    }
}
