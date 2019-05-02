using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalX.Coding.Assessment.Sorting
{
    public class QuickNameSorter : NameSorter
    {
        public override void Sort(Name[] names)
        {
            QuickSort<Name>.Sort(names);
        }
    }
}
