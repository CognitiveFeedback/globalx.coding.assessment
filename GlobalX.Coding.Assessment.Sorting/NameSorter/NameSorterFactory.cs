using System;

namespace GlobalX.Coding.Assessment.Sorting.NameSorter
{
    /// <summary>
    /// Static factory class to create instances of types derived from NameSorter 
    /// </summary>
    public static class NameSorterFactory
    {
        /// <summary>
        /// Careate an instance of a type derived from NameSorter
        /// </summary>
        /// <param name="sortMethod"></param>
        /// <returns></returns>
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
