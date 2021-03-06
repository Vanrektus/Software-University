using System;
using System.Collections.Generic;

namespace Iterator
{
    public class ListyIterator<T>// : IEnumerator<T>
    {
        //---------------------------Fields---------------------------
        private readonly IList<T> list;

        private int currentIndex = 0;

        //---------------------------Constructors---------------------------
        public ListyIterator(params T[] list)
        {
            this.list = new List<T>(list);
        }

        //---------------------------Methods---------------------------
        public bool Move()
        {
            if (currentIndex < list.Count - 1)
            {
                currentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return currentIndex + 1 < list.Count;
        }

        public void Print()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(list[currentIndex]);
        }
    }
}
