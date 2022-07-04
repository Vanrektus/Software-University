using P03_FootballBetting.Data;

namespace P03_FootballBetting
{
    public class Program
    {
        static void Main(string[] args)
        {
            var context = new FootballBettingContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
