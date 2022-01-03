namespace Raiding
{
    public abstract class BaseHero
    {
        //---------------------------Properties---------------------------
        public string Name { get; private set; }
        public int Power { get; set; }

        //---------------------------Constructors---------------------------
        public BaseHero(string name)
        {
            this.Name = name;
        }

        //---------------------------Methods---------------------------
        public abstract string CastAbility();
    }
}
