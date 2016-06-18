using Dyllan.Common.Config;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;

namespace Dyllan.Common.Utility
{
    public class TraceLogger : AbstractLogger
    {
        public TraceLogger(string fileName)
            : base(fileName)
        {
            worker = new Thread(DoLog);
            worker.IsBackground = true;
            worker.Start();

            Trace.AutoFlush = true;
            eventLog = new EventLog(AppDomain.CurrentDomain.FriendlyName);
        }

        private EventLog eventLog;
        private Thread worker;
        private ConcurrentQueue<LogInfo> tasks = new ConcurrentQueue<LogInfo>();

        public override void Log(LogLevel logLevel, Exception ex)
        {
            Trace.WriteLine((new LogInfo(DateTime.Now, ex.ToString(), logLevel)).ToString());
        }

        public override void Log(LogLevel logLevel, string infor)
        {
            Trace.WriteLine((new LogInfo(DateTime.Now, infor, logLevel)).ToString());
        }

        private void DoLog()
        {
            while (true)
            {
                try
                {
                    LogInfo logInfo;
                    if (tasks.TryDequeue(out logInfo))
                    {
                        TextWriterTraceListener listener = new TextWriterTraceListener(FileName);
                        Trace.Listeners.Add(listener);
                        Trace.WriteLine(logInfo.ToString());
                        Trace.Listeners.Remove(listener);
                    }
                    else
                    {
                        Thread.Sleep(LogConfig.SleepInterval);
                    }
                }
                catch (Exception ex)
                {
                    eventLog.WriteEntry(ex.ToString(), EventLogEntryType.Error);
                }
            }
        }
    }
}
