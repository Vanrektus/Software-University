using System;

namespace CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            CharsInRange(firstChar, secondChar);

        }

        static void CharsInRange(char firstChar, char secondChar)
        {
            if (firstChar > secondChar)
            {
                for (int currentChar = secondChar + 1; currentChar < firstChar; currentChar++)
                {
                    Console.Write($"{(char)currentChar} ");
                }
            }
            else if (secondChar > firstChar)
            {
                for (int currentChar = firstChar + 1; currentChar < secondChar; currentChar++)
                {
                    Console.Write($"{(char)currentChar} ");
                }
            }
        }
    }
}
