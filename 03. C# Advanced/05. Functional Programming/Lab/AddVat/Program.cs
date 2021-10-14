using System;
using System.Linq;

namespace AddVat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(n => n * 1.20M)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n:f2}"));
        }
    }
}
