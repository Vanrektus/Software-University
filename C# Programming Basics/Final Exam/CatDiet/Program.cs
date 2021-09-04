using System;

namespace CatDiet
{
    class Program
    {
        static void Main(string[] args)
        {
            double percentOfFats = double.Parse(Console.ReadLine());
            double percentOfProtein = double.Parse(Console.ReadLine());
            double percentOfCarbohydrates = double.Parse(Console.ReadLine());
            double totalCalories = double.Parse(Console.ReadLine());
            double percentOfWater = double.Parse(Console.ReadLine());

            double totalFats = (totalCalories * (percentOfFats / 100)) / 9;
            double totalProtein = (totalCalories * (percentOfProtein / 100)) / 4;
            double totalCarbohydrates = (totalCalories * (percentOfCarbohydrates / 100)) / 4;
            double totalWeight = totalFats + totalProtein + totalCarbohydrates;
            double caloriesPerGram = totalCalories / totalWeight;
            double caloriesPerGramWithoutWater = caloriesPerGram - (caloriesPerGram * (percentOfWater / 100));

            Console.WriteLine($"{caloriesPerGramWithoutWater:f4}");

        }
    }
}
