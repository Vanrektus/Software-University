using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Book
    {
        //---------------------------Properties---------------------------
        public string Title { get; set; }

        public int Year { get; set; }

        public IEnumerable<string> Authors { get; set; }

        //---------------------------Constructors---------------------------
        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = new List<string>(authors);
        }
    }
}
