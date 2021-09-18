using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] setsLength = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<int> nSet = new HashSet<int>();
            HashSet<int> mSet = new HashSet<int>();
            HashSet<int> unique = new HashSet<int>();

            FillSets(setsLength, nSet, mSet);

            FindUniqueNumbers(nSet, mSet, unique);

            Console.WriteLine(string.Join(' ', unique));
        }

        private static void FillSets(int[] setsLength, HashSet<int> nSet, HashSet<int> mSet)
        {
            for (int n = 0; n < setsLength[0]; n++)
            {
                int newNumber = int.Parse(Console.ReadLine());

                nSet.Add(newNumber);
            }

            for (int m = 0; m < setsLength[1]; m++)
            {
                int newNumber = int.Parse(Console.ReadLine());

                mSet.Add(newNumber);
            }
        }

        private static void FindUniqueNumbers(HashSet<int> nSet, HashSet<int> mSet, HashSet<int> unique)
        {
            foreach (var n in nSet)
            {
                foreach (var m in mSet)
                {
                    if (n == m)
                    {
                        unique.Add(m);
                    }
                }
            }
        }
    }
}
