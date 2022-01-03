namespace Vehicles
{
    public class Bus : Vehicle
    {
        //---------------------------Fields---------------------------
        private readonly double fuelConsumption;
        private readonly double tankCapacity;

        //---------------------------Properties---------------------------
        public double FuelQuantity { get; private set; }

        //---------------------------Constructors---------------------------
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.fuelConsumption = fuelConsumption + 1.4;
            this.tankCapacity = tankCapacity;

            if (fuelQuantity > tankCapacity)
            {
                this.FuelQuantity = 0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }
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
                return "Bus needs refueling";
            }
        }

        public string DriveEmpty(double distance)
        {
            if (distance * (this.fuelConsumption - 1.4) <= this.FuelQuantity)
            {
                this.FuelQuantity -= distance * (this.fuelConsumption - 1.4);
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return "Bus needs refueling";
            }
        }

        public override void Refuel(double liters)
        {
            if (liters > 0)
            {
                if (this.FuelQuantity + liters <= this.tankCapacity)
                {
                    this.FuelQuantity += liters;
                }
                else
                {
                    System.Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                }
            }
            else
            {
                System.Console.WriteLine("Fuel must be a positive number");
            }
        }
    }
}
