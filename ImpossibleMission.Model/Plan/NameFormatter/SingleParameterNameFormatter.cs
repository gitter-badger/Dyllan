using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public class SingleParameterNameArgs : FormatterArgs
    {
        public SingleParameterNameArgs(int count) : base(count) { }

        private int startValue = 1;
        private int incrementValue = 1;
        private string prefixValue = string.Empty;
        private string postfixValue = string.Empty;
        public int StartValue
        {
            get
            {
                return startValue;
            }
            set
            {
                startValue = value;
            }
        }

        public int IncrementValue
        {
            get
            {
                return incrementValue;
            }

            set
            {
                incrementValue = value;
            }
        }

        public string PrefixValue
        {
            get
            {
                return prefixValue;
            }

            set
            {
                prefixValue = value;
            }
        }

        public string PostfixValue
        {
            get
            {
                return postfixValue;
            }

            set
            {
                postfixValue = value;
            }
        }
    }
    public class SingleParameterNameFormatter : NameFormatter
    {
        private SingleParameterNameFormatter()
            : base("{0}{1}{2}")
        {
        }

        private static SingleParameterNameFormatter _instance = new SingleParameterNameFormatter();
        public static SingleParameterNameFormatter Instance
        {
            get
            {
                return _instance;
            }
        }

        public override IEnumerable<string> Format(FormatterArgs args)
        {
            List<string> result = new List<string>();

            SingleParameterNameArgs sArgs = args as SingleParameterNameArgs;
            if (sArgs != null && args.Count > 0)
            {
                for (int i = 0; i < args.Count; i++)
                    yield return string.Format(_formatter, sArgs.PrefixValue, sArgs.StartValue + (sArgs.IncrementValue * i), sArgs.PostfixValue);
            }
        }
    }
}
