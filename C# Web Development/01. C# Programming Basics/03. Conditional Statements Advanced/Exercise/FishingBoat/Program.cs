using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numberOfFishers = int.Parse(Console.ReadLine());

            double price = 0.0;

            switch (season)
            {
                case "Spring":
                    price = 3000;
                    if (numberOfFishers <= 6)
                    {
                        price = price * 0.9;
                    }
                    else if (numberOfFishers >= 7 && numberOfFishers <= 11)
                    {
                        price = price * 0.85;
                    }
                    else if (numberOfFishers >= 12)
                    {
                        price = price * 0.75;
                    }
                    break;
                case "Summer":
                case "Autumn":
                    price = 4200;
                    if (numberOfFishers <= 6)
                    {
                        price = price * 0.9;
                    }
                    else if (numberOfFishers >= 7 && numberOfFishers <= 11)
                    {
                        price = price * 0.85;
                    }
                    else if (numberOfFishers >= 12)
                    {
                        price = price * 0.75;
                    }
                    break;
                case "Winter":
                    price = 2600;
                    if (numberOfFishers <= 6)
                    {
                        price = price * 0.9;
                    }
                    else if (numberOfFishers >= 7 && numberOfFishers <= 11)
                    {
                        price = price * 0.85;
                    }
                    else if (numberOfFishers >= 12)
                    {
                        price = price * 0.75;
                    }
                    break;
            }
            if (numberOfFishers % 2 == 0 && season != "Autumn")
            {
                price = price * 0.95;
            }
            if (budget >= price)
            {
                Console.WriteLine($"Yes! You have {budget - price:f2} leva left.");
            }
            else if (budget < price)
            {
                Console.WriteLine($"Not enough money! You need {price - budget:f2} leva.");
            }
        }
    }
}
