using System;

namespace AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int result = Subtract(firstNumber, secondNumber, thirdNumber);

            Console.WriteLine(result);
        }

        static int Sum(int a, int b)
        {
            int result = a + b;

            return result;
        }

        static int Subtract(int a, int b, int c)
        {
            int result = Sum(a, b) - c;

            return result;
        }
    }
}
