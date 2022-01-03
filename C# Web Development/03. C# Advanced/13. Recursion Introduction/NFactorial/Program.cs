using System;

namespace NFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(number));
        }

        private static int Factorial(int number)
        {
            if (number == 1)
            {
                Console.WriteLine();
                return 1;
            }

            Console.WriteLine($"{number}! = {number} * {number - 1}!");

            int nMinus1Factorial = Factorial(number - 1);

            Console.WriteLine($"{number}! = {number} * {nMinus1Factorial}");

            return number * nMinus1Factorial;
        }
    }
}
