using System;

namespace Randomize
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Random rndNumber = new Random();

            for (int firstIndex = 0; firstIndex < input.Length - 1; firstIndex++)
            {
                int secondIndex = rndNumber.Next(0, input.Length - 1);
                string originalWord = input[firstIndex];

                input[firstIndex] = input[secondIndex];
                input[secondIndex] = originalWord;
            }

            Console.Write(string.Join(Environment.NewLine, input));
        }
    }
}
