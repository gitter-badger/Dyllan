using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public abstract class FormatterArgs
    {
        public FormatterArgs(int count)
        {
            this.count = count;
        }

        private readonly int count = 1;

        public int Count
        {
            get
            {
                return count;
            }
        }
    }

    public abstract class NameFormatter
    {
        protected readonly string _formatter;
        public string Formatter
        {
            get
            {
                return _formatter;
            }
        }
        public NameFormatter(string formatter)
        {
            _formatter = formatter;
        }

        public abstract IEnumerable<string> Format(FormatterArgs args);
    }
}
