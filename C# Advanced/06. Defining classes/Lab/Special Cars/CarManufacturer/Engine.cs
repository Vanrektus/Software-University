namespace CarManufacturer
{
    public class Engine
    {
        //---------------------------Fields---------------------------
        private int horsePower;
        private double cubicCapacity;

        //---------------------------Properties---------------------------
        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }

        public double CubicCapacity
        {
            get { return cubicCapacity; }
            set { cubicCapacity = value; }
        }

        //---------------------------Constructors---------------------------
        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
    }
}
