using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Cat : Feline
    {
        //---------------------------Constants---------------------------
        private const double CatWeightMultiplier = 0.30;

        //---------------------------Properties---------------------------
        protected override double WeightMultiplier => CatWeightMultiplier;
        protected override ICollection<Type> AllowedFoods { get; }

        //---------------------------Constructors---------------------------
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            this.AllowedFoods = new List<Type>
            {
                typeof(Vegetable),
                typeof(Meat)
            };
        }

        //---------------------------Methods---------------------------
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
