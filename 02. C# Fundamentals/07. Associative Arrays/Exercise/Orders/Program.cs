using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> products = new Dictionary<string, List<double>>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "buy")
                {
                    break;
                }

                if (!products.ContainsKey(input[0]))
                {
                    products.Add(input[0], new List<double>() { double.Parse(input[1]), int.Parse(input[2]) });
                }
                else
                {
                    products[input[0]][0] = double.Parse(input[1]);
                    products[input[0]][1] += double.Parse(input[2]);
                }
            }

            foreach (var item in products)
            {
                Console.WriteLine($"{item.Key} -> {item.Value[0] * item.Value[1]:f2}");
            }
        }
    }
}