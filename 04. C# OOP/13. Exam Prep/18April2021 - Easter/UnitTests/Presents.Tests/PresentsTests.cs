namespace Presents.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;

        [SetUp]
        public void ConstuctorSetup()
        {
            this.bag = new Bag();
        }

        //Create method
        [Test]
        public void CreatePresentCorrect()
        {
            Present present = new Present("Pesho", 69);

            this.bag.Create(present);

            Assert.That(this.bag.GetPresents().Count, Is.EqualTo(1));
        }

        [Test]
        public void CreatePresentNullException()
        {
            Present present = null;

            Assert.That(() => this.bag.Create(present),
                Throws.ArgumentNullException);
        }

        [Test]
        public void CreatePresentDuplicateException()
        {
            Present present = new Present("Pesho", 69);

            this.bag.Create(present);

            Assert.That(() => this.bag.Create(present),
                Throws.InvalidOperationException);
        }

        //Remove method
        [Test]
        public void RemovePresentCorrect()
        {
            Present present = new Present("Pesho", 69);

            this.bag.Create(present);

            Assert.That(() => this.bag.Remove(present),
                Is.EqualTo(true));
            Assert.That(this.bag.GetPresents().Count, Is.EqualTo(0));
        }

        //GetPresentWithLeastMagic method
        [Test]
        public void GePresentWithLeastMagicCorrect()
        {
            Present present = new Present("Pesho", 69);
            Present present2 = new Present("Pesho2", 50);

            this.bag.Create(present);
            this.bag.Create(present2);

            Assert.That(() => this.bag.GetPresentWithLeastMagic(),
                Is.EqualTo(present2));
        }

        //GetPresent method
        [Test]
        public void GetPresentCorrect()
        {
            Present present = new Present("Pesho", 69);
            Present present2 = new Present("Pesho2", 50);

            this.bag.Create(present);
            this.bag.Create(present2);

            Assert.That(() => this.bag.GetPresent("Pesho"),
                Is.EqualTo(present));
        }
    }
}
