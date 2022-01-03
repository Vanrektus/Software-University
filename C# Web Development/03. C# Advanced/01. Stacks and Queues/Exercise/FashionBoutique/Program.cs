using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int capacity = int.Parse(Console.ReadLine());
            int racksUsed = 1;
            int currentRack = 0;

            Stack<int> pileOfClothers = new Stack<int>(input);

            while (pileOfClothers.Count > 0)
            {
                if (currentRack + pileOfClothers.Peek() <= capacity)
                {
                    currentRack += pileOfClothers.Pop();
                }
                else
                {
                    racksUsed++;
                    currentRack = 0;
                    currentRack += pileOfClothers.Pop();
                }
            }

            Console.WriteLine(racksUsed);
        }
    }
}
