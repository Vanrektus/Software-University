using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Owl : Bird
    {
        //---------------------------Constants---------------------------
        private const double OwlWeightMultiplier = 0.25;

        //---------------------------Properties---------------------------
        protected override double WeightMultiplier => OwlWeightMultiplier;
        protected override ICollection<Type> AllowedFoods { get; }

        //---------------------------Constructors---------------------------
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            this.AllowedFoods = new List<Type>
            {
                typeof(Meat)
            };
        }

        //---------------------------Methods---------------------------
        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
