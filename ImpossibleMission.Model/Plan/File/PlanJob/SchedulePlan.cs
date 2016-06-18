using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public class SchedulePlan : Plan
    {
        public SchedulePlan(DateTime startDate) : base(startDate)
        {
            _items = new ScheduleItemCollection();
        }

        internal SchedulePlan(Guid id, string name, DateTime startDate, DateTime endDate, string details, string review, ProgressStatusEnum status)
            : base(id, name, startDate, endDate, details, review, status, new ScheduleItemCollection())
        {
        }

        public override void GenerateItem(string name)
        {
            int index = int.Parse(name);
            GenerateItem(index, null, TimeSpan.Zero);
        }

        public void GenerateItem(int index, string note, TimeSpan costTime)
        {
            if (index < StartIndex || index > EndIndex)
                throw new ArgumentException("Invalid Current Index");

            ScheduleItem item = TodayItem;

            if (item == null)
            {
                _dailyItem = item = new ScheduleItem(index, DateTime.Now.Date.ToString("yyyy-MM-dd"), this.ID);
                _todayDate = DateTime.Now;
                _items.Add(item);
            }
            else
            {
                item.CurrentIndex = index;
            }
            item.Note = note;
            item.CostTime = costTime;
        }

        private DateTime _todayDate = DateTime.MinValue;
        private ScheduleItem _dailyItem = null;
        public ScheduleItem TodayItem
        {
            get
            {
                if (_todayDate.Date != DateTime.Now.Date || _dailyItem == null)
                {
                    DailyItem item = _items.FirstOrDefault(p => p.ExecuteDate.Date == DateTime.Now.Date);
                    _dailyItem = item as ScheduleItem;
                }

                return _dailyItem;
            }
        }

        public int CurrentIndex
        {
            get
            {
                ScheduleItemCollection items = _items as ScheduleItemCollection;
                ScheduleItem item = items.LastDailyItem as ScheduleItem;
                if (item != null)
                {
                    return item.CurrentIndex;
                }
                return StartIndex;
            }
        }

        public int Amount
        {
            get
            {
                return _endIndex - _startIndex + 1;
            }
        }

        private int _weekDayWorkload;
        private int _weekendWorkload;
        private int _startIndex;
        private int _endIndex;
        private float _buffer;
        public int WeekDayWorkload
        {
            get
            {
                return _weekDayWorkload;
            }
        }

        public int WeekendWorkload
        {
            get
            {
                return _weekendWorkload;
            }
        }

        public int StartIndex
        {
            get
            {
                return _startIndex;
            }
        }

        public int EndIndex
        {
            get
            {
                return _endIndex;
            }
        }

        public float Buffer
        {
            get
            {
                return _buffer;
            }
        }

        public override string TypeName
        {
            get
            {
                return ResourceCode.TypeName_Schedule;
            }
        }

        private static void CheckParameter(int startIndex, int endIndex, int weekDayWorkload, int weekendWorkload, float buffer)
        {
            if (startIndex < 0 || endIndex <= 0 || weekDayWorkload < 0 || weekendWorkload < 0 || buffer < 0
                || endIndex < startIndex || (weekendWorkload + weekDayWorkload == 0))
            {
                throw new ArgumentException();
            }
        }

        public void SetParameter(int startIndex, int endIndex, int weekDayWorkload, int weekendWorkload, float buffer)
        {
            CheckParameter(startIndex, endIndex, weekDayWorkload, weekendWorkload, buffer);
            _startIndex = startIndex;
            _endIndex = endIndex;
            _weekDayWorkload = weekDayWorkload;
            _weekendWorkload = weekendWorkload;
            _buffer = buffer;

            if (_endDate < _startDate)
            {
                _endDate = GetEndDate(_startDate, startIndex, endIndex, weekDayWorkload, weekendWorkload, buffer);
            }
        }

        protected override ProgressStatusEnum GetPlanProgressStatus()
        {
            ProgressStatusEnum progressStatus = ProgressStatusEnum.NotStarted;
            ScheduleItemCollection items = _items as ScheduleItemCollection;

            if (EndDate <= StartDate)
            {
                progressStatus = ProgressStatusEnum.NotStarted;
            }
            else if (DateTime.Now.Date > EndDate)
            {
                progressStatus = ProgressStatusEnum.Uncompleted;
            }
            else
            {
                ScheduleItem item = items.LastDailyItem as ScheduleItem;

                if (item != null)
                {
                    if (item.CurrentIndex >= EndIndex)
                        progressStatus = ProgressStatusEnum.Completed;
                    else
                    {
                        progressStatus = ProgressStatusEnum.InProgress;
                    }
                }
            }

            return progressStatus;
        }

        public override float CompletedPercent
        {
            get
            {
                ScheduleItemCollection items = _items as ScheduleItemCollection;
                ScheduleItem item = items.LastDailyItem as ScheduleItem;
                float completed = 0.0f;

                if (item != null)
                {
                    completed = ((float)(item.CurrentIndex - StartIndex + 1)) / ((float)Amount);
                }

                return completed * 100;
            }
        }

        public override bool DailyUpdated
        {
            get
            {
                return TodayItem != null;
            }
        }

        public static DateTime GetEndDate(DateTime startDate, int startIndex, int endIndex, int weekDayWorkload, int weekendWorkload, float buffer)
        {
            // TODO: Redesign
            CheckParameter(startIndex, endIndex, weekDayWorkload, weekendWorkload, buffer);
            float tempStartIndex = startIndex;
            float tempEndIndex = endIndex;
            float tempWeekDayWorkload = weekDayWorkload;
            float tempWeekendWorkload = weekendWorkload;
            float totalWorkload = tempWeekDayWorkload + tempWeekendWorkload;

            float costDay = (tempEndIndex - tempStartIndex + 1f) / ((tempWeekDayWorkload * 5f) + (tempWeekendWorkload * 2f)) * 7.0f;
            float costBuffer = costDay * buffer * ((5f / 7f * tempWeekDayWorkload / totalWorkload) + (2f / 7f * tempWeekendWorkload / totalWorkload));
            int tempCost = (int)Math.Ceiling(costBuffer + costDay);
            DateTime result = startDate.AddDays(tempCost);
            if (weekendWorkload == 0)
            {
                if (result.DayOfWeek == DayOfWeek.Saturday)
                {
                    result = result.AddDays(2);
                }
                else if (result.DayOfWeek == DayOfWeek.Sunday)
                {
                    result = result.AddDays(1);
                }
                else
                {
                    // Nothing to do;
                }
            }

            return result;
        }
    }
}
