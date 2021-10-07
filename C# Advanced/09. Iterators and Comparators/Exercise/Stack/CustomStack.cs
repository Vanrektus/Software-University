using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        //---------------------------Fields---------------------------
        private readonly IList<T> list;

        private int currentIndex = -1;

        //---------------------------Constructors---------------------------
        public CustomStack()
        {
            list = new List<T>();
        }

        //---------------------------Methods---------------------------
        public void Push(params T[] items)
        {
            foreach (var item in items)
            {
                list.Insert(++currentIndex, item);
            }
        }

        public void Pop()
        {
            if (currentIndex < 0)
            {
                throw new InvalidOperationException("No elements");
            }

            currentIndex--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = currentIndex; i >= 0; i--)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
