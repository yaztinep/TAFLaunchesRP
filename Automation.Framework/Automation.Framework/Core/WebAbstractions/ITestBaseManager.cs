using Automation.Framework.Business.Test.Base;

namespace Automation.Framework.Core.WebAbstractions
{
    public interface ITestBaseManager
    {
        void SetTestBase(TestBase testBase);

        TestBase GetTestBase();

        UiTestBase GetUiTestBase();
    }
}
