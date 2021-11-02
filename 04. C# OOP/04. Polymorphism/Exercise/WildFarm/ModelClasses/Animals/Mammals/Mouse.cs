using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        //---------------------------Constructors---------------------------
        private const double MouseWeightMultiplier = 0.10;

        //---------------------------Properties---------------------------
        protected override double WeightMultiplier => MouseWeightMultiplier;
        protected override ICollection<Type> AllowedFoods { get; }

        //---------------------------Constructors---------------------------
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            this.AllowedFoods = new List<Type>
            {
                typeof(Vegetable),
                typeof(Fruit)
            };
        }

        //---------------------------Methods---------------------------
        public override void ProduceSound()
        {
            Console.WriteLine("Squeak");
        }
    }
}
