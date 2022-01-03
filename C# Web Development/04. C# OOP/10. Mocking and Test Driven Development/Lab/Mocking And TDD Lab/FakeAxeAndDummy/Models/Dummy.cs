using FakeAxeAndDummy.Contracts;
using System;

public class Dummy : ITarget
{
    //---------------------------Fields---------------------------
    private int health;
    private int experience;

    //---------------------------Properties---------------------------
    public int Health 
    {
        get { return this.health; }
    }

    //---------------------------Constructors---------------------------
    public Dummy(int health, int experience)
    {
        this.health = health;
        this.experience = experience;
    }

    //---------------------------Methods---------------------------
    public void TakeAttack(int attackPoints)
    {
        if (this.IsDead())
        {
            throw new InvalidOperationException("Dummy is dead.");
        }

        this.health -= attackPoints;
    }

    public int GiveExperience()
    {
        if (!this.IsDead())
        {
            throw new InvalidOperationException("Target is not dead.");
        }

        return this.experience;
    }

    public bool IsDead()
    {
        return this.health <= 0;
    }
}
