using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public class CommonEbbCollection : DailyItemCollection
    {
        public override void Add(DailyItem item)
        {
            if (item != null && _items.Where(p => p.Name.Equals(item.Name)).Count() != 0)
                throw new DuplicateDailyItemException(item.Name);

            base.Add(item);
        }

        protected override void CheckItem(DailyItem item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            if (!(item is CommonEbbinghausItem))
                throw new InvalidTypeException(typeof(CommonEbbinghausItem), item.GetType());
        }

        public void AdjustDate()
        {
            int pushDay = 0;
            foreach (CommonEbbinghausItem item in _items)
            {
                if (pushDay != 0)
                {
                    item.PushDay(pushDay);
                }
                else if (item.ExecuteDate < DateTime.Now.Date)
                {
                    item.Refresh();
                    if (item.ProcessStatus == ProgressStatusEnum.Uncompleted)
                    { 
                        pushDay = DateTime.Now.Subtract(item.ExecuteDate).Days;
                        item.PushDay(pushDay);
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public void TryGetProcessStatus(out int inprogressCount, out int completedCount, out int notStartedCount, out int uncompletedCount)
        {
            inprogressCount = 0;
            completedCount = 0;
            notStartedCount = 0;
            uncompletedCount = 0;
            foreach (var item in _items)
            {
                item.Refresh();
                switch (item.ProcessStatus)
                {
                    case ProgressStatusEnum.InProgress:
                        inprogressCount++;
                        break;
                    case ProgressStatusEnum.Completed:
                        completedCount++;
                        break;
                    case ProgressStatusEnum.NotStarted:
                        notStartedCount++;
                        break;
                    case ProgressStatusEnum.Uncompleted:
                        uncompletedCount++;
                        break;
                    default:
                        break;
                }
            }
        }

        public DateTime LastReviewDate
        {
            get
            {
                DateTime result = DateTime.MinValue;
                if (_items.Count > 0)
                {
                    CommonEbbinghausItem item = _items[_items.Count - 1] as CommonEbbinghausItem;
                    result = item.LastReviewDate;
                }
                return result;
            }
        }
    }
}
