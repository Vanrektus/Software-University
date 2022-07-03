using P03_FootballBetting.Data;

namespace P03_FootballBetting
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var context = new FootballBettingContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
