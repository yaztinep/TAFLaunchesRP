using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.WebAbstractions
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
    }
}
