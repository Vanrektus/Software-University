using NUnit.Framework;
using System.Collections.Generic;
using FightingArena;

namespace Tests
{
    public class ArenaTests
    {
        //---------------------------Fields-------------------------
        private Arena arena;
        private List<Warrior> warriors;

        //---------------------------SET UP-------------------------
        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        //---------------------------CONSTRUCTOR TESTS-------------------------
        [Test]
        public void ConstructorShouldInitializeCollection()
        {
            //Arrange
            this.warriors = new List<Warrior>();

            //Act

            //Assert
            Assert.That(this.arena.Warriors, Is.EqualTo(warriors));
        }

        //---------------------------ENROLL OPERATION TESTS-------------------------
        [Test]
        public void EnrollOperationShouldEnrollWarriorsCorrectly()
        {
            //Arrange
            Warrior warriorOne = new Warrior("Pesho", 20, 100);
            Warrior warriorTwo = new Warrior("Gosho", 25, 120);

            //Act
            this.arena.Enroll(warriorOne);
            this.arena.Enroll(warriorTwo);

            List<Warrior> expectedResult = new List<Warrior> { warriorOne, warriorTwo };

            //Assert
            Assert.That(this.arena.Warriors, Is.EqualTo(expectedResult));
        }

        [Test]
        public void EnrollOperationShouldEnrollWarriorToCollection()
        {
            //Arrange
            Warrior warrior = new Warrior("Pesho", 20, 100);

            //Act
            this.arena.Enroll(warrior);

            //Assert
            Assert.That(this.arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void EnrollOperationShouldThrowExceptionIfTriedToEnrollSameWarrior()
        {
            //Arrange
            Warrior warrior = new Warrior("Pesho", 20, 100);

            //Act
            this.arena.Enroll(warrior);

            //Assert
            Assert.That(() => this.arena.Enroll(warrior),
                Throws.InvalidOperationException.With.Message
                .EqualTo("Warrior is already enrolled for the fights!"));
        }

        //---------------------------FIGHT OPERATION TESTS-------------------------
        [Test]
        public void FightOperationShouldExecuteSuccessfully()
        {
            //Arrange
            Warrior attacker = new Warrior("Pesho", 20, 100);
            Warrior defender = new Warrior("Gosho", 25, 120);

            //Act
            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);
            this.arena.Fight("Pesho", "Gosho");

            int expectedDefenderHp = 100;
            int actualDefenderHp = defender.HP;

            //Assert
            Assert.That(actualDefenderHp, Is.EqualTo(expectedDefenderHp));
        }

        [Test]
        public void FightOperationShouldThrowExceptionWithNoAttackerName()
        {
            //Arrange
            Warrior warrior = new Warrior("Pesho", 20, 100);
            string attacker = "Gosho";

            //Act
            this.arena.Enroll(warrior);

            //Assert
            Assert.That(() => this.arena.Fight(attacker, "Pesho"),
                Throws.InvalidOperationException.With.Message
                .EqualTo($"There is no fighter with name {attacker} enrolled for the fights!"));
        }

        [Test]
        public void FightOperationShouldThrowExceptionWithNoDefenderName()
        {
            //Arrange
            Warrior warrior = new Warrior("Pesho", 20, 100);
            string defender = "Gosho";

            //Act
            this.arena.Enroll(warrior);

            //Assert
            Assert.That(() => this.arena.Fight("Pesho", defender),
                Throws.InvalidOperationException.With.Message
                .EqualTo($"There is no fighter with name {defender} enrolled for the fights!"));
        }
    }
}
