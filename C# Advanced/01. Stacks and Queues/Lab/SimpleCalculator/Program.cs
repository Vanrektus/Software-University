using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();
            Stack<string> stack = new Stack<string>(input);

            while (stack.Count > 1)
            {
                int a = int.Parse(stack.Pop());
                char op = char.Parse(stack.Pop());
                int b = int.Parse(stack.Pop());

                switch (op)
                {
                    case '+':
                        stack.Push((a + b).ToString());
                        break;
                    case '-':
                        stack.Push((a - b).ToString());
                        break;
                }
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
