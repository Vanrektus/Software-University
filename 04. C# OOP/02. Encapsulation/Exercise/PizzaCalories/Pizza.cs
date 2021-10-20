using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        //---------------------------Fields---------------------------
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        //---------------------------Properties---------------------------
        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough
        {
            get => this.dough;

            set => this.dough = value;
        }

        public List<Topping> Toppings
        {
            get => this.toppings;
            private set => this.toppings = value;
        }

        public double Calories
        {
            get => this.CalculateTotalCalories();
        }

        //---------------------------Constructors---------------------------
        public Pizza(string name)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
        }

        //---------------------------Methods---------------------------
        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count > 9)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.Toppings.Add(topping);
        }

        private double CalculateTotalCalories()
        {
            return this.Dough.Calories + this.Toppings.Sum(t => t.Calories);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.CalculateTotalCalories():f2} Calories.";
        }
    }
}
