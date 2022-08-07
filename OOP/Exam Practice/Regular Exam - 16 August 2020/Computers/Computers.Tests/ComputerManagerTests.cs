using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void ConstructorShouldCreateEmptyList()
        {
            ComputerManager manager = new ComputerManager();
            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        public void AddComputerMethodShouldWorkProperly()
        {
            var manager = new ComputerManager();
            manager.AddComputer(new Computer("Dell", "S50", 1000));

            Assert.AreEqual(1,manager.Count);
        }

        [Test]
        public void AddComputerShouldThrowExceptionIfComputerAlreadyExists()
        {
            var manager = new ComputerManager();
            Computer computer = new Computer("Dell", "S50", 1000);
            manager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => manager.AddComputer(computer));
        }

        [Test]
        public void RemoveComputerShouldReduceCount()
        {
            var manager = new ComputerManager();

            Computer computer1 = new Computer("Assus", "S50", 1000);
            Computer computer2 = new Computer("Dell", "S50", 1000);
            Computer computer3 = new Computer("Lenovo", "S50", 1000);

            manager.AddComputer(computer1);
            manager.AddComputer(computer2);
            manager.AddComputer(computer3);

            Assert.AreEqual(3, manager.Count);

            manager.RemoveComputer("Dell", "S50");

            Assert.AreEqual(2, manager.Count);
        }

        [Test]
        public void RemoveComputerShouldReturnRemovedComputer()
        {
            var manager = new ComputerManager();

            Computer computer1 = new Computer("Assus", "S50", 1000);
            Computer computer2 = new Computer("Dell", "S50", 1000);

            manager.AddComputer(computer1);
            manager.AddComputer(computer2);

            var removed = manager.RemoveComputer("Dell", "S50");

            Assert.AreEqual(removed, computer2);
        }

        [Test]
        public void GetComputerShouldThrowExceptionIfComputerNotInCollection()
        {
            var manager = new ComputerManager();

            Computer computer1 = new Computer("Assus", "S50", 1000);

            manager.AddComputer(computer1);

            Assert.Throws<ArgumentException>(() => manager.GetComputer("Dell", "S50"));
        }

        [Test]
        public void GetComputerShouldWorkProperly()
        {
            var manager = new ComputerManager();

            Computer computer1 = new Computer("Assus", "S50", 1000);
            Computer computer2 = new Computer("Dell", "S50", 1000);

            manager.AddComputer(computer1);
            manager.AddComputer(computer2);

            var computer = manager.GetComputer("Assus", "S50");

            Assert.AreEqual(computer, computer1);
        }

        [Test]
        public void GetComputersByManufacturerShouldWorkProperly()
        {
            var manager = new ComputerManager();

            Computer computer1 = new Computer("Dell", "S10", 1000);
            Computer computer2 = new Computer("Lenovo", "S20", 1000);
            Computer computer3 = new Computer("Dell", "S30", 1000);
            Computer computer4 = new Computer("Assus", "S50", 1000);

            manager.AddComputer(computer1);
            manager.AddComputer(computer2);
            manager.AddComputer(computer3);
            manager.AddComputer(computer4);
            var computersByManufacturer = manager.GetComputersByManufacturer("Dell");
            List<Computer> computers = new List<Computer>{computer1, computer3};

            CollectionAssert.AreEqual(computers, computersByManufacturer );
        }

        [Test]
        public void ValidateMethodShouldWorkProperly()
        {
            var manager = new ComputerManager();

            Computer computer1 = new Computer("Assus", "S50", 1000);
            Computer computer2 = new Computer("Dell", "S50", 1000);

            manager.AddComputer(computer1);
            manager.AddComputer(computer2);

            Assert.Throws<ArgumentNullException>(() => manager.RemoveComputer(null, null));
            Assert.That(() => manager.AddComputer(null), Throws.ArgumentNullException.With.Message.EqualTo("Can not be null! (Parameter 'computer')"));

        }

        [Test]
        public void ComputersPropertyShouldBeReadOnly()
        {
            var type = typeof(ComputerManager);
            var propertyInfo = type.GetProperty("Computers");
            Assert.That(propertyInfo.CanWrite == false);
        }
    }
}