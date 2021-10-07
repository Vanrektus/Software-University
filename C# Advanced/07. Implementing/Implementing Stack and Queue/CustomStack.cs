using System;

namespace CustomDataStructures
{
    class CustomStack<T>
    {
        private const int INITIAL_CAPACITY = 4;

        private const string EMPTY_STACK_EXC_MSG = "Stack is empy!";

        public T[] Items { get; private set; }

        public int Count { get; private set; }

        public CustomStack()
        {
            this.Items = new T[INITIAL_CAPACITY]; 
        }

        public void Push(T item)
        {
            if (this.Count == this.Items.Length)
            {
                this.Resize();
            }

            this.Items[this.Count] = item;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(EMPTY_STACK_EXC_MSG);
            }

            T poppedItem = this.Items[this.Count - 1];
            this.Items[this.Count - 1] = default;
            this.Count--;

            return poppedItem;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(EMPTY_STACK_EXC_MSG);
            }

            T lastItem = this.Items[this.Count - 1];

            return lastItem;
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.Items[i]);
            }
        }

        private void Resize()
        {
            T[] copy = new T[this.Items.Length * 2];

            for (int i = 0; i < this.Items.Length; i++)
            {
                copy[i] = this.Items[i];
            }

            this.Items = copy;
        }
    }
}
