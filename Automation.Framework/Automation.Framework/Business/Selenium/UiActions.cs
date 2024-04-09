using Automation.Framework.Core.CustomException;
using Automation.Framework.Core.WebAbstractions;
using System;

namespace Automation.Framework.Business.Selenium
{
    public class UiActions : IUiActions
    {
        ITestBaseManager _itestBaseManager;
        ILogging _ilogging;
        public UiActions(ITestBaseManager itestBaseManager)
        {
            _itestBaseManager = itestBaseManager;
        }

        public void NavigateToUrl(ITestSteps itestSteps)
        {
            try
            {
                _itestBaseManager.GetUiTestBase().GetWebDriver().Navigate().GoToUrl(itestSteps.GetParameter(0));
            }
            catch (Exception e)
            {
                _ilogging.Error("Error while navigating to url " + itestSteps.GetParameter(0));
                throw new AutomationException("Error while navigating to url " + itestSteps.GetParameter(0));
            }
        }
    }
}
