using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWaves = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> orcs = new Stack<int>();

            orcs = TheFight(numberOfWaves, plates, orcs);

            PrintOutput(plates, orcs);
        }

        private static Stack<int> TheFight(int numberOfWaves, Queue<int> plates, Stack<int> orcs)
        {
            for (int wave = 1; wave <= numberOfWaves; wave++)
            {
                orcs = new Stack<int>(Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse));

                if (wave % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }

                while (plates.Count > 0 && orcs.Count > 0)
                {
                    int currentPlate = plates.Peek();
                    int currentOrc = orcs.Peek();

                    if (currentPlate > currentOrc)
                    {
                        currentPlate -= currentOrc;

                        orcs.Pop();

                        plates.Dequeue();
                        plates.Enqueue(currentPlate);

                        for (int i = 0; i < plates.Count - 1; i++)
                        {
                            plates.Enqueue(plates.Dequeue());
                        }
                    }
                    else if (currentPlate < currentOrc)
                    {
                        currentOrc -= currentPlate;

                        orcs.Pop();
                        orcs.Push(currentOrc);

                        plates.Dequeue();
                    }
                    else if (currentPlate == currentOrc)
                    {
                        plates.Dequeue();
                        orcs.Pop();
                    }
                }

                if (plates.Count == 0)
                {
                    break;
                }
            }

            return orcs;
        }

        private static void PrintOutput(Queue<int> plates, Stack<int> orcs)
        {
            if (plates.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
        }
    }
}
