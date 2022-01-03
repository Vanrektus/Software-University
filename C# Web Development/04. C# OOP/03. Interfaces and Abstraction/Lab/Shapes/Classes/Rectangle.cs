using System;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        //---------------------------Fields---------------------------
        private readonly int width;
        private readonly int height;

        //---------------------------Constructors---------------------------
        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        //---------------------------Methods---------------------------
        public void Draw()
        {
            DrawLine('*', '*');

            for (int i = 0; i < height - 2; i++)
            {
                DrawLine('*', ' ');
            }

            DrawLine('*', '*');
        }

        private void DrawLine(char end, char middle)
        {
            Console.WriteLine($"{end}{new string(middle, width - 2)}{end}");
        }
    }
}
