using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public class CommonEbbItemBuilder : DailyItemBuilder
    {
        private int _score = 0;
        public CommonEbbItemBuilder(int score)
        {
            _score = score;
        }
        
        public override DailyItem CreateDailyItem(Guid id, DateTime executeTime, string name, Guid planId, 
            ProgressStatusEnum progressStatus, TimeSpan costTime)
        {
            _dailyItem = new CommonEbbinghausItem(id, executeTime, name, planId, progressStatus, _score, costTime);
            return _dailyItem;
        }
    }
}
