using BookShop.Data;
using BookShop.Initializer;

namespace BookShop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (var dbContext = new BookShopContext())
            {
                DbInitializer.ResetDatabase(dbContext);
            }
        }
    }
}
