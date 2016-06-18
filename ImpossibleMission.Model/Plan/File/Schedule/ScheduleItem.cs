using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public class ScheduleItem : DailyItem
    {
        public int _currentIndex;
        public int CurrentIndex
        {
            get
            {
                return _currentIndex;
            }
            set
            {
                _currentIndex = value;
            }
        }

        public string Note { get; set; }

        public ScheduleItem(int currentIndex, string name, Guid planId)
            : this(currentIndex, Guid.NewGuid(), name, DateTime.Now, planId, ProgressStatusEnum.Completed, null, TimeSpan.Zero)
        {
        }

        public ScheduleItem(int currentIndex, Guid id, string name, DateTime executeDate, Guid planId, ProgressStatusEnum progressStatus, string note, TimeSpan costTime)
        {
            this._currentIndex = currentIndex;
            this._id = id;
            this._name = name;
            this._executeDate = executeDate;
            this._planID = planId;
            this._progressStatus = progressStatus;
            Note = note;
            this._costTime = costTime;
        }

        public override void Refresh()
        {

        }
    }
}
