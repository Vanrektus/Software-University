namespace Raiding
{
    public class Rogue : BaseHero
    {
        //---------------------------Constructors---------------------------
        public Rogue(string name)
            : base(name)
        {
            this.Power = 80;
        }

        //---------------------------Methods---------------------------
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
