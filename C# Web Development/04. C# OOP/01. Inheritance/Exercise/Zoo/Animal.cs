namespace Zoo
{
    public class Animal
    {
        //---------------------------Propperties---------------------------
        public string Name { get; private set; }

        //---------------------------Constructors---------------------------
        public Animal(string name)
        {
            this.Name = name;
        }
    }
}
