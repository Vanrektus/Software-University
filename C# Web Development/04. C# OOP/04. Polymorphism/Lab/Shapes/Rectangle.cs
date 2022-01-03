using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        //---------------------------Fields---------------------------
        private readonly double height;
        private readonly double width;

        //---------------------------Constructors---------------------------
        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        //---------------------------Methods---------------------------
        public override double CalculatePerimeter()
        {
            return (2 * this.height) + (2 * this.width);
        }

        public override double CalculateArea()
        {
            return (this.height * this.width);
        }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.Draw());
            sb.AppendLine("Rectangle");

            return sb.ToString().TrimEnd();
        }
    }
}
