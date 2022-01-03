using System;

namespace CatWalking
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesOfWalking = int.Parse(Console.ReadLine());
            int numOfWalks = int.Parse(Console.ReadLine());
            double caloriesPerDay = int.Parse(Console.ReadLine());

            double burntCalories = (minutesOfWalking * 5) * numOfWalks;

            if (burntCalories >= caloriesPerDay / 2)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {burntCalories}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {burntCalories}.");
            }
        }
    }
}
