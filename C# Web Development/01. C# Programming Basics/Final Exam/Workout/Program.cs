using System;

namespace Workout
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDays = int.Parse(Console.ReadLine());
            double startingDistance = double.Parse(Console.ReadLine());

            double totalDistance = startingDistance;
            double currentDistance = startingDistance;

            for (int i = 1; i <= numberOfDays; i++)
            {
                double percentMoreDistance = double.Parse(Console.ReadLine());

                totalDistance += currentDistance + (currentDistance * (percentMoreDistance / 100));
                currentDistance += currentDistance * (percentMoreDistance / 100);
            }

            if (totalDistance >= 1000)
            {
                Console.WriteLine($"You've done a great job running {Math.Ceiling(totalDistance - 1000)} more kilometers!");
            }
            else
            {
                Console.WriteLine($"Sorry Mrs. Ivanova, you need to run {Math.Ceiling(1000 - totalDistance)} more kilometers");
            }
        }
    }
}
