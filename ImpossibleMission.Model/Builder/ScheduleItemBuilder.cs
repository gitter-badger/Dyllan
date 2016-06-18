using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public class ScheduleItemBuilder : DailyItemBuilder
    {
        private int _currentIndex;
        private readonly string _note;

        public ScheduleItemBuilder(int currentIndex, string note)
        {
            _currentIndex = currentIndex;
            _note = note;
        }

        public override DailyItem CreateDailyItem(Guid id, DateTime executeTime, string name, Guid planId, ProgressStatusEnum progressStatus, TimeSpan costTime)
        {
            _dailyItem = new ScheduleItem(_currentIndex, id, name, executeTime, planId, progressStatus, _note, costTime);
            return _dailyItem;
        }
    }
}
