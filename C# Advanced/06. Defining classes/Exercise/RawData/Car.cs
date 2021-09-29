namespace RawData
{
    class Car
    {
        //---------------------------Properties---------------------------
        public string Model { get; private set; }
        public Engine Engine { get; private set; }
        public Cargo Cargo { get; private set; }
        public Tire[] Tire { get; set; }

        //---------------------------Constructors---------------------------
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tire = tires;
        }

        public override string ToString()
        {
            return $"{this.Model}";
        }
    }
}
