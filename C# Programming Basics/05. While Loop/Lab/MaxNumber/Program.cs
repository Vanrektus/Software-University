using System;

namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int biggestNumber = int.MinValue;

            while (input != "Stop")
            {
                int newNumber = int.Parse(input);
                if (newNumber > biggestNumber)
                {
                    biggestNumber = newNumber;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(biggestNumber);
        }
    }
}
