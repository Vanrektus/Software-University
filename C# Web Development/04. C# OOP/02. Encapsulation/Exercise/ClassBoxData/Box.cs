using System;

namespace ClassBoxData
{
    public class Box
    {
        //---------------------------Fields---------------------------
        private double length;
        private double width;
        private double height;

        //---------------------------Properties---------------------------
        public double Length
        {
            get => this.length;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double SurfaceArea
        {
            get => this.CalculateSurfaceArea();
        }

        public double LateralSurfaceArea
        {
            get => this.CalculateLateralSurfaceArea();
        }

        public double Volume
        {
            get => this.CalculateVolume();
        }

        //---------------------------Constructors---------------------------
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        //---------------------------Methods---------------------------
        private double CalculateSurfaceArea()
        {
            return (2 * this.Length * this.Width) + 
                (2 * this.Length * this.Height) + 
                (2 * this.Width * this.Height);
        }

        private double CalculateLateralSurfaceArea()
        {
            return (2 * this.Length * height) + 
                (2 * this.Width * this.Height);
        }

        private double CalculateVolume()
        {
            return this.Length * this.Width * this.Height;
        }
    }
}
