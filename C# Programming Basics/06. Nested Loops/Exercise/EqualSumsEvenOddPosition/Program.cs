using System;

namespace EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            for (int currentNum = num1; currentNum <= num2; currentNum++)
            {
                int number = currentNum;
                int evenSum = 0;
                int oddSum = 0;

                for (int j = 1; j <= 6; j++)
                {
                    int digit = number % 10;
                    if (j % 2 == 0)
                    {
                        oddSum += digit;
                    }
                    else
                    {
                        evenSum += digit;
                    }
                    number = number / 10;
                }
                if (evenSum == oddSum)
                {
                    Console.Write($"{currentNum} ");
                }
            }
        }
    }
}
