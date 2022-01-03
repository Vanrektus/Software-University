namespace Robots.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class RobotsTests
    {
        private RobotManager robotManager;

        //Constructor
        [SetUp]
        public void ConstructorSetup()
        {
            this.robotManager = new RobotManager(2);
        }

        //Setters
        [Test]
        public void CapacitySetter()
        {
            Assert.That(() => this.robotManager = new RobotManager(-3),
                Throws.ArgumentException);
        }

        //Add method
        [Test]
        public void AddRobotCorrect()
        {
            Robot robot = new Robot("Pesho", 100);

            this.robotManager.Add(robot);

            Assert.That(this.robotManager.Count == 1);
        }

        [Test]
        public void AddRobotDuplicateException()
        {
            Robot robot = new Robot("Pesho", 100);
            Robot robot2 = new Robot("Pesho", 100);

            this.robotManager.Add(robot);

            Assert.That(() => this.robotManager.Add(robot2),
                Throws.InvalidOperationException);
        }

        [Test]
        public void AddRobotCapacityException()
        {
            Robot robot = new Robot("Pesho", 100);
            Robot robot2 = new Robot("Pesho2", 100);
            Robot robot3 = new Robot("Pesho3", 100);

            this.robotManager.Add(robot);
            this.robotManager.Add(robot2);
            Assert.That(() => this.robotManager.Add(robot3),
                Throws.InvalidOperationException);
        }

        //Remove method
        [Test]
        public void RemoveRobotCorrect()
        {
            Robot robot = new Robot("Pesho", 100);

            this.robotManager.Add(robot);
            this.robotManager.Remove("Pesho");

            Assert.That(this.robotManager.Count == 0);
        }

        [Test]
        public void RemoveRobotNullException()
        {
            Assert.That(() => this.robotManager.Remove(null),
                Throws.InvalidOperationException);
        }

        //Work method
        [Test]
        public void WorkRobotMethodCorrect()
        {
            Robot robot = new Robot("Pesho", 100);

            this.robotManager.Add(robot);
            this.robotManager.Work("Pesho", "Fly", 50);

            Assert.That(robot.Battery, Is.EqualTo(50));
        }

        [Test]
        public void WorRobotNullException()
        {
            Assert.That(() => this.robotManager.Work("Pesho", "Fly", 50),
                Throws.InvalidOperationException);
        }

        [Test]
        public void WorkRobotNotEnoughBatteryException()
        {
            Robot robot = new Robot("Pesho", 100);

            this.robotManager.Add(robot);

            Assert.That(() => this.robotManager.Work("Pesho", "Fly", 150),
                Throws.InvalidOperationException);
        }

        //Charge method
        [Test]
        public void ChargeRobotCorrect()
        {
            Robot robot = new Robot("Pesho", 100);

            this.robotManager.Add(robot);
            this.robotManager.Work("Pesho", "Fly", 50);
            this.robotManager.Charge("Pesho");

            Assert.That(robot.Battery, Is.EqualTo(100));
        }

        [Test]
        public void ChargeRobotNullException()
        {
            Assert.That(() => this.robotManager.Charge(null),
                Throws.InvalidOperationException);
        }
    }
}
