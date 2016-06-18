using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ImpossibleMission
{
   public sealed class Constance
    {
        public const string NUMBER = "[0-9]+";
        private static Regex _numberRegex;
        public const string PLACEHOLDER = "{0}";

        public static Regex NumberRegex
        {
            get
            {
                if (_numberRegex == null)
                {
                    _numberRegex = new Regex(Constance.NUMBER);
                }
                return _numberRegex;
            }
        }
    }
}
