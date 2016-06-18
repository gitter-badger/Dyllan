using System;
using System.Collections.Generic;

namespace Dyllan.Common.Sort
{
    public class HeapSort<T> : SortAlgorithm<T> where T : IComparable<T>
    {
        protected override void DoSort(IList<T> collection)
        {
            DoHeapSort(collection);
        }

        private void HeapAdjust(IList<T> collection, int s, int m)
        {
            T key = collection[s];
            for (int i = s * 2 + 1; i <= m; i = i * 2 + 1)
            {
                if (i < m && collection[i].CompareTo(collection[i + 1]) < 0)
                {
                    i++;
                }

                if (collection[i].CompareTo(key) < 0)
                {
                    break;
                }

                collection[s] = collection[i];
                s = i;
            }
            collection[s] = key;
        }

        private void DoHeapSort(IList<T> collection)
        {
            int maxIndex = collection.Count - 1;
            int i;

            for (i = maxIndex / 2; i >= 0; i--)
            {
                HeapAdjust(collection, i, maxIndex);
            }

            for (i = maxIndex; i > 0; i--)
            {
                T key = collection[0];
                collection[0] = collection[i];
                collection[i] = key;

                HeapAdjust(collection, 0, i - 1);
            }
        }
    }
}
