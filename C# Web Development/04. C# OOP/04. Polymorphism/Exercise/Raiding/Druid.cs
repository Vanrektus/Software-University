namespace Raiding
{
    public class Druid : BaseHero
    {
        //---------------------------Constructors---------------------------
        public Druid(string name)
            : base(name)
        {
            this.Power = 80;
        }

        //---------------------------Methods---------------------------
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
