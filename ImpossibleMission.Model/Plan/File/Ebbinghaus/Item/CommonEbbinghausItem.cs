using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public class CommonEbbinghausItem : EbbinghausItem
    {
        public CommonEbbinghausItem(DateTime executeTime, string name, Guid planId)
            :base(executeTime, name, planId)
        {
            _ebbinghaus = CommonEbbinghausTemplate.Instance;
        }

        public CommonEbbinghausItem(Guid id, DateTime executeTime, string name, Guid planId, ProgressStatusEnum progressStatus, int score, TimeSpan costTime)
            :base(id, executeTime, name, planId, progressStatus, costTime)
        {
            _score = score;
            _ebbinghaus = CommonEbbinghausTemplate.Instance;
        }

        private int _score;

        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
            }
        }

        public DateTime LastReviewDate
        {
            get
            {
                return _executeDate.AddDays(_ebbinghaus.Periods[_ebbinghaus.Periods.Count - 1]);
            }
        }
    }
}
