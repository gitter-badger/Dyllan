using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyllan.Common
{
    public sealed class Constant
    {
        private Constant() { }

        public const char Slash = '/';
        public const char BackSlash = '\\';
        public const string DefaultLogFileName = "Log.txt";
        public static readonly char[] InvalidFileNameCharacters = new char[] { '/', '\\', '*', '?', ':', '>', '<', '|'};
    }
}
