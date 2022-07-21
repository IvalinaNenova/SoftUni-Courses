using System;
using System.Reflection;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior1;
        private Warrior warrior2;
        private Warrior notEnrolledWarrior;
        [SetUp] 
        public void Init()
        {
            arena = new Arena();

            warrior1 = new Warrior("Alec", 50, 100);
            warrior2 = new Warrior("Bobby", 40, 80);
            notEnrolledWarrior = new Warrior("Steve", 40, 100);
            
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
        }
        [Test]
        public void ConstructorShouldCreateEmptyCollection()
        {
            arena = new Arena();
            Assert.That(0, Is.EqualTo(arena.Count));
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionIfWarriorAlreadyEnrolled()
        {
            Assert.That(() => arena.Enroll(warrior1), Throws.InvalidOperationException.With.Message.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        [TestCase("Alec", "Steve")]
        [TestCase("Steve", "Bobby")]
        public void FightMethodShouldThrowExceptionIfOneOfTheWarriorsIsNotEnrolled(string warrior1Name, string warrior2Name)
        {
            Assert.That(() => arena.Fight(warrior1Name, warrior2Name), Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {notEnrolledWarrior.Name} enrolled for the fights!"));
        }

        [Test]
        public void FightMethodShouldAllowAWarriorToAttackIfBothWarriorsAreEnrolled()
        {
            arena.Fight("Alec", "Bobby");

            Assert.AreEqual(60, warrior1.HP);
            Assert.AreEqual(30, warrior2.HP);
        }

        [Test]
        public void WarrioirsCollectionShouldBeReadOnly()
        {
            Type type = typeof(Arena);
            PropertyInfo property = type.GetProperty("Warriors");

            Assert.That(property.CanWrite == false);
        }
    }
}
