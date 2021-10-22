namespace TheRace
{
    public class Car
    {
        //---------------------------Properties---------------------------
        public string Name { get; set; }

        public int Speed { get; set; }

        //---------------------------Constructors---------------------------
        public Car(string name, int speed)
        {
            this.Name = name;
            this.Speed = speed;
        }
    }
}
