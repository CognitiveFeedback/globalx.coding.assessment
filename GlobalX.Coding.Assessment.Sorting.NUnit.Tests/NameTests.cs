using NUnit.Framework;
using System;

namespace GlobalX.Coding.Assessment.Sorting.NUnit.Tests
{

    [TestFixture]
    public class NameTests
    {
        [Test]
        public void Name_Construction_AurgumentException_1_Name()
        {
            Assert.Throws<ArgumentException>(() => new Name("Simon"));
        }

        [Test]
        public void Name_Construction_AurgumentException_5_Names()
        {
            Assert.Throws<ArgumentException>(() => new Name("Simon David Stephen Porcella Le Serve"));
        }

        [Test]
        public void Name_CompareTo_2_And_3_Names()
        {
            var name1 = new Name("Simon LeServe");
            var name2 = new Name("Simon David LeServe");

            var target = name1.CompareTo(name2);

            Assert.AreEqual(target, -1);
        }

        [Test]
        public void Name_CompareTo_Different_Given_Names()
        {
            var name1 = new Name("Simon LeServe");
            var name2 = new Name("Sally LeServe");

            var target = name1.CompareTo(name2);

            Assert.AreEqual(target, 1);
        }
    }
}