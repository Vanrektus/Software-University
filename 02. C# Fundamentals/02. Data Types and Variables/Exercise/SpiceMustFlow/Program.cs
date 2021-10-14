using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int daysCounter = 0;
            int totalSpiceExctracted = 0;

            while (startingYield >= 100)
            {
                daysCounter++;
                totalSpiceExctracted += startingYield - 26;
                startingYield -= 10;
            }
            totalSpiceExctracted -= 26;
            if (totalSpiceExctracted < 0)
            {
                totalSpiceExctracted = 0;
            }

            Console.WriteLine(daysCounter);
            Console.WriteLine(totalSpiceExctracted);
        }
    }
}
