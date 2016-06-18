using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dyllan.Common;

namespace Dyllan.Common.Config
{
    [Serializable]
    internal static class LogConfig
    {
        private const string SleepIntervalKey = "SleepInterval";
        private const string LogLevelKey = "LogLevel";
        private const string LogInEventKey = "LogInEvent";

        private static int? sleepInterval;
        private static LogLevel? logLevel;
        private static bool? logInEvent;

        public static int SleepInterval
        {
            get 
            {
                if (!sleepInterval.HasValue)
                {
                    sleepInterval = AppSettingHelper.GetInteger(SleepIntervalKey, 10 * 1000);
                }

                return sleepInterval.Value; 
            }
        }

        public static LogLevel LogLevel
        {
            get
            {
                if (!logLevel.HasValue)
                {
                    logLevel = AppSettingHelper.GetEnum<LogLevel>(LogLevelKey, LogLevel.Info);
                }

                return logLevel.Value;
            }
        }

        public static bool LogInEvent
        {
            get
            {
                if (!logInEvent.HasValue)
                {
                    logInEvent = AppSettingHelper.GetBoolean(LogInEventKey, false);
                }
                return logInEvent.Value;
            }
        }
    }
}
