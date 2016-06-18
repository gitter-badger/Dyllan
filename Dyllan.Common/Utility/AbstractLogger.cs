using System;
using System.IO;
using System.Threading;

using Dyllan.Common.Config;

namespace Dyllan.Common.Utility
{
    public abstract class AbstractLogger : AbstractFile
    {
        #region Fields

        private readonly string name;
        private readonly string fileNameWithoutExtension;
        private readonly string extension;
        private readonly string directoryName;
        private bool autoCheckFileSize = true;
        private int postFix = 0;
        
        #endregion

        #region class

        public class LogInfo
        {
            private readonly string msg;
            private readonly LogLevel logLevel;
            private DateTime dateTime;
            private int threadId;

            public LogInfo(DateTime dateTime, string msg, LogLevel logLevel)
            {
                this.dateTime = dateTime;
                this.msg = msg;
                this.logLevel = logLevel;
                threadId = Thread.CurrentThread.ManagedThreadId;
            }

            public string Message
            {
                get { return msg; }
            }

            public LogLevel LogLevel
            {
                get { return logLevel; }
            }

            public DateTime DateTime
            {
                get { return dateTime; }
            }

            public override string ToString()
            {
                return string.Format("{0}:[ThreadID {4}][{1}]{2}{3}", dateTime, logLevel.ToString(), msg, Environment.NewLine, threadId);
            }
        }

        #endregion

        #region constructors

        public AbstractLogger(string fileName) : base(fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            extension = fileInfo.Extension;
            name = fileInfo.Name;
            directoryName = fileInfo.DirectoryName;
            fileNameWithoutExtension = name.Substring(0, name.LastIndexOf(extension));
        }

        #endregion

        public void Log(Exception ex)
        {
            Log(LogLevel.Error, ex);
        }

        public void Log(string information)
        {
            Log(LogLevel.Info, information);
        }

        public abstract void Log(LogLevel logLevel, Exception ex);

        public abstract void Log(LogLevel logLevel, string infor);

        private void CheckFileSize()
        {
            bool reCheck = false;
            if (CheckFileExistOrCreate(fileName))
            {
                FileInfo fileInfo = new FileInfo(fileName);

                checked
                {
                    if ((int)(fileInfo.Length / 1024 / 1024) > FileConfig.MaxFileSize)
                    {
                        postFix++;
                        fileName = Path.Combine(directoryName, fileNameWithoutExtension, postFix.ToString());
                        reCheck = true;
                    }
                }
            }

            if (reCheck)
            {
                CheckFileSize();
            }
        }
    }
}
