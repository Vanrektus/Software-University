using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Queue<string> kids = new Queue<string>(input);
            int n = int.Parse(Console.ReadLine());

            while (kids.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    kids.Enqueue(kids.Dequeue());
                }

                Console.WriteLine($"Removed {kids.Dequeue()}");
            }

            Console.WriteLine($"Last is {kids.Peek()}");
        }
    }
}
