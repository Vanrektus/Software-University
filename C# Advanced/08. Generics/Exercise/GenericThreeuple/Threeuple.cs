namespace GenericThreeuple
{
    public class Threeuple<TFirst, TSecond, TThird>
    {
        //---------------------------Properties---------------------------
        public TFirst FirstItem { get; private set; }

        public TSecond SecondItem { get; private set; }

        public TThird ThirdItem { get; private set; }

        //---------------------------Constructors---------------------------
        public Threeuple(TFirst firstItem, TSecond secondItem, TThird thirdItem)
        {
            this.FirstItem = firstItem;
            this.SecondItem = secondItem;
            this.ThirdItem = thirdItem;
        }

        //---------------------------Methods---------------------------
        public override string ToString()
        {
            return $"{FirstItem} -> {SecondItem} -> {ThirdItem}";
        }
    }
}
