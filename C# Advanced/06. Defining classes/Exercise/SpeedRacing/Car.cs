namespace SpeedRacing
{
    class Car
    {
        //---------------------------Properties---------------------------
        public string Model { get; private set; }
        public double FuelAmount { get; private set; }
        public double FuelConsumptionPerKilometer { get; private set; }
        public double TravelledDistance { get; private set; }

        //---------------------------Constructors---------------------------
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }

        //---------------------------Methods---------------------------
        public void Drive(int amountOfKm)
        {
            double leftFuel = this.FuelAmount - amountOfKm * this.FuelConsumptionPerKilometer;

            if (leftFuel >= 0)
            {
                this.TravelledDistance += amountOfKm;
                this.FuelAmount = leftFuel;
            }
            else
            {
                System.Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.TravelledDistance}";
        }
    }
}
