using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    //---------------------------Fields---------------------------
    private Axe axe;
    private Dummy dummy;

    //---------------------------SET UP---------------------------
    [SetUp]
    public void Initialize()
    {
        axe = new Axe(10, 2);
        dummy = new Dummy(20, 5);
    }

    //---------------------------WEAPON TESTS---------------------------
    [Test]
    public void WeaponLosesDurabilityAfterAttack()
    {
        axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(1));
        Assert.AreEqual(1, axe.DurabilityPoints);
    }

    [Test]
    public void AttackWithABrokenWeapon()
    {
        axe.Attack(dummy);
        axe.Attack(dummy);

        Assert.That(() => axe.Attack(dummy),
            Throws.InvalidOperationException.With.Message
            .EqualTo("Axe is broken."));
    }
}