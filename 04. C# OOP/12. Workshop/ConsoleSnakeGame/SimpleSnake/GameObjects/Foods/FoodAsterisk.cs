namespace SimpleSnake.GameObjects.Foods
{
    public class FoodAsterisk : Food
    {
        //---------------------------Constants---------------------------
        private const char foodSymbol = '*';
        private const int points = 1;

        //---------------------------Constructors---------------------------
        public FoodAsterisk(Wall wall) 
            : base(wall, foodSymbol, points)
        {

        }
    }
}
