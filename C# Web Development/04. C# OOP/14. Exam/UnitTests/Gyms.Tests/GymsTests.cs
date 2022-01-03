namespace Gyms.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class GymsTests
    {
        private Gym gym;

        [SetUp]
        public void ConstructorSetup()
        {
            this.gym = new Gym("PeshoGym", 2);
        }

        //Constructor
        [Test]
        public void ConstructorInitializeNameCorrect()
        {
            Assert.That(this.gym.Name, Is.EqualTo("PeshoGym"));
        }

        [Test]
        public void ConstructorInitializeCapacityCorrect()
        {
            Assert.That(this.gym.Capacity, Is.EqualTo(2));
        }

        [Test]
        public void ConstructorInitializeCountCorrect()
        {
            Assert.That(this.gym.Count, Is.EqualTo(0));
        }

        //Setters
        [Test]
        public void NameSetterNullException()
        {
            Assert.That(() => this.gym = new Gym(null, 2),
                Throws.ArgumentNullException);
        }

        [Test]
        public void NameSetterEmptyException()
        {
            Assert.That(() => this.gym = new Gym("", 2),
                Throws.ArgumentNullException);
        }

        [Test]
        public void CapacitySetterException()
        {
            Assert.That(() => this.gym = new Gym("PeshoGym", -2),
                Throws.ArgumentException);
        }

        //Add method
        [Test]
        public void AddAthleteCountCorrect()
        {
            Athlete athlete = new Athlete("Pesho");

            this.gym.AddAthlete(athlete);

            Assert.That(this.gym.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddAthleteFullNameCorrect()
        {
            Athlete athlete = new Athlete("Pesho");

            this.gym.AddAthlete(athlete);

            Assert.That(athlete.FullName, Is.EqualTo("Pesho"));
        }

        [Test]
        public void AddAthleteIsInjuredCorrect()
        {
            Athlete athlete = new Athlete("Pesho");

            this.gym.AddAthlete(athlete);
            
            Assert.That(athlete.IsInjured, Is.EqualTo(false));
        }

        [Test]
        public void AddAthleteNotEnoughCapacityException()
        {
            Athlete athlete = new Athlete("Pesho");
            Athlete athlete2 = new Athlete("Gosho");

            this.gym.AddAthlete(athlete);
            this.gym.AddAthlete(athlete2);

            Assert.That(athlete.IsInjured, Is.EqualTo(false));
            Assert.That(athlete2.IsInjured, Is.EqualTo(false));

            Assert.That(() => this.gym.AddAthlete(new Athlete("Tosho")),
                Throws.InvalidOperationException.With.Message.
                EqualTo("The gym is full."));
        }

        //Remove method
        [Test]
        public void RemoveAthleteCorrect()
        {
            Athlete athlete = new Athlete("Pesho");

            this.gym.AddAthlete(athlete);

            Assert.That(this.gym.Count, Is.EqualTo(1));

            this.gym.RemoveAthlete("Pesho");

            Assert.That(this.gym.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveAthleteException()
        {
            Assert.That(() => this.gym.RemoveAthlete("Pesho"),
                Throws.InvalidOperationException.With.Message
                .EqualTo($"The athlete Pesho doesn't exist."));
        }

        [Test]
        public void RemoveAthleteNullException()
        {
            Athlete athlete = new Athlete("Gosho");

            this.gym.AddAthlete(athlete);

            Assert.That(() => this.gym.RemoveAthlete("Pesho"),
                Throws.InvalidOperationException.With.Message
                .EqualTo($"The athlete Pesho doesn't exist."));
        }

        //Injure method
        [Test]
        public void InjureAthleteCorrect()
        {
            Athlete athlete = new Athlete("Pesho");

            this.gym.AddAthlete(athlete);

            Assert.That(athlete.IsInjured, Is.EqualTo(false));

            this.gym.InjureAthlete("Pesho");

            Assert.That(athlete.IsInjured, Is.EqualTo(true));
        }

        [Test]
        public void InjureAthleteCorrectSecondTest()
        {
            Athlete athlete = new Athlete("Pesho");

            this.gym.AddAthlete(athlete);

            Assert.That(athlete.IsInjured, Is.EqualTo(false));

            Assert.That(() => this.gym.InjureAthlete("Pesho"),
                Is.EqualTo(athlete));
        }

        [Test]
        public void InjureAthleteNullException()
        {
            Athlete athlete = new Athlete("Gosho");

            this.gym.AddAthlete(athlete);

            Assert.That(() => this.gym.InjureAthlete("Pesho"),
                Throws.InvalidOperationException.With.Message
                .EqualTo($"The athlete Pesho doesn't exist."));
        }

        //Report method
        [Test]
        public void ReportAthletesCorrect()
        {
            Assert.That(() => this.gym.Report(),
                Is.EqualTo($"Active athletes at PeshoGym: "));

            Athlete athlete = new Athlete("Pesho");
            Athlete athlete2 = new Athlete("Gosho");

            this.gym.AddAthlete(athlete);
            this.gym.AddAthlete(athlete2);

            Assert.That(() => this.gym.Report(),
                Is.EqualTo($"Active athletes at PeshoGym: Pesho, Gosho"));
        }
    }
}
