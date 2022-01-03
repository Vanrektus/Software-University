using System;

namespace OddEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());

            double oddSum = 0.0;
            double evenSum = 0.0;
            double oddMin = int.MaxValue;
            double oddMax = int.MinValue;
            double evenMin = int.MaxValue;
            double evenMax = int.MinValue;

            for (int i = 1; i <= numberOfNumbers; i++)
            {
                double number = double.Parse(Console.ReadLine());
                if (i % 2 != 0)
                {
                    oddSum += number;
                    if (oddMin > number)
                    {
                        oddMin = number;
                    }
                    if (oddMax < number)
                    {
                        oddMax = number;
                    }
                }
                else
                {
                    evenSum += number;
                    if (evenMin > number)
                    {
                        evenMin = number;
                    }
                    if (evenMax < number)
                    {
                        evenMax = number;
                    }
                }
            }
            if (oddSum != 0)
            {
                Console.WriteLine($"OddSum={oddSum:f2},");
                Console.WriteLine($"OddMin={oddMin:f2},");
                Console.WriteLine($"OddMax={oddMax:f2},");
            }
            else
            {
                Console.WriteLine($"OddSum={oddSum:f2},");
                Console.WriteLine("OddMin=No,");
                Console.WriteLine("OddMax=No,");
            }
            if (evenSum != 0)
            {
                Console.WriteLine($"EvenSum={evenSum:f2},");
                Console.WriteLine($"EvenMin={evenMin:f2},");
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }
            else
            {
                Console.WriteLine($"EvenSum={evenSum:f2},");
                Console.WriteLine("EvenMin=No,");
                Console.WriteLine("EvenMax=No");
            }
        }
    }
}
