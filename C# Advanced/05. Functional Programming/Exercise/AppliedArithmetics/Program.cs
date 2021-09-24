using System;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int[]> add = n => n.Select(n => n + 1).ToArray();
            Func<int[], int[]> multiply = n => n.Select(n => n * 2).ToArray();
            Func<int[], int[]> subtract = n => n.Select(n => n - 1).ToArray();
            Action<int[]> print = n => Console.WriteLine(string.Join(" ", n));

            while (true)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "add":
                        numbers = add(numbers);
                        break;
                    case "multiply":
                        numbers = multiply(numbers);
                        break;
                    case "subtract":
                        numbers = subtract(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                    case "end":
                        return;
                }
            }
        }
    }
}
