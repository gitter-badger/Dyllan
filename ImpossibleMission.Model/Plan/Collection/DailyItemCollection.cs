using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public abstract class DailyItemCollection : IEnumerable<DailyItem>, ICollection<DailyItem>
    {
        #region Implement IEnumerable
        public IEnumerator<DailyItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_items).GetEnumerator();
        }

        #endregion

        protected List<DailyItem> _items = new List<DailyItem>();

        #region Implement ICollection
        public virtual int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public virtual bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public virtual void Add(DailyItem item)
        {
            CheckItem(item);
            lock (_items)
            {
                _items.Add(item);
            }
        }

        public virtual bool Remove(DailyItem item)
        {
            CheckItem(item);
            lock (_items)
            {
                return _items.Remove(item);
            }
        }

        public virtual void Clear()
        {
            lock (_items)
            {
                _items.Clear();
            }
        }

        public virtual bool Contains(DailyItem item)
        {
            lock (_items)
            {
                return _items.Contains(item);
            }
        }

        public virtual void CopyTo(DailyItem[] array, int arrayIndex)
        {
            if (array != null)
            {
                foreach (var item in array)
                {
                    CheckItem(item);
                }
            }

            lock (_items)
            {
                _items.CopyTo(array, arrayIndex);
            }
        }
        #endregion


        protected abstract void CheckItem(DailyItem item);
        
    }
}
