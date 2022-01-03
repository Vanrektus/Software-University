using System;

namespace VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int vowelsCounter = 0;

            int result = VowelsCount(input, vowelsCounter);

            Console.WriteLine(result);
        }

        static int VowelsCount(string input, int count)
        {
            int vowelsCounter = 0;

            foreach (char currentChar in input)
            {
                if (currentChar == 65
                    || currentChar == 69
                    || currentChar == 73
                    || currentChar == 79
                    || currentChar == 85
                    || currentChar == 89
                    || currentChar == 97
                    || currentChar == 101
                    || currentChar == 105
                    || currentChar == 111
                    || currentChar == 117
                    || currentChar == 121)
                {
                    vowelsCounter++;
                }
            }

            return vowelsCounter;
        }
    }
}
