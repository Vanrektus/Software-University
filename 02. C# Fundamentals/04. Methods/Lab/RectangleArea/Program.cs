using System;

namespace RectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            double result = Calculations(width, height);

            Console.WriteLine(result);
        }

        static double Calculations(int a, int b)
        {
            double rectangleArea = a * b;

            return rectangleArea;
        }
    }
}
