using FakeAxeAndDummy.Contracts;

public class Hero
{
    //---------------------------Fields---------------------------
    private string name;
    private int experience;
    private IWeapon weapon;

    //---------------------------Properties---------------------------
    public string Name
    {
        get { return this.name; }
    }

    public int Experience
    {
        get { return this.experience; }
    }

    public IWeapon Weapon
    {
        get { return this.weapon; }
    }

    //---------------------------Constructors---------------------------
    public Hero(string name, IWeapon axe)
    {
        this.name = name;
        this.experience = 0;
        this.weapon = axe;
    }

    //---------------------------Methods---------------------------
    public void Attack(ITarget target)
    {
        this.weapon.Attack(target);

        if (target.IsDead())
        {
            this.experience += target.GiveExperience();
        }
    }
}
