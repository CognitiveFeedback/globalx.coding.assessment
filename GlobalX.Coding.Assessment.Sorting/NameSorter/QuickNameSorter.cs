﻿using GlobalX.Coding.Assessment.Sorting.Models;

namespace GlobalX.Coding.Assessment.Sorting.NameSorter
{
    /// <summary>
    /// Quick sort implementation of the abstract NameSorter class
    /// </summary>
    public class QuickNameSorter : NameSorter
    {
        /// <summary>
        /// Executes a Quick Sort on the list of names
        /// </summary>
        public override void SortNames()
        {
            QuickSort<OrderedName>.Sort(names);
        }
    }
}
