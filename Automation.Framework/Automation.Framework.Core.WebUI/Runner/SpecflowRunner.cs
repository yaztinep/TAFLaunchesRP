using Automation.Framework.Core.WebUI.DIContainer;
using Automation.Framework.Core.WebUI.Params;
using Automation.Framework.Core.WebUI.Test.Base;
using Automation.Framework.Core.WebUI.WebAbstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.Framework.Core.WebUI.Runner
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
