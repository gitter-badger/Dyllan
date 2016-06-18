using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyllan.Common
{
    public static class ParameterChecker
    {
        public static void CheckParameter(object @object, string parameterName)
        {
            if (@object == null)
            {
                if (string.IsNullOrEmpty(parameterName))
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    throw new ArgumentNullException(parameterName);
                }
            }
        }

        public static void CheckParameter(string str, string parameterName)
        {
            if (string.IsNullOrEmpty(str))
            {
                if (string.IsNullOrEmpty(parameterName))
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    throw new ArgumentNullException(parameterName);
                }
            }
        }

        public static void CheckCollection<T>(IEnumerable<T> collection, string parameterName)
        {
            CheckParameter(collection, parameterName);

            if (typeof(T).IsClass)
            {
                foreach (T item in collection)
                {
                    CheckParameter(item, parameterName);
                }
            }
        }
    }
}
