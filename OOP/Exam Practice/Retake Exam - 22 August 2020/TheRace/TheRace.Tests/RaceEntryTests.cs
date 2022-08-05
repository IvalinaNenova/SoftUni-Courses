using System;
using System.Collections.Generic;
using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry entry;
        [SetUp]
        public void Setup()
        {
            entry = new RaceEntry();
        }

        [Test]
        public void AddMethodShouldAddDriver()
        {
            UnitDriver driver = new UnitDriver("Bobby", new UnitCar("Subaru", 150, 50));
            entry.AddDriver(driver);

            Assert.AreEqual(1, entry.Counter);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfDriverIsNull()
        {
            UnitDriver driver = null;

            Assert.Throws<InvalidOperationException>(() => entry.AddDriver(driver));
        }
        [Test]
        public void AddMethodShouldThrowExceptionIfDriverAlreadyRegistered()
        {
            UnitDriver driver = new UnitDriver("Bobby", new UnitCar("Subaru", 150, 50));
            entry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => entry.AddDriver(driver));
        }

        [Test]
        public void AddDriverMethodShouldReturnCorrectMessage()
        {
            UnitDriver driver = new UnitDriver("Bobby", new UnitCar("Subaru", 150, 50));
            
            string message = entry.AddDriver(driver);

            Assert.AreEqual($"Driver Bobby added in race.", message);
        }

        [Test]
        public void CalculateAverageHorsepowerMethodShouldThrowExceptionIfCountLessThanMinCount()
        {
            UnitDriver driver = new UnitDriver("Bobby", new UnitCar("Subaru", 150, 50));
            entry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => entry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsepowerMethodShouldReturnAverageHorsepower()
        {
            UnitDriver driver1 = new UnitDriver("Bobby", new UnitCar("Subaru", 150, 50));
            UnitDriver driver2 = new UnitDriver("Molly", new UnitCar("Subaru", 200, 50));
            UnitDriver driver3 = new UnitDriver("Gigi", new UnitCar("Subaru", 250, 50));
            entry.AddDriver(driver1);
            entry.AddDriver(driver2);
            entry.AddDriver(driver3);

            Assert.AreEqual(200, entry.CalculateAverageHorsePower());
        }
    }
}