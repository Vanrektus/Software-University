namespace GenericBoxOfInteger
{
    public class Box<T>
    {
        //---------------------------Properties---------------------------
        public T Value { get; set; }

        //---------------------------Constructors---------------------------
        public Box(T value)
        {
            this.Value = value;
        }

        //---------------------------Methods---------------------------
        public override string ToString()
        {
            return $"{Value.GetType()}: {Value}";
        }
    }
}
