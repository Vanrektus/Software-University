using System;

namespace ShoppingSpree
{
    public class Product
    {
        //---------------------------Fields---------------------------
        private string name;
        private decimal cost;

        //---------------------------Properties---------------------------

        public string Name
        {
            get => this.name;

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Cost
        {
            get => this.cost;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.cost = value;
            }
        }

        //---------------------------Constructors---------------------------
        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        //---------------------------Methods---------------------------
        public override string ToString()
        {
            return this.Name;
        }
    }
}
