using System;

namespace Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            double result = Calculations(operation, firstNumber, secondNumber);

            Console.WriteLine(result);
        }

        static double Calculations(string operation, int a, int b)
        {
            double calculationResult = 0.0;

            switch (operation)
            {
                case "add":
                    calculationResult = a + b;
                    break;
                case "subtract":
                    calculationResult = a - b;
                    break;
                case "multiply":
                    calculationResult = a * b;
                    break;
                case "divide":
                    calculationResult = a / b;
                    break;
            }

            return calculationResult;
        }
    }
}
