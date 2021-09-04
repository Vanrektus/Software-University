using System;

namespace FoodForPets
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfDays = int.Parse(Console.ReadLine());
            double amountOfFood = double.Parse(Console.ReadLine());

            double totalFoodEatenFromDog = 0;
            double totalFoodEatenFromCat = 0;
            double totalEatenBiscuits = 0;

            for (int currentDay = 1; currentDay <= numOfDays; currentDay++)
            {
                double eatenFoodFromDog = double.Parse(Console.ReadLine());
                double eatenFoodFromCat = double.Parse(Console.ReadLine());

                totalFoodEatenFromDog += eatenFoodFromDog;
                totalFoodEatenFromCat += eatenFoodFromCat;

                if (currentDay % 3 == 0)
                {
                    totalEatenBiscuits += (eatenFoodFromDog + eatenFoodFromCat) * 0.1;
                }
            }

            Console.WriteLine($"Total eaten biscuits: {Math.Round(totalEatenBiscuits)}gr.");
            Console.WriteLine($"{(totalFoodEatenFromDog + totalFoodEatenFromCat) / amountOfFood * 100:f2}% of the food has been eaten.");
            Console.WriteLine($"{totalFoodEatenFromDog / (totalFoodEatenFromDog + totalFoodEatenFromCat) * 100:f2}% eaten from the dog.");
            Console.WriteLine($"{totalFoodEatenFromCat / (totalFoodEatenFromDog + totalFoodEatenFromCat) * 100:f2}% eaten from the cat.");
        }
    }
}
