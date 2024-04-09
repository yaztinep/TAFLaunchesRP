using Automation.Framework.Business.Steps;

namespace Automation.Framework.Core.WebAbstractions
{
    public interface IVariableReplacer
    {
        VariableReplacer SetDataSet(string value, string startIndicator, string endIndicator);
        VariableReplacer GetAllVariables();
    }
}
