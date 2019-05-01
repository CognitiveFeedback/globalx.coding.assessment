using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GlobalX.Coding.Assessment.Sorting.Tests
{
    [TestClass()]
    public class QuickSortTests
    {
        [TestMethod()]
        public void SortTest()
        {
            var unsorted = new int[] { 10, 8, 1, 6, 6, 5, 2, 9, 8, 7, 3, };

            var sorted = QuickSort<int>.Sort(unsorted);

            Assert.IsTrue(sorted.SequenceEqual(new int[] { 1, 2, 3, 5, 6, 6, 7, 8, 8, 9, 10 }));
        }
    }
}
