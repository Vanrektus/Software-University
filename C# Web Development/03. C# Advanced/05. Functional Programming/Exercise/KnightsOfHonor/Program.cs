using System;
using System.Linq;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = x => x
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .ToList()
                   .ForEach(x => Console.WriteLine($"Sir {x}"));

            action(Console.ReadLine());



            //Console.ReadLine()
            //       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //       .ToList()
            //       .ForEach(x => Console.WriteLine($"Sir {x}"));
        }
    }
}
