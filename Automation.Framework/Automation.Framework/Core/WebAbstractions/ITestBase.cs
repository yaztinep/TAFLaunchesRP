using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.Framework.Core.WebAbstractions
{
    public interface ITestBase
    {
        void SetContext(FeatureContext featureContext);
        FeatureContext GetContext();
        void SetDataSet(string key, string value);
        string GetDataSet(string key);
        void SetExtent(IExtentFeatureReport extentFeatureReport);
        IExtentFeatureReport GetExtentFeatureReport();
    }
}
