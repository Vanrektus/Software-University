using System;
using System.Collections.Generic;
using WildFarm.Exceptions;
using WildFarm.Interfaces;

namespace WildFarm
{
    public abstract class Animal : IAnimal
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
        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            if (!this.AllowedFoods.Contains(food.GetType()))
            {
                string exceptionMessage = string.Format(ExceptionMessage.InvalidFoodException, this.GetType().Name, food.GetType().Name);
                throw new ArgumentException(exceptionMessage);
            }

            this.Weight += this.WeightMultiplier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }
    }
}
