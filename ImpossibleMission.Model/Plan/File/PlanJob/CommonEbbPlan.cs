using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public class CommonEbbPlan : Plan
    {
        public override string TypeName
        {
            get
            {
                return ResourceCode.TypeName_Ebbinghaus;
            }
        }

        public CommonEbbPlan(DateTime startDate) : base(startDate)
        {
            _items = new CommonEbbCollection();
        }

        internal CommonEbbPlan(Guid id, string name, DateTime startDate, DateTime endDate, string details, string review, ProgressStatusEnum status)
           : base(id, name, startDate, endDate, details, review, status, new CommonEbbCollection())
        {
        }

        public override void GenerateItem(string name)
        {
            _endDate = _endDate.AddDays(1);
            _items.Add(new CommonEbbinghausItem(_endDate, name, this.ID));
        }

        protected override ProgressStatusEnum GetPlanProgressStatus()
        {
            DateTime currentDate = DateTime.Now.Date;
            if (_items == null || currentDate < _startDate || _startDate >= _endDate)
                return ProgressStatusEnum.NotStarted;

            CommonEbbCollection items = _items as CommonEbbCollection;

            int inprogressCount, completedCount, notStartedCount, uncompletedCount;
            items.TryGetProcessStatus(out inprogressCount, out completedCount, out notStartedCount, out uncompletedCount);
            items.AdjustDate();
            if (uncompletedCount > 0 && currentDate > _endDate)
                return ProgressStatusEnum.Uncompleted;
            if (completedCount == _items.Count && currentDate >= items.LastReviewDate)
                return ProgressStatusEnum.Completed;
            return ProgressStatusEnum.InProgress;
        }

        public float GetCompletedPercent(out int inprogressCount, out int completedCount, out int notStartedCount, out int uncompletedCount)
        {
            CommonEbbCollection items = _items as CommonEbbCollection;
            items.TryGetProcessStatus(out inprogressCount, out completedCount, out notStartedCount, out uncompletedCount);
            var percent = (float)completedCount / (float)_items.Count;
            return percent;
        }

        public override float CompletedPercent
        {
            get
            {
                int inprogressCount, completedCount, notStartedCount, uncompletedCount;
                float result = GetCompletedPercent(out inprogressCount, out completedCount, out notStartedCount, out uncompletedCount);

                if (result == 1)
                {
                    CommonEbbCollection items = _items as CommonEbbCollection;
                    if (DateTime.Now < items.LastReviewDate)
                        result = 0.99f;
                }

                return result * 100f;
            }
        }

        public override DateTime EndDate
        {
            get
            {
                CommonEbbCollection tempItem = _items as CommonEbbCollection;
                return tempItem.LastReviewDate;
            }
        }

        private DateTime _todayDate = DateTime.MinValue;
        private CommonEbbinghausItem _dailyItem = null;
        public CommonEbbinghausItem TodayItem
        {
            get
            {
                if (_todayDate.Date != DateTime.Now.Date || _dailyItem == null)
                {
                    Refresh();
                    DailyItem item = Items.FirstOrDefault(p => p.ExecuteDate.Date == DateTime.Now.Date);
                    if (item == null)
                    {
                        item = Items.LastOrDefault(p => (p as CommonEbbinghausItem).ItemType == JobEnum.Review);

                        if (item == null)
                            item = Items.LastOrDefault();
                    }
                    _dailyItem = item as CommonEbbinghausItem;
                }

                return _dailyItem;
            }
        }

        public override bool DailyUpdated
        {
            get
            {
                return TodayItem != null && TodayItem.ProcessStatus == ProgressStatusEnum.Completed;
            }
        }
    }
}
