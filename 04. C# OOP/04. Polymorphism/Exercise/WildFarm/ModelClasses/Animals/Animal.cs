using System;
using System.Collections.Generic;

namespace WildFarm
{
    public abstract class Animal : IEatable, ISoundProducible
    {
        //---------------------------Properties---------------------------
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        protected abstract double WeightMultiplier { get; }
        protected abstract ICollection<Type> AllowedFoods { get; }

        //---------------------------Constructors---------------------------
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        //---------------------------Methods---------------------------
        public abstract void ProduceSound();

        public void Eat(Food food)
        {
            if (!this.AllowedFoods.Contains(food.GetType()))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += this.WeightMultiplier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }
    }
}
