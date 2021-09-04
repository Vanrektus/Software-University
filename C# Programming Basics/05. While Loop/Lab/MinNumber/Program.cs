using System;

namespace MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int smallestNumber = int.MaxValue;

            while (input != "Stop")
            {
                int newNumber = int.Parse(input);
                if (newNumber < smallestNumber)
                {
                    smallestNumber = newNumber;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(smallestNumber);
        }
    }
}
