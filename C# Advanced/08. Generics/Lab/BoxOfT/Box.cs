﻿using System.Collections.Generic;
using System.Linq;

namespace BoxOfT
{
    public class Box<T>
    {
        private readonly List<T> elements; // = new List<T>();

        public int Count
        {
            get
            {
                return elements.Count;
            }
        }

        public Box()
        {
            elements = new List<T>();
        }

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
