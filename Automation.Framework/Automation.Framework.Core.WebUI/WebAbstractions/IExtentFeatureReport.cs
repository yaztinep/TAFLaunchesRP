using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.WebAbstractions
{
    public interface IExtentFeatureReport
    {
        void CreateFeature(string feature);
        void CreateScenario(string scenario);
        void Error(string message, string base64);
        void Information(string message, string base64);
        void Warning(string message, string base64);
        void Fail(string message, string base64);
        void Pass(string message, string base64);
    }
}
