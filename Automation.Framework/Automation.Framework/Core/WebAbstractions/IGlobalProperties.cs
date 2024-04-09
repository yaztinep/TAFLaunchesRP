using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebAbstractions
{
    public interface IGlobalProperties
    {
        string DownloadedLocation
        {
            get;
        }

        string GridHubUrl
        {
            get;
        }

        string BrowserType
        {
            get;
        }

        string GetProperty(string key);
    }
}
