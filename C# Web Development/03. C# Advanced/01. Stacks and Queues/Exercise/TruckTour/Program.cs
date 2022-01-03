using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPumps = int.Parse(Console.ReadLine());

            Queue<int[]> pumpsCircle = new Queue<int[]>();

            for (int i = 0; i < numberOfPumps; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                int[] pumps = new int[3] { input[0], input[1], i };

                pumpsCircle.Enqueue(pumps);
            }

            int totalFuel = 0;

            for (int i = 0; i < numberOfPumps; i++)
            {
                int[] currentPump = pumpsCircle.Dequeue();
                int fuel = currentPump[0];
                int distance = currentPump[1];
                totalFuel += fuel;

                if (totalFuel >= distance)
                {
                    totalFuel -= distance;
                }
                else
                {
                    totalFuel = 0;
                    i = -1;
                }

                pumpsCircle.Enqueue(currentPump);
            }

            int[] firstElement = pumpsCircle.Dequeue();

            Console.WriteLine(firstElement[2]);
        }
    }
}
