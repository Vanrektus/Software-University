using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Person
    {
        //---------------------------Fields---------------------------
        private string name;
        private decimal money;
        private readonly List<Product> bagOfProducts;

        //---------------------------Properties---------------------------
        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public List<Product> BagOfProducts
        {
            get => this.bagOfProducts;
        }

        //---------------------------Constructors---------------------------
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        //---------------------------Methods---------------------------
        public void AddProduct(Product product)
        {
            if (product.Cost > this.Money)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
                return;
            }

            bagOfProducts.Add(product);

            this.Money -= product.Cost;
            Console.WriteLine($"{this.Name} bought {product.Name}");
        }

        public override string ToString()
        {
            if (this.bagOfProducts.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }
            else
            {
                return $"{this.Name} - {string.Join(", ", this.bagOfProducts.Select(p => p.Name))}";
            }
        }
    }
}
