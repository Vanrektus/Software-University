using System;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string shorterLength = string.Empty;
            string longerLength = string.Empty;
            int charsSum = 0;

            if (input[0].Length > input[1].Length)
            {
                longerLength = input[0];
                shorterLength = input[1];
            }
            else
            {
                longerLength = input[1];
                shorterLength = input[0];
            }

            for (int i = 0; i < shorterLength.Length; i++)
            {
                charsSum += longerLength[i] * shorterLength[i];
            }

            for (int i = shorterLength.Length; i < longerLength.Length; i++)
            {
                charsSum += longerLength[i];
            }

            Console.WriteLine(charsSum);
        }
    }
}
