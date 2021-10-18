namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        //---------------------------Constants---------------------------
        private const double DefaultFuelConsumption = 8;

        //---------------------------Constructors---------------------------
        public RaceMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {

        }

        //---------------------------Methods---------------------------
        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
