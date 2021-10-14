using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> secondNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>(firstNumbers.Count + secondNumbers.Count);

            int limit = Math.Min(firstNumbers.Count, secondNumbers.Count);

            for (int i = 0; i < limit; i++)
            {
                result.Add(firstNumbers[i]);
                result.Add(secondNumbers[i]);
            }


            if (firstNumbers.Count > secondNumbers.Count)
            {
                result.AddRange(RemainingValues(firstNumbers, secondNumbers));
            }
            else if (firstNumbers.Count < secondNumbers.Count)
            {
                result.AddRange(RemainingValues(secondNumbers, firstNumbers));
            }

            Console.WriteLine(string.Join(" ", result));
        }

        static List<int> RemainingValues(List<int> longerList, List<int> shorterList)
        {
            List<int> remaining = new List<int>(longerList.Count - shorterList.Count);

            for (int i = shorterList.Count; i < longerList.Count; i++)
            {
                remaining.Add(longerList[i]);
            }

            return remaining;
        }
    }
}
