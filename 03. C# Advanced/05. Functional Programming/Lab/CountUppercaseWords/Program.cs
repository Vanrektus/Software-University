using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> predicate = x => char.IsUpper(x[0]);

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => predicate(x))
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, input));
        }
    }
}
