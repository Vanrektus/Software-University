using System;

namespace TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 97; i < 97 + num; i++)
            {
                for (int j = 97; j < 97 + num; j++)
                {
                    for (int k = 97; k < 97 + num; k++)
                    {
                        Console.WriteLine($"{(char)i}{(char)j}{(char)k}");
                    }
                }
            }
        }
    }
}
