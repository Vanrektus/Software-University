using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        //---------------------------Constructors---------------------------
        public StackOfStrings()
        {

        }

        //---------------------------Methods---------------------------
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public Stack<string> AddRange(IEnumerable<string> collection)
        {
            foreach (string currentElement in collection)
            {
                this.Push(currentElement);
            }

            return this;
        }
    }
}
