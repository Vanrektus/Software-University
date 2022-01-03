using System;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                int currentNumber = i;
                int specialNumberCounter = 0;
                for (int j = 1; j <= 4; j++)
                {
                    int digit = currentNumber % 10;
                    if (digit == 0)
                    {
                        break;
                    }
                    if (number % digit == 0)
                    {
                        specialNumberCounter++;
                    }
                    currentNumber = currentNumber / 10;
                }
                if (specialNumberCounter == 4)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
