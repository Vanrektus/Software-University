using FakeAxeAndDummy.Contracts;
using NUnit.Framework;
using Moq;

[TestFixture]
public class HeroTests
{
    //---------------------------Fields---------------------------
    private string name;
    private Mock<IWeapon> fakeAxe;
    private Mock<ITarget> fakeDummy;
    private Hero hero;

    //---------------------------SET UP---------------------------
    [SetUp]
    public void Setup()
    {
        this.name = "Pesho";

        this.fakeAxe = new Mock<IWeapon>();
        fakeAxe.Setup(p => p.Attack(It.IsAny<ITarget>()))
            .Callback((ITarget target) => target.TakeAttack(10));

        this.fakeDummy = new Mock<ITarget>();
        fakeDummy.Setup(p => p.IsDead())
            .Returns(true);
        fakeDummy.Setup(p => p.GiveExperience())
            .Returns(20);

        this.hero = new Hero(this.name, this.fakeAxe.Object);
    }

    //---------------------------HERO TESTS---------------------------
    [Test]
    public void GainXPWhenTargetIsDead()
    {
        this.hero.Attack(this.fakeDummy.Object);

        Assert.That(this.hero.Experience, Is.EqualTo(20));
    }
}