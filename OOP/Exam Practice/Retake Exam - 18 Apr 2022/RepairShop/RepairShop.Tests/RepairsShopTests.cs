using System;
using NUnit.Framework;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            private Garage fullGarage;

            [SetUp]

            public void Init()
            {
                fullGarage = new Garage("Bobby's", 3);
                fullGarage.AddCar(new Car("Opel", 2));
                fullGarage.AddCar(new Car("Toyota", 3));
                fullGarage.AddCar(new Car("BMW", 3));

            }

            [Test]
            [TestCase("")]
            [TestCase(null)]
            public void ConstructorShouldThrowExceptionIfNameIsInvalid(string name)
            {
                Assert.Throws<ArgumentNullException>(() => new Garage(name, 5));
            }

            [Test]
            [TestCase(0)]
            [TestCase(-5)]
            public void ConstructorShouldThrowExceptionIfMechanicsLessOrEqualTo0(int mechanics)
            {
                Assert.Throws<ArgumentException>(() => new Garage("Booby's", mechanics));
            }

            [Test]
            public void ConstructorShouldCreateGarageWithValidData()
            {
                Garage garage = new Garage("Bobby's", 5);

                Assert.AreEqual("Bobby's", garage.Name);
                Assert.AreEqual(5, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void AddMethodShouldThrowExceptionIfGarageFull()
            {
                Car car = new Car("KIA", 3);
                Assert.Throws<InvalidOperationException>(() => fullGarage.AddCar(car));
            }

            [Test]
            public void FixCarShouldThrowExceptionIfCarNotInGarage()
            {
                Assert.Throws<InvalidOperationException>(() => fullGarage.FixCar("Honda"));
            }

            [Test]
            public void FixCarShouldFixTheCar()
            {
                Garage garage = new Garage("Bill's", 3);
                Car car = new Car("Opel", 3);
                garage.AddCar(car);

                garage.FixCar("Opel");

                Assert.AreEqual(0, car.NumberOfIssues);
            }

            [Test]
            public void RemoveFixedCarsShouldReduceCarsCount()
            {
                fullGarage.FixCar("Opel");
                fullGarage.FixCar("Toyota");

                fullGarage.RemoveFixedCar();

                Assert.AreEqual(1, fullGarage.CarsInGarage);
            }

            [Test]
            public void RemoveFixedCarsShouldThrowExceptionIfNoFixedCars()
            {
                Assert.Throws<InvalidOperationException>(() => fullGarage.RemoveFixedCar());
            }

            [Test]
            public void ReportMethodShodReturnInformationAboutCarsThatAreNotFixed()
            {
                fullGarage.FixCar("Toyota");

                string report = fullGarage.Report();

                Assert.AreEqual("There are 2 which are not fixed: Opel, BMW.", report);
            }
        }
    }
}