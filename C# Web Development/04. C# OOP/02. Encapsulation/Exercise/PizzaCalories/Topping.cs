using System;

namespace PizzaCalories
{
    public class Topping
    {
        //---------------------------Fields---------------------------
        private string toppingType;
        private double weight;

        //---------------------------Properties---------------------------
        public string ToppingType
        {
            get => this.toppingType;

            private set
            {
                string topping = value.ToLower();

                if (topping != "meat" && topping != "veggies" && topping != "cheese" && topping != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value.ToLower();
            }
        }

        public double Weight
        {
            get => this.weight;

            private set
            {
                if (value <= 0 || value > 50)
                {
                    string topping = char.ToUpper(this.ToppingType[0]) + this.ToppingType.Substring(1);

                    throw new ArgumentException($"{topping} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public double Calories
        {
            get => this.CalculateCalories();
        }

        //---------------------------Constructors---------------------------
        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        //---------------------------Methods---------------------------
        private double CalculateCalories()
        {
            double toppingTypeModifier = 0;

            switch (this.toppingType)
            {
                case "meat":
                    toppingTypeModifier = 1.2;
                    break;
                case "veggies":
                    toppingTypeModifier = 0.8;
                    break;
                case "cheese":
                    toppingTypeModifier = 1.1;
                    break;
                case "sauce":
                    toppingTypeModifier = 0.9;
                    break;
            }

            return (2 * this.Weight) * toppingTypeModifier;
        }
    }
}
