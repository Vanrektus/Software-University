namespace CarManufacturer
{
    public class Tire
    {
        //---------------------------Fields---------------------------
        private int year;
        private double pressure;

        //---------------------------Properties---------------------------
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }

        //---------------------------Constructors---------------------------
        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
    }
}
