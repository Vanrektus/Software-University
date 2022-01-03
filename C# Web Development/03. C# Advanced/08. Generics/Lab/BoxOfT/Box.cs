using System.Collections.Generic;
using System.Linq;

namespace BoxOfT
{
    public class Box<T>
    {
        //---------------------------Fields---------------------------
        private readonly List<T> elements; // = new List<T>();

        //---------------------------Properties---------------------------
        public int Count
        {
            get
            {
                return elements.Count;
            }
        }

        //---------------------------Constructors---------------------------
        public Box()
        {
            elements = new List<T>();
        }

        //---------------------------Methods---------------------------
        public void Add(T element)
        {
            elements.Add(element);
        }

        public T Remove()
        {
            T result = elements.LastOrDefault();
            elements.Remove(result);

            return result;
        }
    }
}
