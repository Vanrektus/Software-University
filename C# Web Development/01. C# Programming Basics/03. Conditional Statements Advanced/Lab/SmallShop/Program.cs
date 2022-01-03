using System;

namespace SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());

            switch (city)
            {
                case "Sofia":
                    switch (product)
                    {
                        case "coffee":
                            Console.WriteLine(amount * 0.50);
                            break;
                        case "water":
                            Console.WriteLine(amount * 0.80);
                            break;
                        case "beer":
                            Console.WriteLine(amount * 1.20);
                            break;
                        case "sweets":
                            Console.WriteLine(amount * 1.45);
                            break;
                        case "peanuts":
                            Console.WriteLine(amount * 1.60);
                            break;
                    }
                    break;
                case "Plovdiv":
                    switch (product)
                    {
                        case "coffee":
                            Console.WriteLine(amount * 0.40);
                            break;
                        case "water":
                            Console.WriteLine(amount * 0.70);
                            break;
                        case "beer":
                            Console.WriteLine(amount * 1.15);
                            break;
                        case "sweets":
                            Console.WriteLine(amount * 1.30);
                            break;
                        case "peanuts":
                            Console.WriteLine(amount * 1.50);
                            break;
                    }
                    break;
                case "Varna":
                    switch (product)
                    {
                        case "coffee":
                            Console.WriteLine(amount * 0.45);
                            break;
                        case "water":
                            Console.WriteLine(amount * 0.70);
                            break;
                        case "beer":
                            Console.WriteLine(amount * 1.10);
                            break;
                        case "sweets":
                            Console.WriteLine(amount * 1.35);
                            break;
                        case "peanuts":
                            Console.WriteLine(amount * 1.55);
                            break;
                    }
                    break;
            }
        }
    }
}
