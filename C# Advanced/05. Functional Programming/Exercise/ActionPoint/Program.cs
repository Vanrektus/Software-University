using System;
using System.Linq;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = x => x
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .ToList()
                   .ForEach(x => Console.WriteLine(x));

            action(Console.ReadLine());



            //string[] input = Console.ReadLine()
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //Action<string[]> action2 = x => Console.WriteLine(string.Join(Environment.NewLine, x));

            //action2(input);



            //Console.ReadLine()
            //       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //       .ToList()
            //       .ForEach(x => Console.WriteLine(x));
        }
    }
}
