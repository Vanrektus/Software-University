using System;
using System.Collections.Generic;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> productShop = new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Revision")
                {
                    break;
                }

                string shopName = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if (!productShop.ContainsKey(shopName))
                {
                    productShop.Add(shopName, new Dictionary<string, double>());
                }

                if (!productShop[shopName].ContainsKey(product))
                {
                    productShop[shopName].Add(product, price);
                }
            }

            foreach (var currentShop in productShop)
            {
                Console.WriteLine($"{currentShop.Key}->");

                foreach (var currentProduct in currentShop.Value)
                {
                    Console.WriteLine($"Product: {currentProduct.Key}, Price: {currentProduct.Value}");
                }
            }
        }
    }
}
