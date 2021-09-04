using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double neededTimeFor1Meter = double.Parse(Console.ReadLine());

            double totalSeconds = distanceInMeters * neededTimeFor1Meter;
            double addedSecondsPer15Meters = Math.Floor(distanceInMeters / 15) * 12.5;
            double totalTime = totalSeconds + addedSecondsPer15Meters;

            if (recordInSeconds > totalTime)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
            else if (recordInSeconds <= totalTime)
            {
                Console.WriteLine($"No, he failed! He was {totalTime - recordInSeconds:f2} seconds slower.");
            }
        }
    }
}
