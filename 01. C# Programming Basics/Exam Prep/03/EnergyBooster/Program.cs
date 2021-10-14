using System;

namespace EnergyBooster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string sizeOfSet = Console.ReadLine();
            int numOfSets = int.Parse(Console.ReadLine());

            double priceOfSets = 0;

            switch (fruit)
            {
                case "Watermelon":
                    if (sizeOfSet == "small")
                    {
                        priceOfSets = 112 * numOfSets;
                    }
                    else if (sizeOfSet == "big")
                    {
                        priceOfSets = 143.5 * numOfSets;
                    }
                        break;
                case "Mango":
                    if (sizeOfSet == "small")
                    {
                        priceOfSets = 73.32 * numOfSets;
                    }
                    else if (sizeOfSet == "big")
                    {
                        priceOfSets = 98 * numOfSets;
                    }
                    break;
                case "Pineapple":
                    if (sizeOfSet == "small")
                    {
                        priceOfSets = 84.2 * numOfSets;
                    }
                    else if (sizeOfSet == "big")
                    {
                        priceOfSets = 124 * numOfSets;
                    }
                    break;
                case "Raspberry":
                    if (sizeOfSet == "small")
                    {
                        priceOfSets = 40 * numOfSets;
                    }
                    else if (sizeOfSet == "big")
                    {
                        priceOfSets = 76 * numOfSets;
                    }
                    break;
            }

            if (priceOfSets >= 400 && priceOfSets <= 1000)
            {
                priceOfSets -= priceOfSets * 0.15;
            }
            else if (priceOfSets > 1000)
            {
                priceOfSets = priceOfSets / 2;
            }

            Console.WriteLine($"{priceOfSets:f2} lv.");
        }
    }
}
