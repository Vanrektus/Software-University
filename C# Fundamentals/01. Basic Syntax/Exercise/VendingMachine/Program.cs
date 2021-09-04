using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = (Console.ReadLine());

            double totalCoins = 0.0;

            while (input != "Start")
            {
                double coins = double.Parse(input);

                if (coins == 0.10 || coins == 0.20 || coins == 0.50 || coins == 1.00 || coins == 2.00)
                {
                    totalCoins += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }

                input = (Console.ReadLine());
            }

            input = (Console.ReadLine());

            while (input != "End")
            {
                double currentProductPrice = 0.0;

                switch (input)
                {
                    case "Nuts":
                        currentProductPrice = 2.0;
                        break;
                    case "Water":
                        currentProductPrice = 0.7;
                        break;
                    case "Crisps":
                        currentProductPrice = 1.5;
                        break;
                    case "Soda":
                        currentProductPrice = 0.8;
                        break;
                    case "Coke":
                        currentProductPrice = 1.0;
                        break;
                }

                if (currentProductPrice != 0.0)
                {
                    if (totalCoins >= currentProductPrice)
                    {
                        Console.WriteLine($"Purchased {input.ToLower()}");
                        totalCoins -= currentProductPrice;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }

                input = (Console.ReadLine());
            }

            Console.WriteLine($"Change: {totalCoins:f2}");
        }
    }
}
