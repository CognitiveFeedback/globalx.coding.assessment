using System;

namespace GlobalX.Coding.Assessment.Sorting.NameSorter
{
    /// <summary>
    /// Array sort implementation of the abstract NameSorter class
    /// </summary>
    public class ArrayNameSorter : NameSorter
    {
        /// <summary>
        /// Executes an Array Sort on the list of names
        /// </summary>
        public override void Sort()
        {
            sw.Reset();
            sw.Start();
            Array.Sort(names);
            sw.Stop();
        }
    }
}
