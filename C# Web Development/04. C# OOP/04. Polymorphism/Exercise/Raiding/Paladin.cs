namespace Raiding
{
    public class Paladin : BaseHero
    {
        //---------------------------Constructors---------------------------
        public Paladin(string name)
            : base(name)
        {
            this.Power = 100;
        }

        //---------------------------Methods---------------------------
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
