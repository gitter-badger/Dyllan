using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ImpossibleMission
{
   public sealed class Constant
    {
        public const string NUMBER = "[0-9]+";
        public const string FLOAT = "\\d*[.]?\\d*";
        private static Regex _numberRegex;
        private static Regex _floatRegex;
        public const string PLACEHOLDER = "{0}";

        public const string DateFormat = "yyyy-MM-dd";
        public const string LongTimeFormat = "yyyy-MM-dd HH:mm:ss";
        public const string DateFormat2 = "yyyy/MM/dd";
        public const string TimeFormat = @"hh\:mm\:ss";

        public static Regex NumberRegex
        {
            get
            {
                if (_numberRegex == null)
                {
                    _numberRegex = new Regex(NUMBER);
                }
                return _numberRegex;
            }
        }

        public static Regex FloatRegex
        {
            get
            {
                if (_floatRegex == null)
                {
                    _floatRegex = new Regex(FLOAT);
                }
                return _floatRegex;
            }
        }
    }
}
