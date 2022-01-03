using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    //---------------------------Fields---------------------------
    private Axe axe;
    private Dummy dummy;

    //---------------------------SET UP---------------------------
    [SetUp]
    public void Initialize()
    {
        axe = new Axe(10, 3);
        dummy = new Dummy(20, 5);
    }

    //---------------------------DUMMY TESTS---------------------------
    [Test]
    public void DummyLosesHealthWhenAttacked()
    {
        axe.Attack(dummy);

        Assert.That(dummy.Health, Is.EqualTo(10));
        Assert.AreEqual(10, dummy.Health);
    }

    [Test]
    public void DeadDummyThrowsExceptionWhenAttacked()
    {
        axe.Attack(dummy);
        axe.Attack(dummy);

        Assert.That(() => axe.Attack(dummy),
            Throws.InvalidOperationException.With.Message
            .EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyCanGiveExperience()
    {
        axe.Attack(dummy);
        axe.Attack(dummy);

        Assert.That(dummy.GiveExperience(), Is.EqualTo(5));
    }

    [Test]
    public void AliveDummyCannotGiveExperience()
    {
        Assert.That(() => dummy.GiveExperience(),
            Throws.InvalidOperationException.With.Message
            .EqualTo("Target is not dead."));
    }
}
