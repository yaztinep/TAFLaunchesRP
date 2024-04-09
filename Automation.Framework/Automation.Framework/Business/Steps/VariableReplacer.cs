using Automation.Framework.Core.WebAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Business.Steps
{
    public class VariableReplacer : IVariableReplacer
    {
        ITestBaseManager _itestBaseManager;
        ILogging _ilogging;
        IGlobalProperties _iglobalProperties;
        string _input;
        string _startIndicator;
        string _endIndicator;
        List<string> _dataVariables;
        public VariableReplacer(IGlobalProperties iglobalProperties, ILogging ilogging, ITestBaseManager itestBaseManager)
        {
            _itestBaseManager = itestBaseManager;
            _iglobalProperties = iglobalProperties;
            _ilogging = ilogging;
        }

        public VariableReplacer SetDataSet(string value, string startIndicator, string endIndicator)
        {
            _dataVariables = new List<string>();
            _input = value;
            _startIndicator = startIndicator;
            _endIndicator = endIndicator;
            return this;
        }

        public string GetConfigValues()
        {
            foreach (string param in _dataVariables)
            {
                _input = _input.Replace(_startIndicator + param + _endIndicator, _iglobalProperties.GetProperty(param));
            }
            return _input;
        }
        public VariableReplacer GetAllVariables()
        {
            for (int i = _input.IndexOf(_startIndicator, 0); i != -1 && _input.IndexOf(_startIndicator, i) >= 0
                                            && _input.IndexOf(_endIndicator, i) >= 0; i = _input.IndexOf(_endIndicator, i) + 1)
            {
                _dataVariables.Add(_input.Substring(_input.IndexOf(_startIndicator, i) + _startIndicator.Length
                                             , _input.IndexOf(_endIndicator, i) - (_input.IndexOf(_startIndicator, i) + _startIndicator.Length)));
            }
            return this;
        }
    }
}
