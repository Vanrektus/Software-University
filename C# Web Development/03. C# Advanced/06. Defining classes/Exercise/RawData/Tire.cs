namespace RawData
{
    class Tire
    {
        //---------------------------Properties---------------------------
        public double Pressure { get; private set; }
        public int Age { get; private set; }

        //---------------------------Constructors---------------------------
        public Tire(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }
    }
}
