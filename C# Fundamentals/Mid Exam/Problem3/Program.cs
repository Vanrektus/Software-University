using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> products = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split('%', StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Shop!")
                {
                    break;
                }

                switch (input[0])
                {
                    case "Important":
                        if (products.Any(x => x == input[1]))
                        {
                            for (int i = 0; i < products.Count; i++)
                            {
                                if (products[i] == input[1])
                                {
                                    products.Insert(0, input[1]);
                                    products.RemoveAt(i + 1);
                                }
                            }
                        }
                        else
                        {
                            products.Insert(0, input[1]);
                        }
                        break;
                    case "Add":
                        if (products.Any(x => x == input[1]))
                        {
                            Console.WriteLine("The product is already in the list.");
                        }
                        else
                        {
                            products.Add(input[1]);
                        }
                        break;
                    case "Swap":
                        if (products.Any(x => x == input[1]) && products.Any(x => x == input[2]))
                        {
                            for (int i = 0; i < products.Count; i++)
                            {
                                bool isDone = false;

                                if (products[i] == input[1])
                                {

                                    for (int j = 0; j < products.Count; j++)
                                    {
                                        if (products[j] == input[2])
                                        {
                                            products.Insert(j, input[1]);
                                            products.Insert(i, input[2]);

                                            products.Remove(input[1]);
                                            products.RemoveAt(j + 1);

                                            isDone = true;
                                            break;
                                        }
                                    }
                                }

                                if (isDone == true)
                                {
                                    break;
                                }
                            }
                        }
                        else if (!products.Any(x => x == input[1]))
                        {
                            Console.WriteLine($"Product {input[1]} missing!");
                        }
                        else if (!products.Any(x => x == input[2]))
                        {
                            Console.WriteLine($"Product {input[2]} missing!");
                        }
                        break;
                    case "Remove":
                        if (products.Any(x => x == input[1]))
                        {
                            products.Remove(input[1]);
                        }
                        else
                        {
                            Console.WriteLine($"Product {input[1]} isn't in the list.");
                        }
                        break;
                }
            }

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i]}");
            }
        }
    }
}
