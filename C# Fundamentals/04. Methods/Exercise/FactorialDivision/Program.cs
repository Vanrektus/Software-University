using System;

namespace FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            double result = Factorial(firstNumber, secondNumber);

            Console.WriteLine($"{result:f2}");
        }

        static double Factorial(double a, double b)
        {
            double firstFactorial = 1;
            double secondFactorial = 1;

            int originalFirstNumber = (int)a;
            int originalSecondNumber = (int)b;

            for (int i = 1; i <= originalFirstNumber; i++)
            {
                firstFactorial *= a;

                a -= 1;
            }

            for (int j = 1; j <= originalSecondNumber; j++)
            {
                secondFactorial *= b;

                b -= 1;
            }

            double result = firstFactorial / secondFactorial;

            return result;
        }
    }
}
