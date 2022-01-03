using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> index = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    index.Push(i);
                }
                else if (input[i] == ')')
                {
                    Console.WriteLine(input.Substring(index.Peek(), i - index.Pop() + 1));
                }
            }
        }
    }
}
