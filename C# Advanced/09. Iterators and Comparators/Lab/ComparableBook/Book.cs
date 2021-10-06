using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        //---------------------------Properties---------------------------
        public string Title { get; private set; }

        public int Year { get; private set; }

        public IReadOnlyList<string> Authors { get; private set; }

        //---------------------------Constructors---------------------------
        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = new List<string>(authors);
        }

        //---------------------------Methods---------------------------
        public int CompareTo(Book other)
        {
            int result = this.Year.CompareTo(other.Year);

            if (result == 0)
            {
                result = this.Title.CompareTo(other.Title);
            }

            return result;
        }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
    }
}
