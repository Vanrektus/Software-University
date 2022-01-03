using System;

namespace RecursionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine("Hello world!");
            //}

            Print(10);
        }

        private static void Print(int n)
        {
            if (n == 0)
            {
                return;
            }

            Console.WriteLine("Hello world! " + n);
            Print(n - 1);
        }
    }
}
