using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private HeroRepository repository;

    [SetUp]
    public void SetUp()
    {
        this.repository = new HeroRepository();
    }

    //Constructor
    [Test]
    public void ConstructorTest()
    {
        Assert.That(this.repository.Heroes.Count, Is.EqualTo(0));
    }
    
    //Create
    [Test]
    public void CreateHeroCorrect()
    {
        Hero hero = new Hero("Pesho", 30);

        string excepctedResult = $"Successfully added hero Pesho with level 30";

        Assert.That(() => this.repository.Create(hero),
            Is.EqualTo(excepctedResult));
    }

    [Test]
    public void CreateHeroNullException()
    {
        Hero hero = null;

        Assert.That(() => this.repository.Create(hero),
            Throws.ArgumentNullException);
    }

    [Test]
    public void CreateHeroDuplicateException()
    {
        Hero hero = new Hero("Pesho", 30);

        this.repository.Create(hero);

        Hero hero2 = new Hero("Pesho", 20);

        Assert.That(() => this.repository.Create(hero2),
            Throws.InvalidOperationException);
    }

    //Remove
    [Test]
    public void RemoveHeroCorrect()
    {
        Hero hero = new Hero("Pesho", 30);

        this.repository.Create(hero);

        Assert.That(() => this.repository.Remove(hero.Name),
            Is.EqualTo(true));
    }

    [Test]
    [TestCase(null)]
    [TestCase(" ")]
    public void RemoveHeroNullOrWhitespaceNameException(string name)
    {
        Assert.That(() => this.repository.Remove(name),
            Throws.ArgumentNullException);
    }

    //GetHeroWithHighestLevel
    [Test]
    public void GetHeroWithHighestLevelCorrect()
    {
        Hero hero = new Hero("Pesho", 30);
        Hero hero2 = new Hero("Pesho2", 60);

        this.repository.Create(hero);
        this.repository.Create(hero2);

        Hero exceptedHero = hero2;
        Hero actualHero = this.repository.GetHeroWithHighestLevel();

        Assert.That(actualHero, Is.EqualTo(exceptedHero));
    }

    //GetHero
    [Test]
    public void GetHeroCorrect()
    {
        Hero hero = new Hero("Pesho", 30);

        this.repository.Create(hero);

        Hero exceptedHero = hero;
        Hero actualHero = this.repository.GetHero("Pesho");

        Assert.That(actualHero, Is.EqualTo(exceptedHero));
    }
}