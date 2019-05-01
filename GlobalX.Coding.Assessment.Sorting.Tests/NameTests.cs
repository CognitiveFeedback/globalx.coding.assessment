using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GlobalX.Coding.Assessment.Sorting.Tests
{
    [TestClass()]
    public class NameTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Name_Construction_AurgumentException_1_Name()
        {
            var name = new Name("Simon");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Name_Construction_AurgumentException_5_Names()
        {
            var name = new Name("Simon David Stephen Porcella Le Serve");
        }

        [TestMethod()]
        public void Name_CompareTo_2_And_3_Names()
        {
            var name1 = new Name("Simon LeServe");
            var name2 = new Name("Simon David LeServe");

            var target = name1.CompareTo(name2);

            Assert.AreEqual(target, -1);
        }

        [TestMethod()]
        public void Name_CompareTo_Different_Given_Names()
        {
            var name1 = new Name("Simon LeServe");
            var name2 = new Name("Sally LeServe");

            var target = name1.CompareTo(name2);

            Assert.AreEqual(target, 1);
        }
    }
}