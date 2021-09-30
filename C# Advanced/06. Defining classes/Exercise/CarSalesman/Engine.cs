namespace CarSalesman
{
    class Engine
    {
        //---------------------------Properties---------------------------
        public string Model { get; private set; }
        public int Power { get; private set; }
        public string Displacement { get; private set; }
        public string Efficiency { get; private set; }

        //---------------------------Constructors---------------------------
        public Engine(string model, int power, string displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }
    }
}
