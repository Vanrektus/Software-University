// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    //using FestivalManager.Entities;
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
    public class StageTests
    {
        private Stage stage;

        [SetUp]
        public void Setup()
        {
            stage = new Stage();
        }

        //AddPerformer
        [Test]
        public void AddPerformerShouldAddCorrectly()
        {
            Performer performer = new Performer("Pesho", "Peshov", 25);
            this.stage.AddPerformer(performer);

            Assert.That(this.stage.Performers.Count == 1);
            Assert.That(this.stage.Performers.FirstOrDefault(p => p.FullName == performer.FullName), Is.EqualTo(performer));
        }

        [Test]
        public void AddPerformerCannotBeNull()
        {
            Assert.That(() => this.stage.AddPerformer(null),
                Throws.ArgumentNullException);
        }

        [Test]
        public void AddPerformerCannotBeBelow18()
        {
            Performer performer = new Performer("Pesho", "Peshov", 15);

            Assert.That(() => this.stage.AddPerformer(performer),
                Throws.ArgumentException);
        }

        //AddSong
        [Test]
        public void AddSongShouldAddCorrectly()
        {
            Performer performer = new Performer("Pesho", "Peshov", 25);
            Song song = new Song("Vetrove", new System.TimeSpan(0, 3, 30));

            this.stage.AddPerformer(performer);
            this.stage.AddSong(song);
            this.stage.AddSongToPerformer(song.Name, performer.FullName);

            Assert.That(this.stage.Play(), Is.EqualTo("1 performers played 1 songs"));
        }

        [Test]
        public void AddSongSongCannotBeNull()
        {
            Assert.That(() => this.stage.AddSong(null),
                Throws.ArgumentNullException);
        }

        [Test]
        public void AddSongCannotBeLessThat1Minute()
        {
            Song song = new Song("Vetrove", new System.TimeSpan(0, 0, 30));

            Assert.That(() => this.stage.AddSong(song),
                Throws.ArgumentException.With.Message.EqualTo("You can only add songs that are longer than 1 minute."));
        }

        //AddSongToPerformer
        [Test]
        public void AddSongToPerformerShouldAddCorrectly()
        {
            Performer performer = new Performer("Pesho", "Peshov", 25);
            Song song = new Song("Vetrove", new System.TimeSpan(0, 3, 30));

            this.stage.AddPerformer(performer);
            this.stage.AddSong(song);

            stage.AddSongToPerformer("Vetrove", "Pesho Peshov");

            Assert.That(performer.SongList.Count == 1);
            Assert.That(performer.SongList.FirstOrDefault().Equals(song));
            Assert.That(this.stage.AddSongToPerformer(song.Name, performer.FullName), Is.EqualTo($"{song} will be performed by {performer}"));
        }

        [Test]
        public void AddSongToPerformerPerformerCannotBeNull()
        {
            Assert.That(() => this.stage.AddSongToPerformer("Vetrove", null),
                Throws.ArgumentNullException);
        }

        [Test]
        public void AddSongToPerformerSongCannotBeNull()
        {
            Assert.That(() => this.stage.AddSongToPerformer(null, "Pesho Peshov"),
                Throws.ArgumentNullException);
        }

        [Test]
        public void AddSongToPerformerPerformerDoesNotExist()
        {
            Song song = new Song("Vetrove", new System.TimeSpan(0, 3, 30));

            Assert.That(() => this.stage.AddSongToPerformer("Vetrove", "Test"),
                Throws.ArgumentException.With.Message.EqualTo("There is no performer with this name."));
        }

        [Test]
        public void AddSongToPerformerSongDoesNotExist()
        {
            Performer performer = new Performer("Pesho", "Peshov", 25);

            this.stage.AddPerformer(performer);

            Assert.That(() => this.stage.AddSongToPerformer("Test", performer.FullName),
                Throws.ArgumentException.With.Message.EqualTo("There is no song with this name."));
        }

        //Play
        [Test]
        public void PlayShouldWorkCorrectly()
        {
            //Arrange
            Performer performer = new Performer("Pesho", "Peshov", 25);
            Performer performer2 = new Performer("Gosho", "Goshov", 30);
            Song song = new Song("Vetrove", new System.TimeSpan(0, 3, 30));
            Song song2 = new Song("Vetrove2", new System.TimeSpan(0, 5, 41));
            Song song3 = new Song("Vetrove3", new System.TimeSpan(0, 6, 12));

            //Act
            this.stage.AddPerformer(performer);
            this.stage.AddPerformer(performer2);

            this.stage.AddSong(song);
            this.stage.AddSong(song2);
            this.stage.AddSong(song3);

            this.stage.AddSongToPerformer("Vetrove", "Pesho Peshov");
            this.stage.AddSongToPerformer("Vetrove2", "Gosho Goshov");
            this.stage.AddSongToPerformer("Vetrove3", "Gosho Goshov");

            //Assert
            Assert.That(this.stage.Play(), Is.EqualTo($"2 performers played 3 songs"));
        }
    }
}