using System;

namespace GlobalX.Coding.Assessment.Sorting.NameSorter
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
