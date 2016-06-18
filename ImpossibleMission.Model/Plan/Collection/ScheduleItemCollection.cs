using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public class ScheduleItemCollection : DailyItemCollection
    {
        protected override void CheckItem(DailyItem item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            if (!(item is ScheduleItem))
                throw new InvalidTypeException(typeof(ScheduleItem), item.GetType());
        }

        public DailyItem LastDailyItem
        {
            get
            {
                DailyItem item = null;
                if (_items.Count > 0)
                {
                    item = _items[Count - 1];
                }
                return item;
            }
        }
    }
}
