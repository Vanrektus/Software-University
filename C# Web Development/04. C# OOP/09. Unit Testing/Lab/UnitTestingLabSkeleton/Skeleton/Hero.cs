public class Hero
{
    //---------------------------Fields---------------------------
    private string name;
    private int experience;
    private Axe weapon;

    //---------------------------Properties---------------------------
    public string Name
    {
        get { return this.name; }
    }

    public int Experience
    {
        get { return this.experience; }
    }

    public Axe Weapon
    {
        get { return this.weapon; }
    }

    //---------------------------Constructors---------------------------
    public Hero(string name)
    {
        this.name = name;
        this.experience = 0;
        this.weapon = new Axe(10, 10);
    }

    //---------------------------Methods---------------------------
    public void Attack(Dummy target)
    {
        this.weapon.Attack(target);

        if (target.IsDead())
        {
            this.experience += target.GiveExperience();
        }
    }
}
