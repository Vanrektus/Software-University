using FakeAxeAndDummy.Contracts;
using System;

// Axe durability drop with 5 
public class Axe : IWeapon
{
    //---------------------------Fields---------------------------
    private int attackPoints;
    private int durabilityPoints;

    //---------------------------Properties---------------------------
    public int AttackPoints
    {
        get { return this.attackPoints; }
    }

    public int DurabilityPoints
    {
        get { return this.durabilityPoints; }
    }

    //---------------------------Constructors---------------------------
    public Axe(int attack, int durability)
    {
        this.attackPoints = attack;
        this.durabilityPoints = durability;
    }

    //---------------------------Methods---------------------------
    public void Attack(ITarget target)
    {
        if (this.durabilityPoints <= 0)
        {
            throw new InvalidOperationException("Axe is broken.");
        }

        target.TakeAttack(this.attackPoints);
        this.durabilityPoints -= 1;
    }
}
