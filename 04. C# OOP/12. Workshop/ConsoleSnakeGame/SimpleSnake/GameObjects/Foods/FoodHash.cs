namespace SimpleSnake.GameObjects.Foods
{
    public class FoodHash : Food
    {
        //---------------------------Constants---------------------------
        private const char foodSymbol = '#';
        private const int points = 3;

        //---------------------------Constructors---------------------------
        public FoodHash(Wall wall)
            : base(wall, foodSymbol, points)
        {

        }
    }
}
