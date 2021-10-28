namespace PersonInfo
{
    public class Citizen : IPerson
    {
        //---------------------------Properties---------------------------
        public string Name { get; private set; }
        public int Age { get; private set; }

        //---------------------------Constructors---------------------------
        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
