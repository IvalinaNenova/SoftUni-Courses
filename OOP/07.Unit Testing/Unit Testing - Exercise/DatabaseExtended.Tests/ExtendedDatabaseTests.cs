using System;
using ExtendedDatabase;
using System.Text;
using NUnit.Framework.Interfaces;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database fullDatabase;
        private Database twoPeopleInDatabase;

        [SetUp]
        public void Init()
        {
            Person[] twoPeopleList = new Person[2];

            for (int i = 0; i < 2; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Iva");
                sb.Append(i.ToString());

                twoPeopleList[i] = new Person(1234 + i, sb.ToString());
            }

            twoPeopleInDatabase = new Database(twoPeopleList);

            Person[] sixteenPeopleList = new Person[16];

            for (int i = 0; i < 16; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Iva");
                sb.Append(i.ToString());

                sixteenPeopleList[i] = new Person(1234 + i, sb.ToString());
            }

            fullDatabase = new Database(sixteenPeopleList);
        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenCollectionExceeds16()
        {
            Person[] people = new Person[20];

            for (int i = 0; i < 16; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Iva");
                sb.Append(i.ToString());

                people[i] = new Person(1234 + i, sb.ToString());
            }

            Assert.That(() => new Database(people), Throws.ArgumentException.With.Message
                .EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        [TestCase(16)]
        [TestCase(5)]
        [TestCase(0)]
        public void ConstructorShouldAddPeopleToDatabaseIfCollectionLessOrEqualTo16(int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < count; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Iva");
                sb.Append(i.ToString());

                people[i] = new Person(1234 + i, sb.ToString());
            }

            Database database = new Database(people);

            Assert.That(database.Count, Is.EqualTo(count));
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenAddingExistingPersonById()
        {
            Person newPerson = new Person(1235, "Iva");

            Assert.That(() => twoPeopleInDatabase.Add(newPerson), Throws.InvalidOperationException.With.Message
                        .EqualTo("There is already user with this Id!"));
        }

        [Test]

        public void AddMethodShouldThrowExceptionWhenAddingExistingPersonByName()
        {
            Assert.That(() => twoPeopleInDatabase.Add(new Person(3, "Iva0")), Throws.InvalidOperationException.With.Message
                        .EqualTo("There is already user with this username!"));
        }

        [Test]

        public void AddMethodShouldThrowExceptionIfCollectionHas16People()
        {
            Person newPerson = new Person(12, "Marina");

            Assert.That(() => fullDatabase.Add(newPerson),
                Throws.InvalidOperationException.With.Message
                        .EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]

        public void RemoveMethodShouldThrowExceptionIfDatabaseIsEmpty()
        {
            Database database = new Database();

            Assert.That(() => database.Remove(), Throws.InvalidOperationException);
        }

        [Test]

        public void RemoveMethodShouldRemoveElementsFromDatabase()
        {
            fullDatabase.Remove();
            fullDatabase.Remove();

            Assert.That(fullDatabase.Count, Is.EqualTo(14));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsernameMethodShouldThrowExceptionIfInvalidUsername(string name)
        {
            Assert.That(()=> fullDatabase.FindByUsername(name),
                Throws.ArgumentNullException);
        }
        [Test]
        public void FindByUsernameMethodShouldThrowExceptionIfLowercaseName()
        {
            Assert.That(() => fullDatabase.FindByUsername("iva0"), 
                Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameMethodShouldThrowExceptionIfUsernameDoesNotExist()
        {
            Assert.That(() => fullDatabase.FindByUsername("Marina"), Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FindByUsernameShouldReturnPersonWithThatUsername()
        {
            Person result = fullDatabase.FindByUsername("Iva0");
            Person expected = new Person(1234, "Iva0");

            Assert.AreEqual((result.UserName , result.Id), (expected.UserName, expected.Id));
        }

        [Test]
        public void FindByIdMethodShouldThrowExceptionIfNoUserWithThatIdInDatabase()
        {
            Assert.That(() => fullDatabase.FindById(1), Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void FindByIdMethodShouldThrowExceptionIfNegativeIdIsProvided()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => fullDatabase.FindById(-1));
        }
        [Test]
        public void FindByIdShouldReturnPersonWithThatId()
        {
            Person result = fullDatabase.FindById(1235);
            Person expected = new Person(1235, "Iva1");
            Assert.AreEqual((result.Id, result.UserName), 
                (expected.Id, expected.UserName));
        }
    }
}