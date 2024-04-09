using Automation.Framework.Business.Selenium;
using Automation.Framework.Business.Steps;
using Automation.Framework.Business.Test.Base;
using Automation.Framework.Business.Test.Type;
using Automation.Framework.Business.UiObject;
using Automation.Framework.Core.Params;
using Automation.Framework.Core.Reporting;
using Automation.Framework.Core.Selenium.BrowserProfiles;
using Automation.Framework.Core.Selenium.WebDrivers.LocalWebDriver;
using Automation.Framework.Core.Selenium.WebDrivers.RemoteDriver;
using Automation.Framework.Core.WebAbstractions;
using Automation.Framework.Core.Selenium;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium.Chrome;
using System;

namespace Automation.Framework.Core.DIContainer
{
    public class ContainerConfig
    {
        public static IServiceCollection serviceCollection;
        public static IServiceProvider ConfigureService()
        {
            serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IDefaultVariables, DefaultVariables>();
            serviceCollection.AddSingleton<ILogging, Logging>();
            serviceCollection.AddSingleton<IGlobalProperties, GlobalProperties>();
            serviceCollection.AddSingleton<IExtentReport, ExtentReport>();
            serviceCollection.AddTransient<IUiTestBase, UiTestBase>();
            serviceCollection.AddTransient<ITestBase, TestBase>();
            serviceCollection.AddTransient<ITestBaseManager, TestBaseManager>();
            serviceCollection.AddTransient<IBrowserType, BrowserType>();
            serviceCollection.AddTransient<IBrowserProfiles, ChromeProfiles>();
            serviceCollection.AddTransient<IBrowserProfiles, FirefoxProfiles>();
            serviceCollection.AddTransient<IDriver, ChromeWebDriver>();
            serviceCollection.AddTransient<IDriver, FirefoxWebDriver>();
            serviceCollection.AddTransient<IDriver, RemoteDriver>();
            serviceCollection.AddTransient<IUiElement, UiElement>();
            serviceCollection.AddTransient<IUiElementBuilder, UiElementBuilder>();
            serviceCollection.AddTransient<ITestSteps, TestSteps>();
            serviceCollection.AddTransient<ITestStepBuilder, TestStepBuilder>();
            serviceCollection.AddTransient<IVariableReplacer, VariableReplacer>();
            serviceCollection.AddTransient<IUiActions, UiActions>();
            serviceCollection.AddSingleton<IExtentFeatureReport, ExtentFeatureReport>();
            return serviceCollection.BuildServiceProvider();
        }
    }
}
