using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalX.Coding.Assessment.Sorting
{
    public static class NameSorterFactory
    {
        public static NameSorter Create(SortMethod sortMethod)
        {
            NameSorter sorter = null;
            switch (sortMethod)
            {
                case SortMethod.ArraySort:
                    sorter = new ArrayNameSorter();
                    break;
                case SortMethod.QuickSort:
                    sorter = new QuickNameSorter();
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"sortMethod: {sortMethod}");
            }
            return sorter;
        }
    }
}
