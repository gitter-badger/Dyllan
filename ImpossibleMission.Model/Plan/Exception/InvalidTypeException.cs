using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public class InvalidTypeException : Exception
    {
        public InvalidTypeException(Type expectedType, Type actualType)
            : base (string.Format("Expected type is {0}, however, actual type is {1}", expectedType.FullName, actualType.FullName))
        {
        }
    }
}
