using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public abstract class DailyItemBuilder
    {
        protected DailyItem _dailyItem;
        public DailyItem DailyItem
        {
            get
            {
                return _dailyItem;
            }
        }

        public abstract DailyItem CreateDailyItem(Guid id, DateTime executeTime, string name, Guid planId, 
            ProgressStatusEnum progressStatus, TimeSpan costTime);
    }
}
