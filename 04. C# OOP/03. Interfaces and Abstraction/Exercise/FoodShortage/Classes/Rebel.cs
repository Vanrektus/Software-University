namespace BorderControl
{
    public class Rebel : IBuyer
    {
        //---------------------------Properties---------------------------
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Group { get; private set; }
        public int Food { get; private set; } = 0;

        //---------------------------Constructors---------------------------
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        //---------------------------Methods---------------------------
        public void BuyFood()
        {
            Food += 5;
        }
    }
}
