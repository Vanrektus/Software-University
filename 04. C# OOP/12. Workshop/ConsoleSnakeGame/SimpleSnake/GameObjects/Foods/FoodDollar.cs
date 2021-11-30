namespace SimpleSnake.GameObjects.Foods
{
    public class FoodDollar : Food
    {
        //---------------------------Constants---------------------------
        private const char foodSymbol = '$';
        private const int points = 2;

        //---------------------------Constructors---------------------------
        public FoodDollar(Wall wall)
            : base(wall, foodSymbol, points)
        {

        }
    }
}
