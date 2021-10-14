using System;

namespace DivideWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());

            double divideBy2 = 0;
            double divideBy3 = 0;
            double divideBy4 = 0;

            for (int i = 1; i <= numberOfNumbers; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number % 2 == 0)
                {
                    divideBy2++;
                }
                if (number % 3 == 0)
                {
                    divideBy3++;
                }
                if (number % 4 == 0)
                {
                    divideBy4++;
                }
            }
            Console.WriteLine($"{divideBy2 / numberOfNumbers * 100:f2}%");
            Console.WriteLine($"{divideBy3 / numberOfNumbers * 100:f2}%");
            Console.WriteLine($"{divideBy4 / numberOfNumbers * 100:f2}%");
        }
    }
}
