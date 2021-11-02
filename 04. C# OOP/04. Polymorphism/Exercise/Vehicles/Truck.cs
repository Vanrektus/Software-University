namespace Vehicles
{
    public class Truck : Vehicle
    {
        //---------------------------Fields---------------------------
        private readonly double fuelConsumption;

        //---------------------------Properties---------------------------
        public double FuelQuantity { get; private set; }

        //---------------------------Constructors---------------------------
        public Truck(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption + 1.6;
        }

        //---------------------------Methods---------------------------
        public override string Drive(double distance)
        {
            if (distance * this.fuelConsumption <= this.FuelQuantity)
            {
                this.FuelQuantity -= distance * this.fuelConsumption;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return "Truck needs refueling";
            }
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters * 0.95;
        }
    }
}
