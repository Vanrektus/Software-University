using System;

namespace HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());

            int sum = 0;
            int biggestNumber = int.MinValue;

            for (int i = 1; i <= numberOfNumbers; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number;
                if (biggestNumber < number)
                {
                    biggestNumber = number;
                }
            }
            int sumWithoutBiggestNumber = sum - biggestNumber;
            if (biggestNumber == sumWithoutBiggestNumber)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sumWithoutBiggestNumber}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(biggestNumber - sumWithoutBiggestNumber)}");
            }
        }
    }
}
