using System;
using System.Collections.Generic;

namespace GenericCountMethodDoubles
{
    public class Box<T> where T : IComparable
    {
        //---------------------------Fields---------------------------
        private readonly List<T> List;

        //---------------------------Constructors---------------------------
        public Box()
        {
            this.List = new List<T>();
        }

        //---------------------------Methods---------------------------
        public void Add(T value)
        {
            List.Add(value);
        }

        public int GreaterValueCounter(T elementForComparison)
        {
            int count = 0;

            foreach (T currentElement in List)
            {
                if (currentElement.CompareTo(elementForComparison) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
