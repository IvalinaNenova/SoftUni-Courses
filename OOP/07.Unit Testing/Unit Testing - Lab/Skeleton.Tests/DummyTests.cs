using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyShouldLooseHealthWhenAttacked()
        {
            Dummy dummy = new Dummy(10, 10);
            dummy.TakeAttack(5);

            Assert.AreEqual(5, dummy.Health);
        }
        [Test]
        public void DeadDummyShouldThrowExceptionWhenAttacked()
        {
            Dummy dummy = new Dummy(0, 10);

            //Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(5));

            Assert.That(()=> dummy.TakeAttack(5), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }
        [Test]
        public void DeadDummyShouldGiveXp()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.AreEqual(10, dummy.GiveExperience());
        }
        [Test]
        public void AliveDummyShouldNotGiveXp()
        {
            Dummy dummy = new Dummy(10, 10);

            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));

        }
    }
}