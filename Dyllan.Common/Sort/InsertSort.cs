using System;
using System.Collections.Generic;

namespace Dyllan.Common.Sort
{
    public class InsertSort<T> : SortAlgorithm<T> where T : IComparable<T>
    {
        protected override void DoSort(IList<T> collection)
        {
            T key;

            for (int j = 1, i = 0; j < collection.Count; j++)
            {
                key = collection[j];
                i = j - 1;

                while (i > -1 && collection[i].CompareTo(key) > 0)
                {
                    collection[i + 1] = collection[i];
                    i--;
                }

                collection[i + 1] = key;
            }
        }
    }
}
