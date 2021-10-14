using System;

namespace RefractorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numbers; i++)
            {
                bool isTrue = false;
                int currentNumber = i;
                int sum = 0;

                while (currentNumber > 0)
                {
                    sum += currentNumber % 10;
                    currentNumber /= 10;
                }

                if (sum == 5 || sum == 7 || sum == 11 )
                {
                    isTrue = true;
                }

                Console.WriteLine($"{i} -> {isTrue}");
            }
        }
    }
}
