using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyllan.Common
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class TableTypeAttribute : Attribute
    {
        private readonly string _tableName;
        public string TableName
        {
            get
            {
                return _tableName;
            }
        }
        public TableTypeAttribute(string tableName)
        {
            _tableName = tableName;
        }
    }
}
