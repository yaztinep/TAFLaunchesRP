using Automation.Framework.Core.WebAbstractions;
using System.Linq;

namespace Automation.Framework.Business.Steps
{
    public class TestStepBuilder : ITestStepBuilder
    {
        ITestSteps _itestSteps;

        public TestStepBuilder(ITestSteps itestSteps)
        {
            _itestSteps = itestSteps;
        }

        public TestStepBuilder SetParams(params string[] param)
        {
            _itestSteps.SetParameters(param.ToList());
            return this;
        }

        public TestStepBuilder SetUiElement(IUiElement iuiElement)
        {
            _itestSteps.SetUiObject(iuiElement);
            return this;
        }
        public ITestSteps Build()
        {
            return _itestSteps.Run();
        }
    }
}
