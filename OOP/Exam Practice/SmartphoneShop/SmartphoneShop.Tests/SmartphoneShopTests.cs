using System.Text;
using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Shop fullShop;
        private Shop shopWithTwoPhones;
        private Smartphone smartphoneNotInShop;
        private Smartphone existingSmartphone;
        [SetUp]
        public void Init()
        {
            fullShop = new Shop(10);

            for (int i = 0; i < 10; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Apple");
                sb.Append(i.ToString());
                Smartphone smartphone = new Smartphone(sb.ToString(), 100);

                fullShop.Add(smartphone);
            }
            
            shopWithTwoPhones = new Shop(10);

            for (int i = 0; i < 2; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Apple");
                sb.Append(i.ToString());
                Smartphone smartphone = new Smartphone(sb.ToString(), 100);

                shopWithTwoPhones.Add(smartphone);
            }

            smartphoneNotInShop = new Smartphone("Apple18", 100);
            existingSmartphone = new Smartphone("Apple0", 100);
        }
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
            Assert.That(() => shopWithTwoPhones.Add(existingSmartphone), Throws.InvalidOperationException);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfShopIsAlreadyFull()
        {
            Assert.That(() => fullShop.Add(smartphoneNotInShop), Throws.InvalidOperationException);
        }

        [Test]
        public void AddMethodShouldIncreaseCount()
        {
            shopWithTwoPhones.Add(smartphoneNotInShop);
            Assert.AreEqual(3, shopWithTwoPhones.Count);
            Assert.AreEqual(10, fullShop.Capacity);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfPhoneToRemoveDoesNotExist()
        {
            Assert.That(()=> shopWithTwoPhones.Remove("Apple18"), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveMethodShouldRemovePhoneAndReduceCount()
        {
            shopWithTwoPhones.Remove("Apple0");
            Assert.AreEqual(1, shopWithTwoPhones.Count);
        }

        [Test]
        public void TestPhoneMethodShouldThrowExceptionIfPhoneDoesNotExist()
        {
            string modelName = "Apple18";
            Assert.That(()=> shopWithTwoPhones.TestPhone(modelName, 50), Throws.InvalidOperationException);
        }

        [Test]
        public void TestPhoneMethodShouldThrowExceptionIfBatteryChargeIsLessThanBatteryUsage()
        {
            shopWithTwoPhones.TestPhone(existingSmartphone.ModelName, 40);
            shopWithTwoPhones.TestPhone(existingSmartphone.ModelName, 40);

            Assert.That(() => shopWithTwoPhones.TestPhone(existingSmartphone.ModelName, 40), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(40)]
        [TestCase(100)]
        public void TestMethodShouldReducePhoneCurrentBatteryCharge(int batteryUsage)
        {
            Smartphone smartphone = new Smartphone("Apple2", 100);
            int initialBatteryCharge = smartphone.CurrentBateryCharge;

            shopWithTwoPhones.Add(smartphone);
            shopWithTwoPhones.TestPhone("Apple2", batteryUsage);

            Assert.AreEqual(initialBatteryCharge-batteryUsage, smartphone.CurrentBateryCharge );
        }

        [Test]
        public void ChargePhoneMethodShouldThrowExceptionIfPhoneDoesNotExist()
        {
            Assert.That(() => shopWithTwoPhones.ChargePhone(smartphoneNotInShop.ModelName), Throws.InvalidOperationException);
        }

        [Test]
        public void ChargePhoneMethodShouldChargePhoneToMaximumCharge()
        {
            Smartphone smartphone = new Smartphone("Apple2", 100);
            shopWithTwoPhones.Add(smartphone);
            shopWithTwoPhones.TestPhone("Apple2", 40);

            shopWithTwoPhones.ChargePhone("Apple2");

            Assert.AreEqual(100, smartphone.CurrentBateryCharge);
        }
        
    }
}