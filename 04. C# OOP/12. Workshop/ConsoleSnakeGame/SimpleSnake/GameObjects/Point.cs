using System;

namespace SimpleSnake.GameObjects
{
    public class Point
    {
        //---------------------------Properties---------------------------
        public int LeftX { get; set; }
        public int TopY { get; set; }

        //---------------------------Constructors---------------------------
        public Point(int leftX, int topY)
        {
            this.LeftX = leftX;
            this.TopY = topY;
        }

        //---------------------------Methods---------------------------
        public void Draw(char symbol)
        {
            Console.SetCursorPosition(this.LeftX, this.TopY);
            Console.Write(symbol);
        }

        public void Draw(int leftX, int topY, char symbol)
        {
            Console.SetCursorPosition(leftX, topY);
            Console.Write(symbol);
        }
    }
}
