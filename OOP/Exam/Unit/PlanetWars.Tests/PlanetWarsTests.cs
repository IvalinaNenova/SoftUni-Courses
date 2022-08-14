using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void ConstructorShouldWorkProperly()
            {
                Planet planet = new Planet("Mars", 100.5);
                Assert.That(planet, Is.Not.Null);
                Assert.AreEqual(0, planet.Weapons.Count);
            }

            [Test]
            [TestCase(null)]
            [TestCase("")]
            public void NamePropertyShouldThrowExceptionIfInvalidName(string name)
            {
                Assert.Throws<ArgumentException>(() => new Planet(name, 100.5));
            }

            [Test]
            public void BudgetPropertyShouldThrowExceptionIfNegative()
            {
                Assert.Throws<ArgumentException>(() => new Planet("Mars", -5));
            }

            [Test]
            public void WeaponPriceShouldThrowExceptionIfNegative()
            {
                Assert.Throws<ArgumentException>(() => new Weapon("Gun", -5.8, 60));
            }

            [Test]
            [TestCase(10)]
            [TestCase(11)]
            public void IsNuclearPropertyShouldWorkCorrectly(int destruction)
            {
                Weapon weapon = new Weapon("Laser", 15.5, destruction);

                Assert.AreEqual(true, weapon.IsNuclear);
            }

            [Test]
            public void MilitaryPowerRatioShouldReturnCorrectSum()
            {
                Planet planet = new Planet("Mars", 100.5);
                planet.AddWeapon(new Weapon("Gun", 15.8, 50));
                planet.AddWeapon(new Weapon("Laser", 117.2, 60));

                Assert.AreEqual(110, planet.MilitaryPowerRatio);
            }

            [Test]
            public void ProfitMethodShouldWorkProperly()
            {
                Planet planet = new Planet("Mars", 100.5);
                planet.Profit(15.5);
                Assert.AreEqual(116, planet.Budget);
            }

            [Test]
            public void SpendFundsShouldThrowExceptionIfNotEnoughBudget()
            {
                Planet planet = new Planet("Mars", 100.5);
                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(150.2));
            }

            [Test]
            public void SpendFundsShouldDecreseBudget()
            {
                Planet planet = new Planet("Mars", 100.5);
                planet.SpendFunds(50.5);
                Assert.AreEqual(50, planet.Budget);
            }

            [Test]
            public void AddWeaponShouldThrowExceptionIfWeaponExists()
            {
                Planet planet = new Planet("Mars", 100.5);
                planet.AddWeapon(new Weapon("Gun", 15.8, 50));
                planet.AddWeapon(new Weapon("Laser", 117.2, 60));

                Weapon weaponToAdd = new Weapon("Laser", 12.8, 66);

                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weaponToAdd));
            }

            [Test]
            public void AddMethodShouldWorkProperly()
            {
                Planet planet = new Planet("Mars", 100.5);
                planet.AddWeapon(new Weapon("Gun", 15.8, 50));
                planet.AddWeapon(new Weapon("Laser", 117.2, 60));

                Assert.AreEqual(2, planet.Weapons.Count);
            }

            [Test]
            public void RemoveMethodShouldWorkProperly()
            {
                Planet planet = new Planet("Mars", 100.5);
                planet.AddWeapon(new Weapon("Gun", 15.8, 50));
                planet.AddWeapon(new Weapon("Laser", 117.2, 60));

                planet.RemoveWeapon("Laser");

                Assert.AreEqual(1, planet.Weapons.Count);
            }

            [Test]
            public void UpgradeMethodShouldThrowExceptionIfWeaponNotInRepository()
            {
                Planet planet = new Planet("Mars", 100.5);
                planet.AddWeapon(new Weapon("Gun", 15.8, 50));
                planet.AddWeapon(new Weapon("Laser", 117.2, 60));

                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("WaterGun"));
            }

            [Test]
            public void UpgradeWeaponShouldWorkProperly()
            {
                Planet planet = new Planet("Mars", 100.5);
                Weapon weapon1 = new Weapon("Gun", 15.8, 50);
                Weapon weapon2 = new Weapon("Laser", 117.2, 60);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                planet.UpgradeWeapon("Laser");
                Assert.AreEqual(61, weapon2.DestructionLevel );
            }

            [Test]
            [TestCase(50, 60)]
            [TestCase(51, 60)]
           
            public void DestructOpponentShouldThrowExceptionIfNotEnoughPower(int weapon1, int weapon2)
            {
                Planet attacker = new Planet("Mars", 100.5);
                Planet defender = new Planet("Earth", 200.3);

                attacker.AddWeapon(new Weapon("Gun", 15.8, 50));
                attacker.AddWeapon(new Weapon("Laser", 117.2, 60));

                defender.AddWeapon(new Weapon("Laser", 117.2, weapon1));
                defender.AddWeapon(new Weapon("WaterGun", 117.2, weapon2));

                Assert.Throws<InvalidOperationException>(() => attacker.DestructOpponent(defender));
            }

            [Test]
            public void DestructOpponentShoudReturnCorrectString()
            {
                Planet attacker = new Planet("Mars", 100.5);
                Planet defender = new Planet("Earth", 200.3);

                attacker.AddWeapon(new Weapon("Gun", 15.8, 50));
                attacker.AddWeapon(new Weapon("Laser", 117.2, 60));

                defender.AddWeapon(new Weapon("Laser", 117.2, 40));
                defender.AddWeapon(new Weapon("WaterGun", 117.2, 30));

                string resultMessage = attacker.DestructOpponent(defender);
                Assert.AreEqual("Earth is destructed!", resultMessage);
            }
        }
    }
}
