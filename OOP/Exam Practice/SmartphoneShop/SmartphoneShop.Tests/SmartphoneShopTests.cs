using System.Text;
using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        
        [Test]
        public void ShopConstructorShouldThrowExceptionIfNegativeCapacityProvided()
        {
            Assert.That(() => new Shop(-10), Throws.ArgumentException);
        }

        [Test]
        public void ShopConstructorShouldCreateObjectWhenValidDataProvided()
        {
            Shop shop = new Shop(10);
            Assert.AreEqual(10, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfPhoneAlreadyInShop()
        {
            var shop = new Shop(2);
            Smartphone smartphone = new Smartphone("Apple0", 100);
            shop.Add(smartphone);
            Assert.That(() => shop.Add(smartphone), Throws.InvalidOperationException);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfShopIsAlreadyFull()
        {
            var shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("Apple0", 100);
            Smartphone smartphone2 = new Smartphone("Apple1", 100);
            Smartphone smartphone3 = new Smartphone("Apple2", 100);

            shop.Add(smartphone1);
            shop.Add(smartphone2);

            Assert.That(() => shop.Add(smartphone3), Throws.InvalidOperationException);
        }

        [Test]
        public void AddMethodShouldIncreaseCount()
        {
            var shop = new Shop(2);

            Smartphone smartphone = new Smartphone("Apple0", 100);
            shop.Add(smartphone);
            Assert.AreEqual(1, shop.Count);
            Assert.AreEqual(2, shop.Capacity);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfPhoneToRemoveDoesNotExist()
        {
            var shop = new Shop(2);

            Smartphone smartphone = new Smartphone("Apple0", 100);
            shop.Add(smartphone);

            Assert.That(()=> shop.Remove("Apple18"), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveMethodShouldRemovePhoneAndReduceCount()
        {
            var shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("Apple0", 100);
            Smartphone smartphone2 = new Smartphone("Apple1", 100);

            shop.Add(smartphone1);
            shop.Add(smartphone2);
            shop.Remove("Apple0");
            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void TestPhoneMethodShouldThrowExceptionIfPhoneDoesNotExist()
        {
            var shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("Apple0", 100);
            Smartphone smartphone2 = new Smartphone("Apple1", 100);

            shop.Add(smartphone1);
            shop.Add(smartphone2);

            Assert.That(()=> shop.TestPhone("Apple18", 50), Throws.InvalidOperationException);
        }

        [Test]
        public void TestPhoneMethodShouldThrowExceptionIfBatteryChargeIsLessThanBatteryUsage()
        {
            var shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("Apple0", 100);
            shop.Add(smartphone1);
            shop.TestPhone("Apple0", 40);
            shop.TestPhone("Apple0", 40);

            Assert.That(() => shop.TestPhone("Apple0", 40), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(40)]
        [TestCase(100)]
        public void TestMethodShouldReducePhoneCurrentBatteryCharge(int batteryUsage)
        {
            var shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("Apple0", 100);
            shop.Add(smartphone1);
            int initialBatteryCharge = smartphone1.CurrentBateryCharge;

            shop.TestPhone("Apple0", batteryUsage);

            Assert.AreEqual(initialBatteryCharge-batteryUsage, smartphone1.CurrentBateryCharge );
        }

        [Test]
        public void ChargePhoneMethodShouldThrowExceptionIfPhoneDoesNotExist()
        {

            var shop = new Shop(2);

            Smartphone smartphone1 = new Smartphone("Apple0", 100);
            Smartphone smartphone2 = new Smartphone("Apple1", 100);

            shop.Add(smartphone1);
            shop.Add(smartphone2);

            Assert.That(() => shop.ChargePhone("Apple18"), Throws.InvalidOperationException);
        }

        [Test]
        public void ChargePhoneMethodShouldChargePhoneToMaximumCharge()
        {
            var shop = new Shop(2);
            Smartphone smartphone = new Smartphone("Apple2", 100);

            shop.Add(smartphone);
            shop.TestPhone("Apple2", 40);

            Assert.AreEqual(60, smartphone.CurrentBateryCharge);

            shop.ChargePhone("Apple2");

            Assert.AreEqual(100, smartphone.CurrentBateryCharge);
        }
    }
}