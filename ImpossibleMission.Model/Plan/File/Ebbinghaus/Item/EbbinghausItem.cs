using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public enum JobEnum
    {
        Learn,
        Review,
        NoOperation
    }

    public abstract class EbbinghausItem : DailyItem, IRefresh
    {
        protected EbbinghausTemplate _ebbinghaus;

        public EbbinghausItem(DateTime executeDate, string name, Guid planId)
            : this(Guid.NewGuid(), executeDate, name, planId, ProgressStatusEnum.NotStarted, TimeSpan.Zero)
        {
            Refresh();
        }

        public EbbinghausItem(Guid id, DateTime executeDate, string name, Guid planId, ProgressStatusEnum progressStatus, TimeSpan costTime)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            _id = id;
            _executeDate = executeDate;
            _name = name;
            _planID = planId;
            _progressStatus = progressStatus;
            _costTime = costTime;
        }

        internal EbbinghausTemplate Ebbinghaus
        {
            get
            {
                return _ebbinghaus;
            }
        }

        public JobEnum ItemType
        {
            get
            {
                if (IsEqualDate())
                    return JobEnum.Learn;

                foreach (var period in Ebbinghaus.Periods)
                {
                    if (IsEqualDate(period))
                        return JobEnum.Review;
                }

                return JobEnum.NoOperation;
            }
        }

        protected bool IsEqualDate(int day = 0)
        {
            return _executeDate.AddDays(day).Date.Equals(DateTime.Now.Date);
        }

        public override bool Equals(object obj)
        {
            EbbinghausItem item = obj as EbbinghausItem;

            if (item == null)
                return false;

            return _planID.Equals(item.PlanID) && _ebbinghaus.Equals(item.Ebbinghaus) & _executeDate.Date.Equals(item.ExecuteDate);
        }

        public override int GetHashCode()
        {
            return string.Format("{0}-{1}-{2}", _planID, _ebbinghaus.GetHashCode(), _executeDate.GetHashCode()).GetHashCode();
        }

        public override void Refresh()
        {
            if (_progressStatus == ProgressStatusEnum.Completed)
                return;

            DateTime currentDate = DateTime.Now.Date;
            if (currentDate.Equals(_executeDate))
            {
                _progressStatus = ProgressStatusEnum.InProgress;
            }
            else if (_executeDate > currentDate)
            {
                _progressStatus = ProgressStatusEnum.NotStarted;
            }
            else
            {
                _progressStatus = ProgressStatusEnum.Uncompleted;
            }
        }

        public void MarkCompleted()
        {
            _progressStatus = ProgressStatusEnum.Completed;
        }

        public void PushDay(int day)
        {
            if (_progressStatus != ProgressStatusEnum.Completed)
            {
                _executeDate = _executeDate.AddDays(day);
            }
        }
    }
}
