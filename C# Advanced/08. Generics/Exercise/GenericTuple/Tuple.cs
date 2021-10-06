namespace GenericTuple
{
    public class Tuple<TFirst, TSecond>
    {
        //---------------------------Properties---------------------------
        public TFirst FirstItem { get; set; }

        public TSecond SecondItem { get; set; }

        //---------------------------Constructors---------------------------
        public Tuple(TFirst firstItem, TSecond secondItem)
        {
            this.FirstItem = firstItem;
            this.SecondItem = secondItem;
        }

        //---------------------------Methods---------------------------
        public override string ToString()
        {
            return $"{FirstItem} -> {SecondItem}";
        }
    }
}
