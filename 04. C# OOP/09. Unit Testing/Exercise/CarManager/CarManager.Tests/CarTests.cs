using NUnit.Framework;
using CarManager;

namespace Tests
{
    public class CarTests
    {
        //---------------------------Fields---------------------------
        private Car car;

        //---------------------------SET UP---------------------------
        [SetUp]
        public void Setup()
        {
            this.car = new Car("Mercedes", "CLS", 9, 70);
        }

        //---------------------------CONSTRUCTOR TESTS---------------------------
        [Test]
        [TestCase("Mercedes", "CLS", 9, 70)]
        public void ConstructorShouldInitializeCarMakeCorrectly(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Arrange
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Act
            Car expectedCar = new Car("Mercedes", "CLS", 9, 70);

            //Assert
            Assert.That(car.Make, Is.EqualTo(expectedCar.Make));
        }

        [Test]
        [TestCase("Mercedes", "CLS", 9, 70)]
        public void ConstructorShouldInitializeCarModelCorrectly(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Arrange
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Act
            Car expectedCar = new Car("Mercedes", "CLS", 9, 70);

            //Assert
            Assert.That(car.Model, Is.EqualTo(expectedCar.Model));
        }

        [Test]
        [TestCase("Mercedes", "CLS", 9, 70)]
        public void ConstructorShouldInitializeCarFuelConsumptionCorrectly(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Arrange
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Act
            Car expectedCar = new Car("Mercedes", "CLS", 9, 70);

            //Assert
            Assert.That(car.FuelConsumption, Is.EqualTo(expectedCar.FuelConsumption));
        }

        [Test]
        [TestCase("Mercedes", "CLS", 9, 70)]
        public void ConstructorShouldInitializeCarFuelCapacityCorrectly(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Arrange
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Act
            Car expectedCar = new Car("Mercedes", "CLS", 9, 70);

            //Assert
            Assert.That(car.FuelCapacity, Is.EqualTo(expectedCar.FuelCapacity));
        }

        //---------------------------SETTERS TESTS---------------------------
        [Test]
        [TestCase(null, "CLS", 9, 70)]
        [TestCase("", "CLS", 9, 70)]
        public void MakeSetterShouldThrowExceptionIfValueIsNullOrEmpty(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Arrange

            //Act

            //Assert
            Assert.That(() => this.car = new Car(make, model, fuelConsumption, fuelCapacity),
                Throws.ArgumentException.With.Message
                .EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        [TestCase("Mercedes", null, 9, 70)]
        [TestCase("Mercedes", "", 9, 70)]
        public void ModelSetterShouldThrowExceptionIfValueIsNullOrEmpty(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Arrange

            //Act

            //Assert
            Assert.That(() => this.car = new Car("Mercedes", "", 9, 70),
                Throws.ArgumentException.With.Message
                .EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        [TestCase("Mercedes", "CLS", 0, 70)]
        [TestCase("Mercedes", "CLS", -20, 70)]
        public void FuelConsumptionSetterShouldThrowExceptionIfValueIsNullOrEmpty(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Arrange

            //Act

            //Assert
            Assert.That(() => this.car = new Car(make, model, fuelConsumption, fuelCapacity),
                Throws.ArgumentException.With.Message
                .EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        [TestCase("Mercedes", "CLS", 9, 0)]
        [TestCase("Mercedes", "CLS", 9, -20)]
        public void FuelCapacitySetterShouldThrowExceptionIfValueIsNullOrEmpty(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Arrange

            //Act

            //Assert
            Assert.That(() => this.car = new Car(make, model, fuelConsumption, fuelCapacity),
                Throws.ArgumentException.With.Message
                .EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        //---------------------------REFUEL OPERATION TESTS---------------------------
        [Test]
        public void RefuelOperationShouldRefuelCar()
        {
            //Arrange
            this.car = new Car("Mercedes", "CLS", 9, 70);

            //Act
            double fuelToRefuel = 30;
            this.car.Refuel(fuelToRefuel);

            double actualResult = this.car.FuelAmount;
            double expectedResult = fuelToRefuel;

            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void RefuelOperationShouldNotPutMoreFuelThanCapacityOfCar()
        {
            //Arrange
            this.car = new Car("Mercedes", "CLS", 9, 70);

            //Act
            double fuelToRefuel = 90;
            this.car.Refuel(fuelToRefuel);

            double expectedResult = 70;
            double actualResult = this.car.FuelAmount;

            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void RefuelOperationShouldThrowExceptionIfInputAmountIsZeroOrNegative()
        {
            //Arrange
            this.car = new Car("Mercedes", "CLS", 9, 70);

            //Act
            double fuelToRefuel = -20;

            //Assert
            Assert.That(() => this.car.Refuel(fuelToRefuel),
                Throws.ArgumentException.With.Message
                .EqualTo("Fuel amount cannot be zero or negative!"));
        }

        //---------------------------DRIVE OPERATION TESTS---------------------------
        [Test]
        public void DriveOperationShouldDriveCarNormally()
        {
            //Arrange
            this.car = new Car("Mercedes", "CLS", 9, 70);

            //Act
            this.car.Refuel(25);
            double distance = 30;
            double fuelNeeded = 2.7;
            this.car.Drive(distance);

            double expectedResult = 25 - fuelNeeded;
            double actualResult = this.car.FuelAmount;

            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void DriveOperationShouldThrowExceptionIfFuelIsNotEnough()
        {
            //Arrange
            this.car = new Car("Mercedes", "CLS", 9, 70);

            //Act
            this.car.Refuel(5);
            double distance = 100;
            double fuelNeeded = 9;

            //Assert
            Assert.That(() => this.car.Drive(distance),
                Throws.InvalidOperationException.With.Message
                .EqualTo("You don't have enough fuel to drive!"));
        }
    }
}