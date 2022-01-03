using System;

namespace CareOfPuppy
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountOfFoodBought = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int amountOfFoodBoughtInGrams = amountOfFoodBought * 1000;
            int totalFoodEaten = 0;

            while (input != "Adopted")
            {
                int foodEaten = int.Parse(input);
                totalFoodEaten += foodEaten;
                input = Console.ReadLine();
            }

            if (totalFoodEaten <= amountOfFoodBoughtInGrams)
            {
                Console.WriteLine($"Food is enough! Leftovers: {amountOfFoodBoughtInGrams - totalFoodEaten} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {totalFoodEaten - amountOfFoodBoughtInGrams} grams more.");
            }
        }
    }
}
