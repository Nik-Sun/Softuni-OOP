namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class RobotsTests
    {
        [TestCase("Pesho",12)]
        [TestCase("Gosho",-12)]
        public void RobotCtorShouldSetValuesCorrectly(string name,int battery)
        {
            //Arrange && Act
            Robot robot = new Robot(name,battery);

            //Assert
            Assert.AreEqual(name,robot.Name);
            Assert.AreEqual(battery,robot.Battery);
            Assert.AreEqual(battery,robot.MaximumBattery);
        }
        [Test]
        public void RobotManagerCtorShouldSetCapacityCorrectly()
        {
            //Arrange && Act
            RobotManager robotManager = new RobotManager(15);

            //Assert
            Assert.AreEqual(15,robotManager.Capacity);

        }
        [Test]
        public void RobotManagerCtorThrowExceptionForNegativeCapacity()
        {
            // Arrange 
            RobotManager robotManager;

            // Assert
            Assert.Throws<ArgumentException>(() => robotManager = new RobotManager(-15), "Invalid capacity!");

        }
        [Test]
        public void RobotManagerCountShouldGetCorrectCount()
        {
            // Arrange 
            RobotManager robotManager = new RobotManager(15);

            // Assert
            Assert.AreEqual(0,robotManager.Count);

        }
        [Test]
        public void RobotManagerAddShouldAddRobotToTheRepository()
        {
            // Arrange 
            RobotManager robotManager = new RobotManager(15);
            Robot robot = new Robot("Pesho", 50);

            //Act
            robotManager.Add(robot);

            // Assert
            Assert.AreEqual(1, robotManager.Count);

        }
        [Test]
        public void RobotManagerShouldThrowExceptionForDuplicateRobots()
        {
            // Arrange 
            RobotManager robotManager = new RobotManager(15);
            Robot robot = new Robot("Pesho", 50);
            robotManager.Add(robot);

            // Act && Assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot), $"There is already a robot with name {robot.Name}!");
        }
        [Test]
        public void RobotManagerAddShouldThrowExceptionForAddingRobotWhenCapacityIsReached()
        {
            // Arrange 
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Pesho", 50);
            Robot robot1 = new Robot("Gosho", 40);
            robotManager.Add(robot);

            // Act && Assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot1), "Not enough capacity!");
        }
        [Test]
        public void RobotManagerRemoveShouldRemoveRobotByName()
        {
            // Arrange 
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Pesho", 50);
            robotManager.Add(robot);

            //Act
            robotManager.Remove("Pesho");

            //  Assert
            Assert.AreEqual(0,robotManager.Count);
        }
        [Test]
        public void RobotManagerRemoveShouldThrowExceptionWhenRobotDoesNotExistsInTheRepository()
        {
            // Arrange 
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Pesho", 50);
            robotManager.Add(robot);


            // Act && Assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("Gosho"), $"Robot with the name Gosho doesn't exist!");
        }
        [Test]
        public void RobotManagerWorkShouldReduceBatteryPowerByGivvenAmount()
        {
            // Arrange 
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Pesho", 50);
            robotManager.Add(robot);

            // Act
            robotManager.Work("Pesho","TestJob",10);

            // Assert
            Assert.AreEqual(40,robot.Battery);
        }
        [Test]
        public void RobotManagerWorkShouldThrowExceptionForNonExistingRobot()
        {
            // Arrange 
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Pesho", 50);
            robotManager.Add(robot);

            
            //Act && Assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Gosho", "TestJob", 10), "Robot with the name Gosho doesn't exist!");
        }
        [Test]
        public void RobotManagerWorkShouldThrowExceptionWhenRobotDoesNotHaveEnoughPower()
        {
            // Arrange 
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Pesho", 5);
            robotManager.Add(robot);


            //Act && Assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Pesho", "TestJob", 10), $"{robot.Name} doesn't have enough battery!");
        }
        [Test]
        public void RobotManagerChargeShouldChargeBatteryToMaximumCapacity()
        {
            // Arrange 
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Pesho", 5);
            robotManager.Add(robot);

            //Act
            robotManager.Work("Pesho","TestJob",5);
            robotManager.Charge("Pesho");

            //Assert
            Assert.AreEqual(robot.MaximumBattery,robot.Battery);
        }
        public void RobotManagerChargeShouldThrowExceptionForNonExistingRobot()
        {
            // Arrange 
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Pesho", 5);
            robotManager.Add(robot);


            //Act && Assert
            Assert.Throws<InvalidOperationException>(()=> robotManager.Charge("Gosho"), "Robot with the name Gosho doesn't exist!");
        }
    }
}
