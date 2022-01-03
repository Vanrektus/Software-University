using NUnit.Framework;
using System;
//using ExtendedDatabase;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        //---------------------------Constants---------------------------
        private const int databaseCapacity = 16;

        //---------------------------Fields---------------------------
        private Person[] people;
        private Person person;
        private ExtendedDatabase extendedDatabase;

        //---------------------------SET UP---------------------------
        [SetUp]
        public void Setup()
        {
            this.extendedDatabase = new ExtendedDatabase();
        }

        //---------------------------CONSTRUCTOR TESTS--------------------------------
        [Test]
        public void ConstructorShouldInitializeDatabaseWith16People()
        {
            //Arrange
            this.people = new Person[]
                {
                    new Person(123, "Pesho"),
                    new Person(234, "Gesho"),
                    new Person(345, "Tesho"),
                    new Person(456, "asd"),
                    new Person(567, "qwe"),
                    new Person(678, "zxc"),
                    new Person(789, "fgh"),
                    new Person(890, "yui"),
                    new Person(90, "vbn"),
                    new Person(12, "jkl"),
                    new Person(23, "rty"),
                    new Person(34, "dfg"),
                    new Person(45, "ghj"),
                    new Person(56, "cvb"),
                    new Person(67, "uio"),
                    new Person(78, "wer"),
                };
            this.extendedDatabase = new ExtendedDatabase(people);

            //Act

            //Assert
            Assert.That(this.extendedDatabase.Count, Is.EqualTo(databaseCapacity));
        }

        //---------------------------ADD OPERATION TESTS--------------------------------
        [Test]
        public void AddOperationExceeding16ElementsShouldThrowException()
        {
            //Arrange
            this.people = new Person[]
                {
                    new Person(123, "Pesho"),
                    new Person(234, "Gesho"),
                    new Person(345, "Tesho"),
                    new Person(456, "asd"),
                    new Person(567, "qwe"),
                    new Person(678, "zxc"),
                    new Person(789, "fgh"),
                    new Person(890, "yui"),
                    new Person(90, "vbn"),
                    new Person(12, "jkl"),
                    new Person(23, "rty"),
                    new Person(34, "dfg"),
                    new Person(45, "ghj"),
                    new Person(56, "cvb"),
                    new Person(67, "uio"),
                    new Person(89, "tyu"),
                };
            this.extendedDatabase = new ExtendedDatabase(people);

            //Act

            //Assert
            Assert.That(() => this.extendedDatabase.Add(new Person(12345, "Wow")),
                Throws.InvalidOperationException.With.Message
                .EqualTo("Array's capacity must be exactly 16 integers!"));
        }
              

        [Test]
        public void AddOperationShouldThrowExceptionIfUsernameAlreadyExists()
        {
            //Arrange
            this.person = new Person(123, "Pesho");

            //Act
            this.extendedDatabase.Add(person);
            Person newPerson = new Person(908, "Pesho");

            //Assert
            Assert.That(() => this.extendedDatabase.Add(newPerson),
                Throws.InvalidOperationException.With.Message
                .EqualTo("There is already user with this username!"));
        }

        [Test]
        public void AddOperationShouldThrowExceptionIfIDAlreadyExists()
        {
            //Arrange
            this.person = new Person(123, "Pesho");

            //Act
            this.extendedDatabase.Add(person);
            Person newPerson = new Person(123, "Gosho");

            //Assert
            Assert.That(() => this.extendedDatabase.Add(newPerson),
                Throws.InvalidOperationException.With.Message
                .EqualTo("There is already user with this Id!"));
        }

        //---------------------------REMOVE OPERATION TESTS--------------------------------
        [Test]
        public void RemoveOperationShouldThrowExceptionIfArrayIsEmpty()
        {
            //Arrange

            //Act

            //Assert
            Assert.That(() => this.extendedDatabase.Remove(),
                Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveOperationShouldDecreaseCount()
        {
            //Arrange
            this.people = new Person[] {
                new Person(123, "Pesho"),
                new Person(234, "Gosho"),
                new Person(345, "Tosho")
            };
            this.extendedDatabase = new ExtendedDatabase(people);

            //Act
            int expectedCount = people.Length - 1;
            this.extendedDatabase.Remove();

            //Assert
            Assert.That(this.extendedDatabase.Count, Is.EqualTo(expectedCount));
        }

        //---------------------------FIND BY USERNAME OPERATION TESTS--------------------------------
        [Test]
        public void FindByUsernameOperationShouldReturnAPerson()
        {
            //Arrange
            this.person = new Person(123, "Pesho");

            //Act
            Person expectedPerson = person;
            this.extendedDatabase.Add(person);

            //Assert
            Assert.That(this.extendedDatabase.FindByUsername("Pesho"), Is.EqualTo(expectedPerson));
        }

        [Test]
        public void FindByUsernameOperationShouldThrowExceptionIfNoSuchUsernameExists()
        {
            //Arrange

            //Act

            //Assert
            Assert.That(() => this.extendedDatabase.FindByUsername("Pesho"),
                Throws.InvalidOperationException.With.Message
                .EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FindByUsernameOperationShouldThrowExceptionIfParameterIsNull()
        {
            //Arrange

            //Act

            //Assert
            Assert.That(() => this.extendedDatabase.FindByUsername(null),
                Throws.ArgumentNullException.With.Property("ParamName")
                .EqualTo("Username parameter is null!"));
        }

        //---------------------------FIND BY ID OPERATION TESTS--------------------------------
        [Test]
        public void FindByIdOperationShouldReturnAPerson()
        {
            //Arrange
            this.person = new Person(123, "Pesho");

            //Act
            Person expectedPerson = person;
            this.extendedDatabase.Add(person);

            //Assert
            Assert.That(this.extendedDatabase.FindById(123), Is.EqualTo(expectedPerson));
        }

        [Test]
        public void FindByIdOperationShouldThrowExceptionIfNoSuchIdExists()
        {
            //Arrange

            //Act

            //Assert
            Assert.That(() => this.extendedDatabase.FindById(123),
                Throws.InvalidOperationException.With.Message
                .EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void FindByIdOperationShouldThrowExceptionIfProvidedIdIsNegative()
        {
            //Arrange

            //Act

            //Assert
            Assert.That(() => this.extendedDatabase.FindById(-123),
                Throws.TypeOf<ArgumentOutOfRangeException>().With.Property("ParamName")
                .EqualTo("Id should be a positive number!"));
        }
    }
}