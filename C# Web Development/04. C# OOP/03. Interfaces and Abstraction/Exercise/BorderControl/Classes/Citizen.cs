namespace BorderControl
{
    public class Citizen : IIdentifiable
    {
        //---------------------------Properties---------------------------
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }

        //---------------------------Constructors---------------------------
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
    }
}
