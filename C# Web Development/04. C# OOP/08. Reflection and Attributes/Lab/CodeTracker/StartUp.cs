namespace AuthorProblem
{
    [Author("Vancho")]
    public class StartUp
    {
        [Author("Pack Vancho")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();

            tracker.PrintMethodsByAuthor();
        }
    }
}
