using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        //---------------------------Constants---------------------------
        private const int databaseCapacity = 16;

        //---------------------------Fields---------------------------
        private Database.Database database;

        //---------------------------SET UP---------------------------
        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database();
        }

        //---------------------------CONSTRUCTOR TESTS---------------------------
        [Test]
        public void ConstructorShouldInitialiiiDatabaseWith16Elements()
        {
            //Arrange
            int[] array = new int[16];
            this.database = new Database.Database(array);

            //Act Assert
            Assert.That(this.database.Count, Is.EqualTo(databaseCapacity), "Array's capacity must be exactly 16 integers!");
        }

        //---------------------------ADD OPERATION TESTS---------------------------
        [Test]
        public void AddOperationShouldAddElementAtNextFreeCell()
        {
            //Arrange

            //Act
            this.database.Add(10);

            //Assert
            Assert.That(this.database.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddOperationExceeding16ElementsShouldThrowException()
        {
            //Arrange
            int[] array = new int[16];
            this.database = new Database.Database(array);

            //Act Assert
            Assert.That(() => this.database.Add(10),
                Throws.InvalidOperationException.With.Message
                .EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        //---------------------------REMOVE OPERATION TESTS---------------------------
        [Test]
        public void RemoveOperationShouldRemoveLastElement()
        {
            //Arrange
            int[] array = new int[10];
            this.database = new Database.Database(array);

            //Act
            this.database.Remove();

            //Assert
            Assert.That(this.database.Count, Is.EqualTo(9));
        }

        [Test]
        public void RemoveOperationShouldThrowExceptionIfEmpty()
        {
            //Arrange

            //Act

            //Assert
            Assert.That(() => this.database.Remove(),
                Throws.InvalidOperationException.With.Message
                .EqualTo("The collection is empty!"));
        }

        //---------------------------FETCH OPERATION TESTS---------------------------
        [Test]
        public void FetchShouldReturnElementsAsArray()
        {
            //Assert
            int[] array = new int[3] { 5, 7, 9 } ;
            this.database = new Database.Database(array);

            //Act
            int[] expectedResult = this.database.Fetch();

            //Assert
            CollectionAssert.AreEqual(expectedResult, array);
        }
    }
}