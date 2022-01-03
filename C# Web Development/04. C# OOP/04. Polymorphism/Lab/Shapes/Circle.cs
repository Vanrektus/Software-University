using System;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        //---------------------------Fields---------------------------
        private readonly double radius;

        //---------------------------Constructors---------------------------
        public Circle(double radius)
        {
            this.radius = radius;
        }

        //---------------------------Methods---------------------------
        public override double CalculatePerimeter()
        {
            return (2 * Math.PI * this.radius);
        }

        public override double CalculateArea()
        {
            return (Math.PI * Math.Pow(this.radius, 2));
        }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.Draw());
            sb.AppendLine("Circle");

            return sb.ToString().TrimEnd();
        }
    }
}
