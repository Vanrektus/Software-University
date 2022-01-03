using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());

            double result = Order(product, amount);

            Console.WriteLine($"{result:f2}");
        }

        static double Order(string products, int amount)
        {
            double orderPrice = 0.0;

            switch (products)
            {
                case "coffee":
                    orderPrice = 1.50 * amount;
                    break;
                case "water":
                    orderPrice = 1.00 * amount;
                    break;
                case "coke":
                    orderPrice = 1.40 * amount;
                    break;
                case "snacks":
                    orderPrice = 2.00 * amount;
                    break;
            }

            return orderPrice;
        }
    }
}
