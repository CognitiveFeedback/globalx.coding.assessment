using GlobalX.Coding.Assessment.Sorting.Models;

namespace GlobalX.Coding.Assessment.Sorting.NameSorter
{
    public class QuickNameSorter : NameSorter
    {
        public override void Sort()
        {
            sw.Reset();
            sw.Start();
            QuickSort<Name>.Sort(names);
            sw.Stop();
        }
    }
}
