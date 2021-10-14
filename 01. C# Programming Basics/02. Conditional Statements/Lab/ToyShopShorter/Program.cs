using System;

namespace ToyShopShorter
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Read input.
            double priceOfExcursion = double.Parse(Console.ReadLine());
            double numberOfPuzzles = double.Parse(Console.ReadLine());
            double numberOfDolls = double.Parse(Console.ReadLine());
            double numberOfBears = double.Parse(Console.ReadLine());
            double numberOfMinions = double.Parse(Console.ReadLine());
            double numberOfTrucks = double.Parse(Console.ReadLine());

            //2. Total income from the toys.
            double totalPriceOfToys = (numberOfPuzzles * 2.60) + (numberOfDolls * 3) + (numberOfBears * 4.10) + (numberOfMinions * 8.20) + 
                (numberOfTrucks * 2);

            //3. If numberOfToys >= 50 then make a discount: 25%.
            double numberOfToys = numberOfPuzzles + numberOfDolls + numberOfBears + numberOfMinions + numberOfTrucks;

            if (numberOfToys >= 50)
            {
                totalPriceOfToys = totalPriceOfToys - totalPriceOfToys * 0.25;
              //totalPriceOfToys = totalPriceOfToys * 0.75;
              //totalPriceOfToys -= totalPriceOfToys * 0.25;
            }

            //4. Pay the rent: 10%.
            totalPriceOfToys = totalPriceOfToys - totalPriceOfToys * 0.10;
            //totalPriceOfToys = totalPriceOfToys * 0.90;
            //totalPriceOfToys -= totalPriceOfToys * 0.10;

            //5. Check if she has enough money for the excursion.
            if (totalPriceOfToys >= priceOfExcursion)
            {
                Console.WriteLine($"Yes! {(totalPriceOfToys - priceOfExcursion):f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {(priceOfExcursion - totalPriceOfToys):f2} lv needed.");
            }
        }
    }
}
