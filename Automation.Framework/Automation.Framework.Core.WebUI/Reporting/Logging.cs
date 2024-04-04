using Automation.Framework.Core.WebUI.Params;
using Automation.Framework.Core.WebUI.WebAbstractions;
using Serilog;
using Serilog.Core;
using System;

namespace Automation.Framework.Core.WebUI.Reporting
{
    public class Logging : ILogging
    {
        LoggingLevelSwitch _loggingLevelSwitch;
        IDefaultVariables _idefaultVariables;
        public Logging(IDefaultVariables idefaultVariables) 
        {
            _idefaultVariables = idefaultVariables;
            _loggingLevelSwitch = new LoggingLevelSwitch(Serilog.Events.LogEventLevel.Debug);
            Log.Logger = new LoggerConfiguration().MinimumLevel.ControlledBy(_loggingLevelSwitch)
                .WriteTo.File(_idefaultVariables.Log
                    , outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .Enrich.WithThreadId().CreateLogger();
        }

        public void SetLogLevel(string loglevel) 
        {
            switch (loglevel.ToLower()) 
            {
                case "debug":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Debug;
                    break;

                case "error":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Error;
                    break;

                case "information":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Information;
                    break;

                case "fatal":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Fatal;
                    break;

                default:
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Debug;
                    break;
            }
        }

        public void Debug (string message) 
        {
            Log.Debug(message);
        }

        public void Error(string message)
        {
            Log.Error(message);
        }

        public void Warning(string message)
        {
            Log.Warning(message);
        }

        public void Information(string message)
        {
            Log.Information(message);
        }
    }
}
