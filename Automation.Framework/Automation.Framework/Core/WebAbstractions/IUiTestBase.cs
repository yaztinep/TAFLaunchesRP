﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebAbstractions
{
    public interface IUiTestBase
    {
        IWebDriver GetWebDriver();
    }
}
