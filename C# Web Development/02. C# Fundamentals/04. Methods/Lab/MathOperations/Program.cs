using System;

namespace MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            double result = Calculations(firstNumber, operation, secondNumber);

            Console.WriteLine(result);
        }

        static double Calculations(int a, char operation, int b)
        {
            double calculationResult = 0.0;

            switch (operation)
            {
                case '/':
                    calculationResult = a / b;
                    break;
                case '*':
                    calculationResult = a * b;
                    break;
                case '+':
                    calculationResult = a + b;
                    break;
                case '-':
                    calculationResult = a - b;
                    break;
            }

            return calculationResult;
        }
    }
}
