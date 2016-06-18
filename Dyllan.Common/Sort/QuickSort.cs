using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyllan.Common.Sort
{
    public class QuickSort<T> : SortAlgorithm<T> where T : IComparable<T>
    {
        protected override void DoSort(IList<T> collection)
        {
            throw new NotImplementedException();
        }
    }
}
