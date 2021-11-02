using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Owl : Bird
    {
        //---------------------------Constructors---------------------------
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
        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
