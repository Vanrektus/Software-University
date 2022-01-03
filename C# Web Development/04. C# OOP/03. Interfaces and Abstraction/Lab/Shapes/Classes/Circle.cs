using System;

namespace Shapes
{
    public class Circle : IDrawable
    {
        //---------------------------Fields---------------------------
        private readonly int radius;

        //---------------------------Constructors---------------------------
        public Circle(int radius)
        {
            this.radius = radius;
        }

        //---------------------------Methods---------------------------
        public void Draw()
        {
            double radiusIn = this.radius - 0.4;
            double radiusOut = this.radius + 0.4;

            for (int y = this.radius; y >= -this.radius; --y)
            {
                for (double x = -this.radius; x < radiusOut; x += 0.5)
                {
                    double value = x * x + y * y;

                    if (value >= radiusIn * radiusIn && value <= radiusOut * radiusOut)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
