using GlobalX.Coding.Assessment.Sorting.Models;
using NUnit.Framework;
using System;

namespace GlobalX.Coding.Assessment.Sorting.NUnit.Tests
{

    [TestFixture]
    public class OrderedNameTests
    {
        [Test]
        public void Construction_AurgumentException_1_Name()
        {
            Assert.Throws<ArgumentException>(() => new OrderedName("Simon"));
        }

        [Test]
        public void onstruction_AurgumentException_5_Names()
        {
            Assert.Throws<ArgumentException>(() => new OrderedName("Simon David Stephen Porcella Le Serve"));
        }

        [Test]
        public void CompareTo_2_And_3_Names()
        {
            var name1 = new OrderedName("Simon LeServe");
            var name2 = new OrderedName("Simon David LeServe");

            var target = name1.CompareTo(name2);

            Assert.AreEqual(target, -1);
        }

        [Test]
        public void CompareTo_Different_Given_Names()
        {
            var name1 = new OrderedName("Simon LeServe");
            var name2 = new OrderedName("Sally LeServe");

            var target = name1.CompareTo(name2);

            Assert.AreEqual(target, 1);
        }

        [Test]
        public void CompareTo_Slightly_Different_Names()
        {
            var name1 = new OrderedName("Simon David Stephen LeServe");
            var name2 = new OrderedName("Simon David Stephan LeServe");

            var target = name1.CompareTo(name2);

            Assert.AreEqual(target, 1);
        }

        [Test]
        public void CompareTo_Multiple_Spaces()
        {
            var name1 = new OrderedName("Simon LeServe");
            var name2 = new OrderedName("Simon     LeServe");

            var target = name1.CompareTo(name2);

            Assert.AreEqual(target, 0);
        }
    }
}