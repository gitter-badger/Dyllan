using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dyllan.Common.Sort
{
    public class MergeSort<T> : SortAlgorithm<T> where T : IComparable<T>
    {
        protected override void DoSort(IList<T> collection)
        {
            DoMergeSort(collection, 0, collection.Count - 1);
        }

        private static void Merge(IList<T> collection, int p, int q, int r)
        {
            IList<T> leftCollection = new Collection<T>();
            IList<T> rightCollection = new Collection<T>();

            int n1 = q - p + 1;
            int n2 = r - q;
            int i, j, k;

            for (i = 0; i < n1; i++)
            {
                leftCollection.Add(collection[i + p]);
            }
            for (i = 0; i < n2; i++)
            {
                rightCollection.Add(collection[i + q + 1]);
            }

            for (k = p, i = 0, j = 0; i < n1 && j < n2; k++)
            {
                if (leftCollection[i].CompareTo(rightCollection[j]) < 0)
                {
                    collection[k] = leftCollection[i++];
                }
                else
                {
                    collection[k] = rightCollection[j++];
                }
            }

            if (i < n1)
            {
                for (; i < n1; i++, k++)
                {
                    collection[k] = leftCollection[i];
                }
            }
            else if (j < n2)
            {
                for (; j < n2; j++, k++)
                {
                    collection[k] = rightCollection[j];
                }
            }
            else
            {
                // Nothing to do.
            }
        }

        private static void DoMergeSort(IList<T> collection, int p, int r)
        {
            if (p < r)
            {
                int q = (p + r) / 2;
                DoMergeSort(collection, p, q);
                DoMergeSort(collection, q + 1, r);
                Merge(collection, p, q, r);
            }
        }

        public static void Sort(IList<T> collection)
        {
            if (collection != null && collection.Count > 0)
            {
                DoMergeSort(collection, 0, collection.Count - 1);
            }
        }
    }
}
