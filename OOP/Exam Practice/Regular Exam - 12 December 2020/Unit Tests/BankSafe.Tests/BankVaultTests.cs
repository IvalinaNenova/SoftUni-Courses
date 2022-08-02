using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        [SetUp]
        public void Setup()
        {
            vault = new BankVault();
        }

        [Test]
        public void ConstructorShouldCreateDictionaryWithNullValues()
        {
            Assert.That(vault.VaultCells.Values.All(v=> v == null));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => vault.AddItem("D1", new Item("Mary", "1234")));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfCellAlreadyTaken()
        {
            vault.AddItem("A1", new Item("Mary", "1234"));
            Assert.Throws<ArgumentException>(() => vault.AddItem("A1", new Item("Iva", "56787")));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfItemAlreadyExists()
        {
            vault.AddItem("A1", new Item("Mary", "1234"));
            vault.AddItem("A2", new Item("Iva", "56787"));

            Assert.Throws<InvalidOperationException>(() => vault.AddItem("C1", new Item("Iva", "56787")));
        }

        [Test]
        public void AddMethodShouldAddItemInEmptyCell()
        {
            vault.AddItem("A1", new Item("Mary", "1234"));
            Assert.That(vault.VaultCells["A1"] != null);
        }

        [Test]
        public void AddMethodShouldReturnCorrectMessage()
        {
            string message = vault.AddItem("A1", new Item("Mary", "1234"));

            Assert.AreEqual($"Item:1234 saved successfully!", message);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => vault.RemoveItem("D1", new Item("Mary", "1234")));
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfWrongItemInCell()
        {
            Item item1 = new Item("Mary", "1234");
            Item item2 = new Item("Iva", "4567");

            vault.AddItem("A1", item1);

            Assert.Throws<ArgumentException>(() => vault.RemoveItem("A1", item2));
        }

        [Test]
        public void RemoveMethodShouldRemoveItemFromCell()
        {
            Item item1 = new Item("Mary", "1234");

            vault.AddItem("A1", item1);
            Assert.That(vault.VaultCells["A1"] == item1);

            vault.RemoveItem("A1", item1);
            Assert.AreEqual(null, vault.VaultCells["A1"]);
        }
    }
}