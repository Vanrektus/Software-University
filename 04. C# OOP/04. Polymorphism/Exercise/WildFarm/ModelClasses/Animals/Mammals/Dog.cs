using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Dog : Mammal
    {
        //---------------------------Constants---------------------------
        private const double DogWeightMultiplier = 0.40;

        //---------------------------Properties---------------------------
        protected override double WeightMultiplier => DogWeightMultiplier;
        protected override ICollection<Type> AllowedFoods { get; }

        //---------------------------Constructors---------------------------
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            this.AllowedFoods = new List<Type>
            {
                typeof(Meat)
            };
        }

        //---------------------------Methods---------------------------
        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
