using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> scarfs = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int mostExpensiveSet = 0;
            Queue<int> createdSets = new Queue<int>();

            GoingThroughHatsAndScarfs(hats, scarfs, ref mostExpensiveSet, createdSets);

            Console.WriteLine($"The most expensive set is: {mostExpensiveSet}");
            Console.WriteLine(string.Join(" ", createdSets));
        }

        private static void GoingThroughHatsAndScarfs(Stack<int> hats, Queue<int> scarfs, ref int mostExpensiveSet, Queue<int> createdSets)
        {
            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int currentHat = hats.Peek();
                int currentScarf = scarfs.Peek();

                if (currentHat > currentScarf)
                {
                    createdSets.Enqueue(currentHat + currentScarf);

                    if ((currentHat + currentScarf) > mostExpensiveSet)
                    {
                        mostExpensiveSet = currentHat + currentScarf;
                    }

                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (currentHat < currentScarf)
                {
                    hats.Pop();
                    continue;
                }
                else
                {
                    scarfs.Dequeue();
                    currentHat++;
                    hats.Pop();
                    hats.Push(currentHat);
                }
            }
        }
    }
}
