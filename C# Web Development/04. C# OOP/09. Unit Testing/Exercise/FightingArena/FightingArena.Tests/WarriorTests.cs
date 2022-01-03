using NUnit.Framework;
using FightingArena;

namespace Tests
{
    public class WarriorTests
    {
        //---------------------------Constants---------------------------
        private const int MIN_ATTACK_HP = 30;

        //---------------------------Fields---------------------------
        private Warrior warrior;

        //---------------------------SET UP---------------------------
        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("Pesho", 20, 100);
        }

        //---------------------------CONSTRUCTOR TESTS---------------------------
        [Test]
        [TestCase("Pesho", 20, 100)]
        public void ConstructorShouldInitializeWarriorNameCorrectly(string name, int damage, int hp)
        {
            //Arrange
            warrior = new Warrior(name, damage, hp);

            //Act
            Warrior expectedWarrior = new Warrior("Pesho", 20, 100);

            //Assert
            Assert.That(warrior.Name, Is.EqualTo(expectedWarrior.Name));
        }

        [Test]
        [TestCase("Pesho", 20, 100)]
        public void ConstructorShouldInitializeWarriorDamageCorrectly(string name, int damage, int hp)
        {
            //Arrange
            warrior = new Warrior(name, damage, hp);

            //Act
            Warrior expectedWarrior = new Warrior("Pesho", 20, 100);

            //Assert
            Assert.That(warrior.Damage, Is.EqualTo(expectedWarrior.Damage));
        }

        [Test]
        [TestCase("Pesho", 20, 100)]
        public void ConstructorShouldInitializeWarriorHpCorrectly(string name, int damage, int hp)
        {
            //Arrange
            warrior = new Warrior(name, damage, hp);

            //Act
            Warrior expectedWarrior = new Warrior("Pesho", 20, 100);

            //Assert
            Assert.That(warrior.HP, Is.EqualTo(expectedWarrior.HP));
        }

        //---------------------------SETTERS TESTS---------------------------
        [Test]
        [TestCase(null, 20, 100)]
        [TestCase("", 20, 100)]
        [TestCase(" ", 20, 100)]
        public void NameSetterShouldThrowExceptionIfValueIsNullOrWhiteSpace(string name, int damage, int hp)
        {
            //Arrange

            //Act

            //Assert
            Assert.That(() => this.warrior = new Warrior(name, damage, hp),
                Throws.ArgumentException.With.Message
                .EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        [TestCase("Pesho", 0, 100)]
        [TestCase("Pesho", -5, 100)]
        public void DamageSetterShouldThrowExceptionIfValueIsZeroOrNegative(string name, int damage, int hp)
        {
            //Arrange

            //Act

            //Assert
            Assert.That(() => this.warrior = new Warrior(name, damage, hp),
                Throws.ArgumentException.With.Message
                .EqualTo("Damage value should be positive!"));
        }

        [Test]
        [TestCase("Pesho", 20, -5)]
        public void HpSetterShouldThrowExceptionIfValueIsNegative(string name, int damage, int hp)
        {
            //Arrange

            //Act

            //Assert
            Assert.That(() => this.warrior = new Warrior(name, damage, hp),
                Throws.ArgumentException.With.Message
                .EqualTo("HP should not be negative!"));
        }

        //---------------------------ATTACK OPERATION TESTS---------------------------
        [Test]
        public void AttackOperationShouldAttackEnemyCorrectly()
        {
            //Arrange
            this.warrior = new Warrior("Pesho", 35, 100);
            Warrior enemyWarrior = new Warrior("Gosho", 20, 70);

            //Act
            int expectedEnemyHp = enemyWarrior.HP - this.warrior.Damage;
            this.warrior.Attack(enemyWarrior);

            //Assert
            Assert.That(enemyWarrior.HP, Is.EqualTo(expectedEnemyHp));
        }

        [Test]
        public void AttackOperationShouldAttackAndKillEnemyCorrectly()
        {
            //Arrange
            this.warrior = new Warrior("Pesho", 70, 100);
            Warrior enemyWarrior = new Warrior("Gosho", 15, 50);

            //Act
            this.warrior.Attack(enemyWarrior);

            //Assert
            Assert.That(enemyWarrior.HP, Is.EqualTo(0));
        }

        [Test]
        public void AttackOperationShouldThrowExceptionIfThisHpIsTooLow()
        {
            //Arrange
            this.warrior = new Warrior("Pesho", 20, 25);
            Warrior enemyWarrior = new Warrior("Gosho", 20, 50);

            //Act

            //Assert
            Assert.That(() => this.warrior.Attack(enemyWarrior),
                Throws.InvalidOperationException.With.Message
                .EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void AttackOperationShouldThrowExceptionIfEnemyHpIsTooLow()
        {
            //Arrange
            this.warrior = new Warrior("Pesho", 20, 100);
            Warrior enemyWarrior = new Warrior("Gosho", 20, 25);

            //Act

            //Assert
            Assert.That(() => this.warrior.Attack(enemyWarrior),
                Throws.InvalidOperationException.With.Message
                .EqualTo($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!"));
        }

        [Test]
        public void AttackOperationShouldThrowExceptionIfEnemyIsTooStrong()
        {
            //Arrange
            this.warrior = new Warrior("Pesho", 20, 50);
            Warrior enemyWarrior = new Warrior("Gosho", 60, 100);

            //Act

            //Assert
            Assert.That(() => this.warrior.Attack(enemyWarrior),
                Throws.InvalidOperationException.With.Message
                .EqualTo("You are trying to attack too strong enemy"));
        }
    }
}