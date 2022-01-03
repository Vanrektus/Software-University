using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());

            double sumUnder200 = 0;
            double sum200To399 = 0;
            double sum400To599 = 0;
            double sum600To799 = 0;
            double sumOver800 = 0;

            for (int i = 1; i <= numberOfNumbers; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 200)
                {
                    sumUnder200++;
                }
                else if (number >= 200 && number <= 399)
                {
                    sum200To399++;
                }
                else if (number >= 400 && number <= 599)
                {
                    sum400To599++;
                }
                else if (number >= 600 && number <= 799)
                {
                    sum600To799++;
                }
                else if (number >= 800)
                {
                    sumOver800++;
                }
            }
            Console.WriteLine($"{sumUnder200 / numberOfNumbers * 100:f2}%");
            Console.WriteLine($"{sum200To399 / numberOfNumbers * 100:f2}%");
            Console.WriteLine($"{sum400To599 / numberOfNumbers * 100:f2}%");
            Console.WriteLine($"{sum600To799 / numberOfNumbers * 100:f2}%");
            Console.WriteLine($"{sumOver800 / numberOfNumbers * 100:f2}%");
        }
    }
}
