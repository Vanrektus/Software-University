using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Hen : Bird
    {
        //---------------------------Constants---------------------------
        private const double HenWeightMultiplier = 0.35;

        //---------------------------Properties---------------------------
        protected override double WeightMultiplier => HenWeightMultiplier;
        protected override ICollection<Type> AllowedFoods { get; }

        //---------------------------Constructors---------------------------
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            this.AllowedFoods = new List<Type>
            {
                typeof(Vegetable),
                typeof(Fruit),
                typeof(Meat),
                typeof(Seeds),
            };
        }

        //---------------------------Methods---------------------------
        public override string ProduceSound()
        {
           return "Cluck";
        }
    }
}
