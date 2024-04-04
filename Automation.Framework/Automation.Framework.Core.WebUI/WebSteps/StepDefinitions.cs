using Automation.Framework.Core.WebUI.DIContainer;
using Automation.Framework.Core.WebUI.Runner;
using Automation.Framework.Core.WebUI.WebAbstractions;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Automation.Framework.Core.WebUI.WebSteps
{
    [Binding]
    public class StepDefinitions
    {
        ITestBaseManager _itestBaseManager;
        ILogging _ilogging;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _itestBaseManager = SpecflowRunner._iserviceProvider.GetRequiredService<ITestBaseManager>();
            _ilogging = SpecflowRunner._iserviceProvider.GetRequiredService<ILogging>();
        }

        [Given(@"User is on the login page")]
        public void GivenUserIsOnTheLoginPage()
        {
            Console.WriteLine("Hello to login page");
        }

        [Given(@"I am on the page ""([^""]*)""")]
        public void GivenIAmOnThePage(string url)
        {
            _itestBaseManager.GetUiTestBase().GetWebDriver().Navigate().GoToUrl(url);
            _ilogging.Debug("Url: " + url);
        }

        [When(@"I save the value ""([^""]*)"" with key ""([^""]*)""")]
        public void WhenISaveTheValueWithKey(string value, string key)
        {
            _itestBaseManager.GetTestBase().SetDataSet(value, key);
            _ilogging.Debug("Key: " + key + " value: " + value);
        }

        [When(@"I provide ""([^""]*)"" to locator ""([^""]*)""")]
        public void WhenIProvideToLocator(string value, string locator)
        {
            _itestBaseManager.GetUiTestBase().GetWebDriver().FindElement(By.XPath(locator)).SendKeys(value);
        }

        [When(@"I click object ""([^""]*)""")]
        public void WhenIClickObject(string locator)
        {
            _itestBaseManager.GetUiTestBase().GetWebDriver().FindElement(By.XPath(locator)).Click();
        }

        [When(@"I fetch value of key ""([^""]*)"" and enter to locator ""([^""]*)""")]
        public void WhenIFetchValueOfKeyAndEnterToLocator(string key, string locator)
        {
            string str = _itestBaseManager.GetTestBase().GetDataSet(key);
            _itestBaseManager.GetUiTestBase().GetWebDriver().FindElement(By.XPath(locator)).SendKeys(str);
            _ilogging.Debug("Key: " + key + " fetched value: " + str);
        }

    }
}
