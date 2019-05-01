using System.Linq;
using NUnit.Framework;


namespace GlobalX.Coding.Assessment.Sorting.NUnit.Tests
{
    [TestFixture]
    public class QuickSortTests
    {
        [Test]
        public void SortTest()
        {
            var unsorted = new int[] { 10, 8, 1, 6, 6, 5, 2, 9, 8, 7, 3, };

            var sorted = QuickSort<int>.Sort(unsorted);

            Assert.IsTrue(sorted.SequenceEqual(new int[] { 1, 2, 3, 5, 6, 6, 7, 8, 8, 9, 10 }));
        }
    }
}
