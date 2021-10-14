using System;

namespace OperationBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double number1 = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());
            string action = Console.ReadLine();

            double result = 0.0;

            switch (action)
            {
                case "+":
                    result = number1 + number2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{number1} + {number2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{number1} + {number2} = {result} - odd");
                    }
                    break;
                case "-":
                    result = number1 - number2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{number1} - {number2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{number1} - {number2} = {result} - odd");
                    }
                    break;
                case "*":
                    result = number1 * number2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{number1} * {number2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{number1} * {number2} = {result} - odd");
                    }
                    break;
                case "/":
                    result = number1 / number2;
                    if (number2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {number1} by zero");
                    }
                    else
                    {
                        Console.WriteLine($"{number1} / {number2} = {result:f2}");
                    }
                    break;
                case "%":
                    result = number1 % number2;
                    if (number2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {number1} by zero");
                    }
                    else
                    {
                        Console.WriteLine($"{number1} % {number2} = {result}");
                    }
                    break;
            }
        }
    }
}
