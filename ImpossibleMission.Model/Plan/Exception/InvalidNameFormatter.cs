using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model.Model
{
    public class InvalidNameFormatter: Exception
    {
        public InvalidNameFormatter() : base(string.Format("Invalid Name Formatter"))
        { }
    }
}
