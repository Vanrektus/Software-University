using System;

namespace MiltiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int positiveNumber = Math.Abs(number);
            int positiveNumberCopy = positiveNumber;

            int evenSum = GetSumOfEvenDigits(positiveNumber);
            int oddSum = GetSumOfOddDigits(positiveNumberCopy);

            int evenOddMultiply = evenSum * oddSum;

            Console.WriteLine(evenOddMultiply);
        }

        static int GetSumOfEvenDigits(int num)
        {
            int evenSum = 0;

            while (num > 0)
            {
                if (num % 2 == 0)
                {
                    evenSum += num % 10;
                }

                num /= 10;
            }

            return evenSum;
        }

        static int GetSumOfOddDigits(int num)
        {
            int oddSum = 0;

            while (num > 0)
            {
                if (num % 2 != 0)
                {
                    oddSum += num % 10;
                }

                num /= 10;
            }

            return oddSum;
        }
    }
}
