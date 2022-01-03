using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Tiger : Feline
    {
        //---------------------------Constants---------------------------
        private const double TigerWeightMultiplier = 1.00;

        //---------------------------Properties---------------------------
        protected override double WeightMultiplier => TigerWeightMultiplier;
        protected override ICollection<Type> AllowedFoods { get; }

        //---------------------------Constructors---------------------------
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            this.AllowedFoods = new List<Type>
            {
                typeof(Meat)
            };
        }

        //---------------------------Methods---------------------------
        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
