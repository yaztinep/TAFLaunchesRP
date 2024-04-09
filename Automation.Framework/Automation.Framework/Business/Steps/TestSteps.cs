using Automation.Framework.Core.WebAbstractions;
using System;
using System.Collections.Generic;

namespace Automation.Framework.Business.Steps
{

    public class TestSteps : ITestSteps
    {
        List<string> _parameters;

        IUiElement _iuielement;
        IVariableReplacer _ivariableReplacer;
        public TestSteps(IVariableReplacer ivariableReplacer)
        {
            _ivariableReplacer = ivariableReplacer;
            _parameters = new List<string>();
        }

        public void SetParameters(List<string> parameters)
        {
            _parameters = parameters;
        }

        public string GetParameter(int index)
        {
            return _parameters[index];
        }
        public void SetUiObject(IUiElement iuiElement)
        {
            _iuielement = iuiElement;
        }

        public ITestSteps Run()
        {
            CheckVars();
            return this;
        }
        public void CheckVars()
        {
            if (_iuielement != null)
            {

            }
            for (int i = 0; i < _parameters.Count; i++)
            {
                string str = _ivariableReplacer.SetDataSet(_parameters[i], "<#", "#>").GetAllVariables().GetConfigValues();
                Console.WriteLine(str);
            }
        }
    }
}
