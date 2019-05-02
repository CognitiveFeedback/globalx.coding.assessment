using System;

namespace GlobalX.Coding.Assessment.Sorting.NameSorter
{
    public class ArrayNameSorter : NameSorter
    {
        public override void Sort()
        {
            sw.Reset();
            sw.Start();
            Array.Sort(names);
            sw.Stop();
        }
    }
}
