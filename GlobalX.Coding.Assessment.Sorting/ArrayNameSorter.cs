using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalX.Coding.Assessment.Sorting
{
    public class ArrayNameSorter : NameSorter
    {
        public override void Sort(Name[] names)
        {
            Array.Sort(names);
        }
    }
}
