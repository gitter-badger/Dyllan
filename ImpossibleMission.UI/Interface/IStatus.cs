using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission
{
    public enum MessageType
    {
        Information,
        Success,
        Error,
        Warn,
        Verbose
    }

    public class OutPutMessage
    {
        public DateTime Time
        {
            get;
            set;
        }
        public MessageType MessageType
        {
            get;
            set;
        }
        public string Message
        {
            get;
            set;
        }
    }

    public interface IStatus
    {
        List<OutPutMessage> Status
        {
            get;
        }

        void PropertyChanged(string propertyName, object value);
    }
}
