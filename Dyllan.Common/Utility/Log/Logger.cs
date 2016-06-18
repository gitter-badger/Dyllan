using Dyllan.Common.Config;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Text;
using System.Threading;

namespace Dyllan.Common.Utility
{
    public class Logger : AbstractLogger
    {
        #region fields

        private Thread worker;
        public ConcurrentQueue<LogInfo> tasks = new ConcurrentQueue<LogInfo>();
        private object fileLocker = new object();
        private object signalLocker = new object();
        public bool isProcessing = true;

        #endregion

        #region Constructors

        public Logger() : this(Constant.DefaultLogFileName) { }

        public Logger(string fileName) : base(fileName) { DoInitial(); }

        #endregion

        #region Private Methods

        private void DoInitial()
        {
            worker = new Thread(DoLog);
            worker.IsBackground = true;
            worker.Start();
        }

        private void Log(LogInfo logInfo)
        {
            if (logInfo != null)
            {
                lock (signalLocker)
                {
                    tasks.Enqueue(logInfo);
                    Monitor.Pulse(signalLocker);
                }
            }
        }

        private void DoLog()
        {
            while (true)
            {
                LogInfo logInfo = null;
                try
                {
                    if (tasks.TryDequeue(out logInfo))
                    {
                        isProcessing = true;
                        LogToFile(logInfo);
                    }
                    else
                    {
                        lock (signalLocker)
                        {
                            isProcessing = false;
                            Monitor.Wait(signalLocker);
                        }
                    }
                }
                catch (ThreadAbortException)
                {
                    throw;
                }
                catch (SecurityException secEx)
                {
                    WriteToWindowsEvent(secEx.ToString(), EventLogEntryType.Error);
                    throw;
                }
                catch (UnauthorizedAccessException unEx)
                {
                    WriteToWindowsEvent(unEx.ToString(), EventLogEntryType.Error);
                    throw;
                }
                catch (Exception ex)
                {
                    Log(logInfo);
                    WriteToWindowsEvent(ex.ToString(), EventLogEntryType.Error);
                }
            }
        }

        private void LogToFile(LogInfo logInfo)
        {
            lock (fileLocker)
            {
                using (FileStream fs = new FileStream(FileName, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                    {
                        sw.WriteLine(logInfo.ToString());
                    }
                }
            }

            if (LogConfig.LogInEvent)
            {
                WriteToWindowsEvent(logInfo.ToString(), MapEventLogEntryType(logInfo.LogLevel));
            }
        }

        private EventLogEntryType MapEventLogEntryType(LogLevel loglevel)
        {
            EventLogEntryType eventType = EventLogEntryType.Information;

            switch (loglevel)
            {
                case LogLevel.Error:
                    eventType = EventLogEntryType.Error;
                    break;
                case LogLevel.Info:
                    eventType = EventLogEntryType.Information;
                    break;
                case LogLevel.Warning:
                    eventType = EventLogEntryType.Warning;
                    break;
                default:
                    eventType = EventLogEntryType.Information;
                    break;
            }

            return eventType;
        }

        private void WriteToWindowsEvent(string msg, EventLogEntryType type)
        {
            if (ProcessHelper.IsAdministratorPermission)
            {
                ProcessHelper.EventLog.WriteEntry(msg, type);
            }
        }

        #endregion Private Methods

        #region Implement base class

        public override void Log(LogLevel logLevel, Exception ex)
        {
            if (ex != null && logLevel >= LogConfig.LogLevel)
            {
                LogInfo logInfo = new LogInfo(DateTime.Now, ex.ToString(), logLevel);
                Log(logInfo);
            }
        }

        public override void Log(LogLevel logLevel, string infor)
        {
            if (!string.IsNullOrEmpty(infor) && logLevel >= LogConfig.LogLevel)
            {
                LogInfo logInfo = new LogInfo(DateTime.Now, infor, logLevel);
                Log(logInfo);
            }
        }
        #endregion

        #region Properties

        public bool IsCompleted
        {
            get
            {
                return tasks.Count == 0 && !isProcessing;
            }
        }

        #endregion
    }
}
