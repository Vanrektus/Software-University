using System;

namespace SignOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string result = SignOfNumbers(number);

            Console.WriteLine(result);
        }

        static string SignOfNumbers(int num)
        {
            string sign = "";

            if (num > 0)
            {
                sign = "positive";
            }
            else if (num < 0)
            {
                sign = "negative";
            }
            else
            {
                sign = "zero";
            }

            return $"The number {num} is {sign}.";
        }
    }
}
