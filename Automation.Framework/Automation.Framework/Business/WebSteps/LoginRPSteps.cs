using Automation.Framework.Core.Runner;
using Automation.Framework.Core.WebAbstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using TechTalk.SpecFlow;

namespace Automation.Framework.Business.WebSteps
{
    [Binding]
    public class LoginRPSteps
    {
        ITestBaseManager _itestBaseManager;
        ILogging _ilogging;
        IUiElementBuilder _iuiElementBuilder;
        ITestStepBuilder _itestStepBuilder;
        ITestSteps _itestSteps;
        IUiActions _iuiActions;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _itestBaseManager = SpecflowRunner._iserviceProvider.GetRequiredService<ITestBaseManager>();
            _ilogging = SpecflowRunner._iserviceProvider.GetRequiredService<ILogging>();
        }

        [BeforeStep]
        public void BeforeStep()
        {
            //_itestBaseManager = SpecflowRunner._iserviceProvider.GetRequiredService<ITestBaseManager>();
            _iuiElementBuilder = SpecflowRunner._iserviceProvider.GetRequiredService<IUiElementBuilder>();
            _itestStepBuilder = SpecflowRunner._iserviceProvider.GetRequiredService<ITestStepBuilder>();
            //_itestSteps = SpecflowRunner._iserviceProvider.GetRequiredService<ITestSteps>();
            _iuiActions = SpecflowRunner._iserviceProvider.GetRequiredService<IUiActions>();
        }

        [Given(@"Im on the login page ""(.*)""")]
        public void GivenImOnTheLoginPage(string url)
        {
            //_itestBaseManager.GetUiTestBase().GetWebDriver().Navigate().GoToUrl(url);
            _iuiActions.NavigateToUrl(_itestStepBuilder.SetParams(url).Build());
            _ilogging.Debug("Url: " + url);
        }

        [When(@"I enter the username ""(.*)""")]
        public void WhenIEnterTheUsername(string username)
        {
            //_itestStepBuilder.SetParams(username).SetUiElement(_iuiElementBuilder.BuildFromNames("//*[@id=\"app\"]/div/div/div/div/div[3]/div[1]/form/div[1]/div/div/div/input").Build()).Build();
        }

        [When(@"I enter the password ""([^""]*)""")]
        public void WhenIEnterThePassword(string username)
        {
            Console.WriteLine("Need to build");
        }

        [When(@"I click on the login button")]
        public void WhenIClickOnTheLoginButton()
        {
            //_iuiElementBuilder.BuildFromNames("locator");
        }

        [Then(@"I should be redirected to the home page")]
        public void ThenIShouldBeRedirectedToTheHomePage()
        {
            Console.WriteLine("Need to build");
        }

    }
}
