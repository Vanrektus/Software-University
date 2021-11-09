namespace DetailPrinter
{
    public class Employee : IEmployee
    {
        //---------------------------Properties---------------------------
        public string Name { get; private set; }

        //---------------------------Constructors---------------------------
        public Employee(string name)
        {
            this.Name = name;
        }

        //---------------------------Methods---------------------------
        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
