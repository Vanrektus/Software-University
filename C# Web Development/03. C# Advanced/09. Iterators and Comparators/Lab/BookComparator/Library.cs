using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        //---------------------------Fields---------------------------
        private readonly SortedSet<Book> books;

        //---------------------------Constructors---------------------------
        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books);
        }

        //---------------------------Methods---------------------------
        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //---------------------------Nested Class---------------------------
        private class LibraryIterator : IEnumerator<Book>
        {
            //---------------------------Fields---------------------------
            private readonly IList<Book> books;

            private int currentIndex = -1;

            //---------------------------Properties---------------------------
            public Book Current => books[currentIndex];

            object IEnumerator.Current => Current;

            //---------------------------Constructors---------------------------
            public LibraryIterator(IEnumerable<Book> books)
            {
                Reset();
                this.books = new List<Book>(books);
            }

            //---------------------------Methods---------------------------
            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                return ++currentIndex < books.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }
        }
    }
}
