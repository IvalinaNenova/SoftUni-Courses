using System;
using NUnit.Framework;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [Test]
        public void ConstructorShouldCreateGymWithValidData()
        {
            Gym gym = new Gym("Hercules", 4);

            Assert.That(gym, Is.Not.Null);
            Assert.AreEqual("Hercules", gym.Name);
            Assert.AreEqual(4, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void NamePropertyShouldThrowExceptionIfNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(()=> new Gym(name, 4));
        }

        [Test]
        public void CapacityPropertyShouldThrowExceptionIfNegativeCapacityProvided()
        {
            Assert.Throws<ArgumentException>(() => new Gym("Hercules", -1));
        }

        [Test]
        public void AddAthleteMethodShouldThrowExceptionIfGymIsAtFullCapacity()
        {
            Gym gym = new Gym("Hercules", 2);
            gym.AddAthlete(new Athlete("John"));
            gym.AddAthlete(new Athlete("Peter"));

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("Liam")));
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfAthleteDoesNotExist()
        {
            Gym gym = new Gym("Hercules", 2);
            gym.AddAthlete(new Athlete("John"));
            gym.AddAthlete(new Athlete("Peter"));

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Liam"));
        }

        [Test]
        public void RemoveMethodShouldReduceCountOfAthletes()
        {
            Gym gym = new Gym("Hercules", 2);

            gym.AddAthlete(new Athlete("John"));
            gym.AddAthlete(new Athlete("Peter"));

            gym.RemoveAthlete("John");

            Assert.AreEqual(1, gym.Count);
        }
        [Test]
        public void InjureMethodShouldThrowExceptionIfAthleteDoesNotExist()
        {
            Gym gym = new Gym("Hercules", 2);

            gym.AddAthlete(new Athlete("John"));
            gym.AddAthlete(new Athlete("Peter"));

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Liam"));
        }
        [Test]
        public void InjureMethodShouldReturnInjuredAthlete()
        {
            Gym gym = new Gym("Hercules", 2);

            gym.AddAthlete(new Athlete("John"));
            gym.AddAthlete(new Athlete("Peter"));

            Athlete injuredAthlete = gym.InjureAthlete("John");

            Assert.AreEqual(true, injuredAthlete.IsInjured);
            Assert.AreEqual("John", injuredAthlete.FullName);
        }

        [Test]
        public void ReportMethodShouldReturnInformationAboutGymAndAthletesInIt()
        {
            Gym gym = new Gym("Hercules", 3);

            gym.AddAthlete(new Athlete("John"));
            gym.AddAthlete(new Athlete("Peter"));
            gym.AddAthlete(new Athlete("Kyle"));

            Athlete injuredAthlete = gym.InjureAthlete("John");

            string report = gym.Report();

            Assert.AreEqual("Active athletes at Hercules: Peter, Kyle", report);
        }
    }
}
