using System;

namespace MountainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double timeInSecondsPerOneMeter = double.Parse(Console.ReadLine());

            double currentSeconds = distanceInMeters * timeInSecondsPerOneMeter;

            if (distanceInMeters >= 50)
            {
                currentSeconds += Math.Floor(distanceInMeters / 50) * 30;
            }

            if (currentSeconds < recordInSeconds)
            {
                Console.WriteLine($"Yes! The new record is {currentSeconds:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {currentSeconds - recordInSeconds:f2} seconds slower.");
            }
        }
    }
}
