using System;

namespace MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberToConvert = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string output = Console.ReadLine();

            double mToMm = numberToConvert * 1000;
            double mToCm = numberToConvert * 100;
            double cmToM = numberToConvert / 100;
            double cmToMm = numberToConvert * 10;
            double mmToM = numberToConvert / 1000;
            double mmToCm = numberToConvert / 10;

            if (input == "m" && output == "mm")
            {
                Console.WriteLine($"{mToMm:f3}");
            }
            else if (input == "m" && output == "cm")
            {
                Console.WriteLine($"{mToCm:f3}");
            }
            else if (input == "cm" && output == "m")
            {
                Console.WriteLine($"{cmToM:f3}");
            }
            else if (input == "cm" && output == "mm")
            {
                Console.WriteLine($"{cmToMm:f3}");
            }
            else if (input == "mm" && output == "cm")
            {
                Console.WriteLine($"{mmToCm:f3}");
            }
            else if (input == "mm" && output == "m")
            {
                Console.WriteLine($"{mmToM:f3}");
            }
        }
    }
}
