using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> parenthesStack = new Stack<char>();

            foreach (var currentChar in input)
            {
                if (parenthesStack.Count > 0)
                {
                    char charCheck = parenthesStack.Peek();

                    if (charCheck == '{' && currentChar == '}')
                    {
                        parenthesStack.Pop();
                        continue;
                    }
                    else if (charCheck == '[' && currentChar == ']')
                    {
                        parenthesStack.Pop();
                        continue;
                    }
                    else if (charCheck == '(' && currentChar == ')')
                    {
                        parenthesStack.Pop();
                        continue;
                    }
                }
                parenthesStack.Push(currentChar);
            }
            Console.WriteLine(parenthesStack.Count == 0 ? "YES" : "NO");
        }
    }
}
