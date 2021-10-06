using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    class Library : IEnumerable<Book>
    {
        //---------------------------Fields---------------------------
        private readonly IList<Book> books;

        //---------------------------Constructors---------------------------
        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        //---------------------------Methods---------------------------
        public IEnumerator<Book> GetEnumerator()
        {
            return books.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
