using Automation.Framework.Core.WebAbstractions;
using System.Threading;

namespace Automation.Framework.Business.Test.Base
{
    public class TestBaseManager : ITestBaseManager
    {
        private static ThreadLocal<TestBase> _testBase = new ThreadLocal<TestBase>();

        public void SetTestBase(TestBase testBase)
        {
            _testBase.Value = testBase;
        }

        public TestBase GetTestBase()
        {
            return _testBase.Value;
        }

        public UiTestBase GetUiTestBase()
        {
            return (UiTestBase)_testBase.Value;
        }
    }
}
