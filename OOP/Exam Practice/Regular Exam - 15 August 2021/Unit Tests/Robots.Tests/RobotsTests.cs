using NUnit.Framework;

namespace Robots.Tests
{
    using System;
    [TestFixture]
    public class RobotsTests
    {
       
        [Test]
        public void ConstructorShouldCreateEmptyListWithProvidedCapacity()
        {
            RobotManager robotManager = new RobotManager(10);
            Assert.AreEqual(10, robotManager.Capacity);
        }

        [Test]
        public void ConstructorShouldThrowExceptionIfNegativeCapacityProvided()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-50));
        }

        [Test]
        public void EmptyRobotManagerShouldHaveCountOfZero()
        {
            var robotManager = new RobotManager(10);
            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void RobotManagerShouldHaveProperCount()
        {
            var robotManager = new RobotManager(10);
            robotManager.Add(new Robot("r1", 100));
            robotManager.Add(new Robot("r2", 100));
            robotManager.Add(new Robot("r3", 100));
            robotManager.Add(new Robot("r4", 100));

            Assert.AreEqual(4, robotManager.Count);
        }
        [Test]
        public void AddMethodShouldThrowExceptionIfRobotAlreadyExists()
        {
            RobotManager robotManager = new RobotManager(2);

            robotManager.Add(new Robot("R2-D2", 100));

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot("R2-D2", 500)));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfAtMaximumCapacity()
        {
            RobotManager robotManager = new RobotManager(2);

            robotManager.Add(new Robot("R2-D2", 100));
            robotManager.Add(new Robot("Sam", 50));

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot("r2", 500)));
        }

        [Test]
        public void AddMethodShouldIncreaseCount()
        {
            RobotManager robotManager = new RobotManager(4);
            Robot robot1 = new Robot("R2-D2", 100);
            Robot robot2 = new Robot("Sam", 50);
            Robot robot3 = new Robot("Becky", 50);

            robotManager.Add(robot1);
            robotManager.Add(robot2);

            Assert.AreEqual(2, robotManager.Count);

            robotManager.Add(robot3);

            Assert.AreEqual(3, robotManager.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfRobotDoesNotExist()
        {
            RobotManager robotManager = new RobotManager(2);

            robotManager.Add(new Robot("R2-D2", 100));
            robotManager.Add(new Robot("Sam", 50));

            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("Becky"));
        }

        [Test]
        public void RemoveMethodShouldDecreaseCount()
        {
            RobotManager robotManager = new RobotManager(3);

            robotManager.Add(new Robot("R2-D2", 100));
            robotManager.Add(new Robot("Sam", 50));
            robotManager.Add(new Robot("Becky", 50));

            robotManager.Remove("Sam");

            Assert.AreEqual(2, robotManager.Count);

            robotManager.Remove("Becky");

            Assert.AreEqual(1, robotManager.Count);
        }

        [Test]
        public void WorkMethodShouldThrowExceptionIfRobotDoesNotExist()
        {
            RobotManager robotManager = new RobotManager(2);

            robotManager.Add(new Robot("R2-D2", 100));
            robotManager.Add(new Robot("Sam", 50));

            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Becky", "Clean", 60));
        }

        [Test]
        public void WorkMethodShouldThrowExceptionIfBatteryNotEnough()
        {
            RobotManager robotManager = new RobotManager(2);

            robotManager.Add(new Robot("R2", 100));

            Assert.Throws<InvalidOperationException>(() => robotManager.Work("R2", "Clean", 105));
        }

        [Test]
        public void WorkMethodShouldReduceRobotBattery()
        {
            RobotManager robotManager = new RobotManager(2);
            Robot robot1 = new Robot("R2-D2", 100);

            robotManager.Add(robot1);

            robotManager.Work("R2-D2", "Clean", 40);
            Assert.AreEqual(60, robot1.Battery);
        }

        [Test]
        public void ChargeMethodShouldThrowExceptionIfRobotDoesNotExist()
        {
            RobotManager robotManager = new RobotManager(2);

            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("Becky"));
        }

        [Test]
        public void ChargeMethodShouldIncreaseRobotBattery()
        {
            RobotManager robotManager = new RobotManager(2);
            Robot robot1 = new Robot("R2-D2", 100);

            robotManager.Add(robot1);

            robotManager.Work("R2-D2", "Clean", 40);
            robotManager.Work("R2-D2", "Clean", 40);

            Assert.AreEqual(20, robot1.Battery);

            robotManager.Charge("R2-D2");

            Assert.AreEqual(100, robot1.Battery);
        }
    }
}
