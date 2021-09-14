using System;
using System.Collections.Generic;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Stack<char> charString = new Stack<char>(input);

            while (charString.Count > 0)
            {
                Console.Write(charString.Pop());
            }

            Console.WriteLine();
        }
    }
}
