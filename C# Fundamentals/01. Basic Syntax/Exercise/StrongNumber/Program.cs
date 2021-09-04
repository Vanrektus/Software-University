using System;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int originalNumber = number;
            int totalSum = 0;

            while (number > 0)
            {
                int currentSum = 1;

                for (int i = 1; i <= number % 10; i++)
                {
                    currentSum *= i;
                }

                totalSum += currentSum;

                number /= 10;
            }

            if (originalNumber == totalSum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
