using System;

namespace PrintAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());

            int totalSum = 0;

            for (int currentNumber = startNumber; currentNumber <= endNumber; currentNumber++)
            {
                totalSum += currentNumber;
                Console.Write($"{currentNumber} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Sum: {totalSum}");
        }
    }
}
