using System;
using System.Linq;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        [TestCase(5)]
        [TestCase(15)]
        [TestCase(16)]
        public void AddMethodShouldAddNewItemWhileCountLessThan16(int count)
        {
            Database database = new Database();
            for (int i = 0; i < count; i++)
            {
                database.Add(i);
            }

            Assert.AreEqual(count, database.Count);
        }
        [Test]
        public void AddMethodShouldThrowExceptionWhenAddingMoreThan17Items()
        {
            var elements = Enumerable.Range(1, 16).ToArray();
            Database database = new Database(elements);

            Assert.Throws<InvalidOperationException>(() => database.Add(1));
        }

        [Test]
        [TestCase(1, 4)]
        [TestCase(1, 15)]
        [TestCase(1, 16)]
        public void ConstructorShouldAddElementsWhileLessThan16(int start, int end)
        {
            var elements = Enumerable.Range(start, end).ToArray();

            Database database = new Database(elements);

            Assert.AreEqual(end, database.Count);
        }
        [Test]
        public void ConstructorShouldThrowExceptionIfElementsMoreThan16()
        {
            var elements = Enumerable.Range(1, 17).ToArray();

            Assert.Throws<InvalidOperationException>(() => new Database(elements));
        }
        

        [Test]
        [TestCase(16)]
        [TestCase(2)]
        [TestCase(1)]
        public void RemoveShouldRemoveItemsWhenCollectionHasMoreThan0Elements(int count)
        {
            var elements = Enumerable.Range(1, count).ToArray();
            Database database = new Database(elements);

            database.Remove();

            Assert.AreEqual(count-1, database.Count);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenCollectionHas0Elements()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchShouldReturnAllValidItems()
        {
            Database database = new Database(1, 2, 3);
            database.Add(4);
            database.Add(5);
            database.Add(6);

            database.Remove();
            database.Remove();

            int[] fetched = database.Fetch();
            int[] expectedData = new int[]{1, 2, 3, 4};

            CollectionAssert.AreEqual(fetched, expectedData );
        }
    }
}
