namespace GenericTuple
{
    public class Tuple<TFirst, TSecond>
    {
        public TFirst FirstItem { get; set; }

        public TSecond SecondItem { get; set; }

        public Tuple(TFirst firstItem, TSecond secondItem)
        {
            this.FirstItem = firstItem;
            this.SecondItem = secondItem;
        }

        public override string ToString()
        {
            return $"{FirstItem} -> {SecondItem}";
        }
    }
}
