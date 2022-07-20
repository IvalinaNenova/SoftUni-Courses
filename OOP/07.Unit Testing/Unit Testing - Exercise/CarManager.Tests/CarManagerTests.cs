using System;
using NUnit.Framework.Internal;

namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]

        public void EmptyConstructorShouldSetFuelAmountTo0()
        {
            Car car = new Car("Toyota", "Yaris", 0.7, 50);
            Assert.AreEqual(0, car.FuelAmount);
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void MakePropertyShouldShouldThrowExceptionWhenInvalidDataIsSet(string data)
        {
            Assert.That(() => new Car( data, "Astra", 0.78, 50), Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ModelPropertyShouldShouldThrowExceptionWhenInvalidDataIsSet(string data)
        {
            Assert.That(() => new Car("Opel", data, 0.78, 50), Throws.ArgumentException.With.Message.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void FuelConsumptionPropertyShouldShouldThrowExceptionWhenInvalidDataIsSet()
        {
            Assert.That(() => new Car("Opel", "Astra", -0.50 , 50), Throws.ArgumentException.With.Message.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        [TestCase(-0)]
        [TestCase(-0.2)]
        [TestCase(0)]
        public void FuelCapacityPropertyShouldShouldThrowExceptionWhenInvalidDataIsSet(double capacity)
        {
            Assert.That(() => new Car("Opel", "Astra", 0.50, capacity), Throws.ArgumentException.With.Message.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]

        public void ConstructorShouldCreateObjectWithValidData()
        {
            Car car = new Car("Opel", "Astra", 0.7, 60);
            Assert.That(car.Make.Equals("Opel"));
            Assert.That(car.Model.Equals("Astra"));
            Assert.That(car.FuelConsumption.Equals(0.7));
            Assert.That(car.FuelCapacity.Equals(60));
            Assert.That(car.FuelAmount.Equals(0));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void RefuelMethodShouldThrowExceptionIfFuelLessOrEqualTo0(double fuel)
        {
            Car car = new Car("Opel", "Astra", 0.7, 60);

            Assert.That(()=> car.Refuel(fuel), Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        [TestCase(60)]
        [TestCase(10)]
        public void RefuelMethodShouldIncreaseFuelAmount(double fuel)
        {
            Car car = new Car("Opel", "Astra", 0.7, 60);
            double fuelBefore = car.FuelAmount;
            car.Refuel(fuel);

            Assert.That(car.FuelAmount, Is.EqualTo(fuel+ fuelBefore));
        }

        [Test]
        public void RefuelMethodShouldReturnAmountEqualToFuelCapacityWhenFuelExceedsIt()
        {
            Car car = new Car("Opel", "Astra", 0.7, 60);
            car.Refuel(70);

            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        public void DriveMethodShouldReduceFuelAmountIfEnoughFuel()
        {
            Car car = new Car("Opel", "Astra", 7, 60);
            car.Refuel(60);
            car.Drive(50);

            Assert.That(car.FuelAmount, Is.EqualTo(56.5));
        }

        [Test]
        public void DriveMethodShouldThrowExceptionWhenFuelNotEnoughToDriveCar()
        {
            Car car = new Car("Opel", "Astra", 7, 60);

            Assert.That(()=> car.Drive(5), Throws.InvalidOperationException.With.Message.EqualTo("You don't have enough fuel to drive!"));
        }
    }
}