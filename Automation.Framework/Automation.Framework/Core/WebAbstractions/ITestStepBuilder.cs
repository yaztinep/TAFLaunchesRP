using Automation.Framework.Business.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebAbstractions
{
    public interface ITestStepBuilder
    {
        TestStepBuilder SetParams(params string[] param);

        TestStepBuilder SetUiElement(IUiElement iuiElement);

        ITestSteps Build();
    }
}
