using System;

namespace CustomDataStructures
{
    class CustomStack
    {
        private const int INITIAL_CAPACITY = 4;

        private const string EMPTY_STACK_EXC_MSG = "Stack is empy!";

        public int[] Items { get; private set; }

        public int Count { get; private set; }

        public CustomStack()
        {
            this.Items = new int[INITIAL_CAPACITY]; 
        }

        public void Push(int item)
        {
            if (this.Count == this.Items.Length)
            {
                this.Resize();
            }

            this.Items[this.Count] = item;
            this.Count++;
        }

        public int Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(EMPTY_STACK_EXC_MSG);
            }

            int poppedItem = this.Items[this.Count - 1];
            this.Items[this.Count - 1] = default;
            this.Count--;

            return poppedItem;
        }

        public int Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(EMPTY_STACK_EXC_MSG);
            }

            int lastItem = this.Items[this.Count - 1];

            return lastItem;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.Items[i]);
            }
        }

        private void Resize()
        {
            int[] copy = new int[this.Items.Length * 2];

            for (int i = 0; i < this.Items.Length; i++)
            {
                copy[i] = this.Items[i];
            }

            this.Items = copy;
        }

        
    }
}
