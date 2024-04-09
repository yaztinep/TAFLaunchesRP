using Automation.Framework.Core.Runner;
using TechTalk.SpecFlow;
using Automation.Framework.Core.WebAbstractions;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;

namespace Automation.Framework.Business.WebSteps
{
    [Binding]
    public class SpecflowBase
    {
        ScenarioContext _scenarioContext;
        ITestBaseManager _itestBaseManager;

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _itestBaseManager = SpecflowRunner._iserviceProvider.GetRequiredService<ITestBaseManager>();
            _itestBaseManager.GetTestBase().GetExtentFeatureReport().CreateScenario(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            IExtentReport iextentReport = SpecflowRunner._iserviceProvider.GetRequiredService<IExtentReport>();
            iextentReport.FlushExtentReport();
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            ITestBaseManager itestBaseManager = SpecflowRunner._iserviceProvider.GetRequiredService<ITestBaseManager>();
            string base64 = ((ITakesScreenshot)_itestBaseManager.GetUiTestBase().GetWebDriver()).GetScreenshot().AsBase64EncodedString;
            if (scenarioContext.TestError == null)
            {
                itestBaseManager.GetTestBase().GetExtentFeatureReport().Pass(scenarioContext.StepContext.StepInfo.Text, null);
            }
            else
            {
                itestBaseManager.GetTestBase().GetExtentFeatureReport().Fail(scenarioContext.StepContext.StepInfo.Text, base64);
            }
         
           
            
        }
    }
}
