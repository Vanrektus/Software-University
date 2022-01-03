namespace Raiding
{
    public class Warrior : BaseHero
    {
        //---------------------------Constructors---------------------------
        public Warrior(string name)
            : base(name)
        {
            this.Power = 100;
        }

        //---------------------------Methods---------------------------
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
