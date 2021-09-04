using System;

namespace SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int oddNumbers = int.Parse(Console.ReadLine());

            int oddNumbersCounter = 0;
            int sum = 0;

            for (int i = 1; i <= oddNumbers * 2; i += 2)
            {
                sum += i;
                oddNumbersCounter++;
                Console.WriteLine(i);
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
