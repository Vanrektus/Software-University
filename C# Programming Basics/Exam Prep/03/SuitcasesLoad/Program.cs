using System;

namespace SuitcasesLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            double trunkCapacity = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int suitcaseCounter = 0;
            double totalSpaceTaken = 0;

            while (input != "End")
            {
                double suitcaseVolume = double.Parse(input);

                suitcaseCounter++;

                if (suitcaseCounter % 3 == 0)
                {
                    suitcaseVolume += suitcaseVolume * 0.1;
                }

                totalSpaceTaken += suitcaseVolume;

                if (totalSpaceTaken > trunkCapacity)
                {
                    suitcaseCounter--;
                    break;
                }
                
                input = Console.ReadLine();
            }

            if (totalSpaceTaken > trunkCapacity)
            {
                Console.WriteLine($"No more space!");
                Console.WriteLine($"Statistic: {suitcaseCounter} suitcases loaded.");
            }
            else
            {
                Console.WriteLine($"Congratulations! All suitcases are loaded!");
                Console.WriteLine($"Statistic: {suitcaseCounter} suitcases loaded.");
            }
        }
    }
}
