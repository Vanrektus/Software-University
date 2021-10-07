using System;
using System.Collections.Generic;

namespace Iterator
{
    public class ListyIterator<T>
    {
        //---------------------------Fields---------------------------
        private readonly IList<T> list;

        private int currentIndex = 1;

        //---------------------------Constructors---------------------------
        public ListyIterator(params T[] list)
        {
            this.list = new List<T>(list);
        }

        //---------------------------Methods---------------------------
        public bool Move()
        {
            if (currentIndex + 1 < list.Count)
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
            if (list.Count > 1)
            {
                Console.WriteLine(list[currentIndex]);
            }
            else
            {
                Console.WriteLine("Invalid Operation!");
            }
        }
    }
}
