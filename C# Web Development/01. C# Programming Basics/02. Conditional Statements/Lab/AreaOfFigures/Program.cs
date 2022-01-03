using System;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            if (figure == "square")
            {
                double sideOfSquare = double.Parse(Console.ReadLine());
                double areaOfSquare = sideOfSquare * sideOfSquare;
                Console.WriteLine($"{areaOfSquare:f3}");
            }
            else if (figure == "rectangle")
            {
                double sideOfRectangle1 = double.Parse(Console.ReadLine());
                double sideOfRectangle2 = double.Parse(Console.ReadLine());
                double areaOfRectangle = sideOfRectangle1 * sideOfRectangle2;
                Console.WriteLine($"{areaOfRectangle:f3}");
            }
            else if (figure == "circle")
            {
                double radiusOfCircle = double.Parse(Console.ReadLine());
                double areaOfCircle = radiusOfCircle * radiusOfCircle * Math.PI;
                Console.WriteLine($"{areaOfCircle:f3}");
            }
            else if (figure == "triangle")
            {
                double sideOfTriangle = double.Parse(Console.ReadLine());
                double heightOfTriangle = double.Parse(Console.ReadLine());
                double areaOfTriangle = sideOfTriangle * heightOfTriangle / 2;
                Console.WriteLine($"{areaOfTriangle:f3}");
            }
        }
    }
}
