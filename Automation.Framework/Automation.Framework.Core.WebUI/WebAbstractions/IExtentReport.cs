﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.WebAbstractions
{
    public interface IExtentReport
    {
        void InitiliazeExtentReport();
        AventStack.ExtentReports.ExtentReports GetExtentReports();
        void FlushExtentReport();
    }
}
