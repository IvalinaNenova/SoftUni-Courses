using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;
    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void ConstructorShouldWorkProperly()
        {
            Aquarium aquarium = new Aquarium("FishWorld", 10);

            Assert.IsNotNull(aquarium);
            Assert.AreEqual("FishWorld", aquarium.Name);
            Assert.AreEqual(10, aquarium.Capacity);
        }

        [Test]
        public void ConstructorShouldCreateEmptyList()
        {
            Aquarium aquarium = new Aquarium("FishWorld", 10);
            Assert.AreEqual(0, aquarium.Count);
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void NamePropertyShouldThrowExceptionIfNullOrEmptyName(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, 10));
        }

        [Test]
        public void CapacitySetterShouldThrowExceptionIfNegativeCapacityProvided()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("FishWorld", -1));
        }

        [Test]
        public void AddMethodShouldWorkProperly()
        {
            Aquarium aquarium = new Aquarium("FishWorld", 10);
            aquarium.Add(new Fish("Dory"));
            aquarium.Add(new Fish("Nemo"));
            aquarium.Add(new Fish("Melvin"));

            Assert.AreEqual(3, aquarium.Count);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfAquariumAtFullCapacity()
        {
            Aquarium aquarium = new Aquarium("FishWorld", 3);
            aquarium.Add(new Fish("Dory"));
            aquarium.Add(new Fish("Nemo"));
            aquarium.Add(new Fish("Melvin"));

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Red")));
        }

        [Test]
        public void RemoveFishShouldDecreaseCount()
        {
            Aquarium aquarium = new Aquarium("FishWorld", 3);
            aquarium.Add(new Fish("Dory"));
            aquarium.Add(new Fish("Nemo"));
            aquarium.Add(new Fish("Melvin"));

            aquarium.RemoveFish("Nemo");

            Assert.AreEqual(2, aquarium.Count);
        }

        [Test]
        public void RemoveFishShouldThrowExceptionIfFishNotInAquarium()
        {
            Aquarium aquarium = new Aquarium("FishWorld", 3);
            aquarium.Add(new Fish("Dory"));
            aquarium.Add(new Fish("Nemo"));
            aquarium.Add(new Fish("Melvin"));

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(("Red")));
        }

        [Test]
        public void SellFishShouldReturnTheRequestedFish()
        {
            Aquarium aquarium = new Aquarium("FishWorld", 3);
            aquarium.Add(new Fish("Dory"));
            aquarium.Add(new Fish("Nemo"));
            aquarium.Add(new Fish("Melvin"));

            Fish requestedFish = aquarium.SellFish("Nemo");

            Assert.AreEqual("Nemo", requestedFish.Name );
        }

        [Test]
        public void SellFishShouldMakeFishUnavailable()
        {
            Aquarium aquarium = new Aquarium("FishWorld", 3);
            aquarium.Add(new Fish("Dory"));
            aquarium.Add(new Fish("Nemo"));
            aquarium.Add(new Fish("Melvin"));

            Fish requestedFish = aquarium.SellFish("Nemo");

            Assert.AreEqual(false, requestedFish.Available);
        }

        [Test]
        public void SellFishShoulThrowExceptionIfRequestedFishNotInAquarium()
        {
            Aquarium aquarium = new Aquarium("FishWorld", 3);
            aquarium.Add(new Fish("Dory"));
            aquarium.Add(new Fish("Nemo"));
            aquarium.Add(new Fish("Melvin"));

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Red"));
        }

        [Test]
        public void ReportMethodShouldWorkProperly()
        {
            Aquarium aquarium = new Aquarium("FishWorld", 3);
            aquarium.Add(new Fish("Dory"));
            aquarium.Add(new Fish("Nemo"));
            aquarium.Add(new Fish("Melvin"));

            string fishReport = $"Fish available at FishWorld: Dory, Nemo, Melvin";

            Assert.AreEqual(fishReport, aquarium.Report());
        }
    }
}
