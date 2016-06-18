using System;
using System.Collections.Generic;

namespace Dyllan.Common.Sort
{
    public abstract class SortAlgorithm<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection != null && collection.Count > 0)
            {
                DoSort(collection);
            }
        }

        protected abstract void DoSort(IList<T> collection);
    }
}
