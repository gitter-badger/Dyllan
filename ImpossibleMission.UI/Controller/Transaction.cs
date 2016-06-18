using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ImpossibleMission
{
    public abstract class Transaction : IStatus, ITransaction
    {
        private static List<OutPutMessage> _status = new List<OutPutMessage>();
        private static ReaderWriterLockSlim _locker = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        protected static Action<IStatus> StatusChanged;

        public static void RegisiterStatusChanged(Action<IStatus> statusChanged)
        {
            StatusChanged += statusChanged;
        }

        public static void UnRegisterStatusChanged(Action<IStatus> statusChanged)
        {
            StatusChanged -= statusChanged;
        }

        public static void ClearStatus()
        {
            _locker.EnterWriteLock();
            try
            {
                _status.Clear();
            }
            finally
            {
                _locker.ExitWriteLock();
            }
        }

        public List<OutPutMessage> Status
        {
            get
            {
                _locker.EnterReadLock();
                try
                {
                    return _status;
                }
                finally
                {
                    _locker.ExitReadLock();
                }
            }
        }

        protected void AddMessage(string msg, MessageType msgType)
        {
            if (string.IsNullOrEmpty(msg))
                return;
            _locker.EnterWriteLock();
            try
            {
                _status.Add(new OutPutMessage() { Time = DateTime.Now, MessageType = msgType, Message = msg});
            }
            finally
            {
                _locker.ExitWriteLock();
            }
            if (StatusChanged != null)
            {
                StatusChanged(this);
            }
        }

        public abstract void Execute();

        public void PropertyChanged(string propertyName, object value)
        {
        }
    }
}
