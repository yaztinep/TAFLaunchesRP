using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.WebAbstractions
{
    public interface ILogging
    {
        void Debug(string message);

        void Error(string message);

        void Warning(string message);

        void Information(string message);

        void SetLogLevel(string loglevel);

    }
}
