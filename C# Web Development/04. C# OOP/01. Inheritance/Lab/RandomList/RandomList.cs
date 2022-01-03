using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        //---------------------------Fields---------------------------
        private readonly Random rnd;

        //---------------------------Constructors---------------------------
        public RandomList()
        {
            this.rnd = new Random();
        }

        //---------------------------Methods---------------------------
        public string RandomString()
        {
            int randomIndex = rnd.Next(0, this.Count);

            return this[randomIndex];
        }

        public string RemoveRandomElement()
        {
            int randomIndex = rnd.Next(0, this.Count);

            string removedElement = this[randomIndex];

            this.RemoveAt(randomIndex);

            return removedElement;
        }
    }
}
