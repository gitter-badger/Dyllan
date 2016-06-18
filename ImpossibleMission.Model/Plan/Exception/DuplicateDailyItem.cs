using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public class DuplicateDailyItemException : Exception
    {
        public DuplicateDailyItemException(string name) : base(string.Format("There already exists an item named {0} in current plan.", name))
        { }
    }
}
