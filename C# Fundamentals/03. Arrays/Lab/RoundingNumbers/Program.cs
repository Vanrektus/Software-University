using System;
using System.Linq;

namespace RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                double roundedNumber = Math.Round(array[i], MidpointRounding.AwayFromZero);

                Console.WriteLine($"{Convert.ToDecimal(array[i])} => {Convert.ToDecimal(roundedNumber)}");
            }

        }
    }
}
