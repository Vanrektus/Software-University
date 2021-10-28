namespace Cars
{
    public abstract class Car : ICar
    {
        //---------------------------Properties---------------------------
        public string Model { get; set; }
        public string Color { get; set; }

        //---------------------------Constructors---------------------------
        public Car(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        //---------------------------Methods---------------------------
        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
    }
}
