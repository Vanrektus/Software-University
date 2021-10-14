using System;

namespace StackOverflowException
{
    class Program
    {
        static void Main(string[] args)
        {
            StackOverflowSux();
        }

        static unsafe void StackOverflowSux()
        {
            int x = 5;

            Console.WriteLine((int)&x);

            StackOverflowSux();
        }
    }
}
