using System;

namespace MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            double result = Calculations(a, b);

            Console.WriteLine(result);
        }

        static double Calculations(double a, int b)
        {
            double result = Math.Pow(a, b);

            return result;
        }
    }
}
