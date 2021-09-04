using System;
using System.Collections.Generic;

namespace ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<char> charsInput = new List<char>();

            foreach (char currentChar in input)
            {
                charsInput.Add(currentChar);
            }

            int index = 1;

            for (int i = 1; i < input.Length; i++)
            {
                if (charsInput[index] == charsInput[index - 1])
                {
                    charsInput.RemoveAt(index);
                }
                else
                {
                    index++;
                }
            }

            Console.WriteLine(string.Join("", charsInput));
        }
    }
}
