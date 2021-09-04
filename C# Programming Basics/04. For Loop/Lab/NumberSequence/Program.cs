using System;

namespace NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());

            int biggestNum = int.MinValue;
            int smallestNum = int.MaxValue;

            for (int i = 0; i < numberOfNumbers; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number > biggestNum)
                {
                    biggestNum = number;
                }
                if (number < smallestNum)
                {
                    smallestNum = number;
                }
            }
            Console.WriteLine($"Max number: {biggestNum}");
            Console.WriteLine($"Min number: {smallestNum}");
        }
    }
}
