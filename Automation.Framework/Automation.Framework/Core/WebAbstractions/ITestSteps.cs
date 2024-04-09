using System.Collections.Generic;

namespace Automation.Framework.Core.WebAbstractions
{
    public interface ITestSteps
    {
        void SetParameters(List<string> parameters);
        string GetParameter(int index);
        void SetUiObject(IUiElement iuiElement);
        ITestSteps Run();
    }
}
