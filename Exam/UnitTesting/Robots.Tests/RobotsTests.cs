namespace Robots.Tests
{
    using NUnit.Framework;
    using Robots;
    using System;
    [TestFixture]
    public class RobotsTests
    {
        private RobotManager robotManager;
        [SetUp]
        public void SetUp()
        {
            robotManager = new RobotManager(10);
        }
        [Test]
        public void CtorWorksFine()
        {
            Assert.That(robotManager.Count, Is.EqualTo(0));
            Assert.That(robotManager.Capacity, Is.EqualTo(10));
        }
        [Test]
        public void GetterCapacityWorksFine()
        {
            Assert.That(robotManager.Capacity, Is.EqualTo(10));
        }
        [Test]
        public void SetterCapacityThrowsEx()
        {
            Assert.That(() => robotManager = new RobotManager(-2), Throws.ArgumentException);
        }
        [Test]
        public void SetterCapacityWorksFine()
        {
            robotManager = new RobotManager(3);
            Assert.That(robotManager.Capacity, Is.EqualTo(3));
        }
        [Test]
        public void GetterCountWorksFine()
        {
            Robot robot = new Robot("Gosho", 10);
            Robot robot1 = new Robot("Moisho", 20);
            robotManager.Add(robot);
            robotManager.Add(robot1);
            Assert.That(robotManager.Count, Is.EqualTo(2));
        }
        [Test]
        public void AddThrowsExWhenExists()
        {
            Robot robot = new Robot("Gosho", 10);
            Robot robot1 = new Robot("Gosho", 20);
            robotManager.Add(robot);
            Assert.That(() => robotManager.Add(robot1), Throws.InvalidOperationException);
        }
        [Test]
        public void AddThrowsExWhenOverflow()
        {
            robotManager = new RobotManager(1);
            Robot robot = new Robot("Gosho", 10);
            Robot robot1 = new Robot("MIsho", 20);
            robotManager.Add(robot);
            Assert.That(() => robotManager.Add(robot1), Throws.InvalidOperationException);
        }
        [Test]
        public void AddWorksFine()
        {
            Robot robot = new Robot("Gosho", 10);
            Robot robot1 = new Robot("MIsho", 20);
            robotManager.Add(robot);
            robotManager.Add(robot1);
            Assert.That(robotManager.Count, Is.EqualTo(2));
        }
        [Test]
        public void RemoveThrowsExWhenDoesntExists()
        {
            Assert.That(() => robotManager.Remove("Goo"), Throws.InvalidOperationException);
        }
        [Test]
        public void RemoveWorksFine()
        {
            Robot robot = new Robot("Gosho", 10);
            Robot robot1 = new Robot("MIsho", 20);
            robotManager.Add(robot);
            robotManager.Add(robot1);
            robotManager.Remove("Gosho");
            Assert.That(robotManager.Count, Is.EqualTo(1));
        }
        [Test]
        public void WorksThrowsExWhenDoesntExists()
        {
            Assert.That(() => robotManager.Work("Goo", "kopaene", 3), Throws.InvalidOperationException);
        }
        [Test]
        public void WorksThrowsExWhenBatteryIsSmaller()
        {

            Robot robot = new Robot("Gosho", 5);
            robotManager.Add(robot);
            Assert.That(() => robotManager.Work("Gosho", "kopaene", 20), Throws.InvalidOperationException);
        }
        [Test]
        public void WorksWorksFine()
        {

            Robot robot = new Robot("Gosho", 20);
            robotManager.Add(robot);
            robotManager.Work("Gosho", "kopaene", 10);
            Assert.That(robot.Battery, Is.EqualTo(10));
        }
        [Test]
        public void ChargeThrowsExWhenDoesntExists()
        {
            Assert.That(() => robotManager.Charge("Goo"), Throws.InvalidOperationException);
        }
        [Test]
        public void ChargeWorksFine()
        {
            Robot robot = new Robot("Gosho", 20);
            robotManager.Add(robot);
            robotManager.Work("Gosho", "kopaene", 10);
            robotManager.Charge("Gosho");
            Assert.That(robot.Battery,Is.EqualTo(20)); ;
        }
    }
}
