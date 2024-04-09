using Automation.Framework.Business.Test.Base;
using Automation.Framework.Core.DIContainer;
using Automation.Framework.Core.WebAbstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using TechTalk.SpecFlow;

namespace Automation.Framework.Core.Runner
{
    [Binding]
    public class SpecflowRunner
    {
        public static IServiceProvider _iserviceProvider;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _iserviceProvider = ContainerConfig.ConfigureService();
            _iserviceProvider.GetRequiredService<IGlobalProperties>();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            UiTestBase uiTestBase = (UiTestBase)_iserviceProvider.GetRequiredService<IUiTestBase>();
            uiTestBase.SetContext(featureContext);

            ITestBaseManager itestBaseManager = _iserviceProvider.GetRequiredService<ITestBaseManager>();
            itestBaseManager.SetTestBase(uiTestBase);

            IExtentFeatureReport iextentFeatureReport = _iserviceProvider.GetRequiredService<IExtentFeatureReport>();
            itestBaseManager.GetTestBase().SetExtent(iextentFeatureReport);
        }
    }
}
