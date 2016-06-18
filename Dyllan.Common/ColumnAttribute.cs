using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyllan.Common
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        private readonly string _columnName;
        public string ColumnName
        {
            get
            {
                return _columnName;
            }
        }

        public ColumnAttribute(string columnName)
        {
            _columnName = columnName;
        }
    }
}
