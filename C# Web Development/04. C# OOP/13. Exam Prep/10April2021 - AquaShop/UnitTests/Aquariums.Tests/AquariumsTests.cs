namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;

        //Constructor
        [SetUp]
        public void ConstructorSetup()
        {
            this.aquarium = new Aquarium("Pesho", 2);
        }

        //Setters
        [Test]
        public void NameSetterInvalid()
        {
            Assert.That(() => this.aquarium = new Aquarium(null, 2),
                Throws.ArgumentNullException);
            Assert.That(() => this.aquarium = new Aquarium("", 2),
                Throws.ArgumentNullException);
        }

        [Test]
        public void CapacitySetterInvalid()
        {
            Assert.That(() => this.aquarium = new Aquarium("Riba", -2),
                Throws.ArgumentException);
        }

        //Add method
        [Test]
        public void AddFishCorrectly()
        {
            Fish fish = new Fish("Riba");

            this.aquarium.Add(fish);

            Assert.That(this.aquarium.Count == 1);
        }

        [Test]
        public void AddFishException()
        {
            Fish fish = new Fish("Riba");
            Fish fish2 = new Fish("Riba2");

            this.aquarium.Add(fish);
            this.aquarium.Add(fish2);

            Assert.That(() => this.aquarium.Add(new Fish("Test")),
                Throws.InvalidOperationException);
        }

        //Remove method
        [Test]
        public void RemoveFishCorrect()
        {
            Fish fish = new Fish("Riba");

            this.aquarium.Add(fish);
            this.aquarium.RemoveFish("Riba");

            Assert.That(this.aquarium.Count == 0);
        }

        [Test]
        public void RemoveFishException()
        {
            Assert.That(() => this.aquarium.RemoveFish("Riba"),
                Throws.InvalidOperationException);
        }

        //Sell method
        [Test]
        public void SellFishCorrect()
        {
            Fish fish = new Fish("Riba");

            this.aquarium.Add(fish);

            Assert.That(() => this.aquarium.SellFish("Riba")
            , Is.EqualTo(fish));
        }

        [Test]
        public void SellFishException()
        {
            Assert.That(() => this.aquarium.SellFish("Riba"),
                Throws.InvalidOperationException);
        }

        //Report method
        [Test]
        public void ReportCorrect()
        {
            Fish fish = new Fish("Riba");

            this.aquarium.Add(fish);

            string actualResult = this.aquarium.Report();

            Assert.That(actualResult, Is.EqualTo($"Fish available at Pesho: Riba"));
        }
    }
}
