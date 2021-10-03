using System;
using System.Text;

namespace CustomDataStructures
{
    public class CustomList
    {
        private const int INITIAL_CAPACITY = 2;

        public int[] Items { get; private set; }

        public CustomList()
        {
            this.Items = new int[INITIAL_CAPACITY];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (!this.IsValidIndex(index))
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.Items[index];
            }
            set
            {
                if (!this.IsValidIndex(index))
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.Items[index] = value;
            }
        }

        public void Add(int item)
        {
            if (this.Count == this.Items.Length)
            {
                this.Resize();
            }

            this.Items[this.Count] = item;
            this.Count++;
        }

        public int RemoveAt(int index)
        {
            if (!this.IsValidIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            int removedItem = this.Items[index];
            this.Items[index] = default;
            this.ShiftToLeft(index);

            this.Count--;

            if (this.Count <= this.Items.Length / 4)
            {
                this.Shrink();
            }

            return removedItem;
        }

        public void Insert(int index, int item)
        {
            if (!this.IsValidIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.Count == this.Items.Length)
            {
                this.Resize();
            }

            this.ShiftToRight(index);
            this.Items[index] = item;
            this.Count++;
        }

        public bool Contains(int searchedElement)
        {
            for (int i = 0; i < this.Count; i++)
            {
                int currentElement = this.Items[i];

                if (currentElement == searchedElement)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (!this.IsValidIndex(firstIndex) || !this.IsValidIndex(secondIndex))
            {
                throw new ArgumentOutOfRangeException();
            }

            //Additional variable
            //int elementAtFirstIndex = this.Items[firstIndex];
            //this.Items[firstIndex] = this.Items[secondIndex];
            //this.Items[secondIndex] = elementAtFirstIndex;

            //Bitwise(faster than additional variable)(saves memory)
            //XOR
            //x = x ^ y;
            //y = x ^ y;
            //x = x ^ y;
            // 1 -> 0001
            // 2 -> 0010
            // x = 0011 -> 3
            // y = 0001
            // x = 0010
            this.Items[firstIndex] = this.Items[firstIndex] ^ this.Items[secondIndex];
            this.Items[secondIndex] = this.Items[firstIndex] ^ this.Items[secondIndex];
            this.Items[firstIndex] = this.Items[firstIndex] ^ this.Items[secondIndex];
        }

        private void Resize()
        {
            int[] copy = new int[this.Items.Length * 2];

            for (int i = 0; i < this.Items.Length; i++)
            {
                copy[i] = this.Items[i];
            }

            Items = copy;
        }

        private void Shrink()
        {
            int[] copy = new int[this.Items.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.Items[i];
            }

            Items = copy;
        }

        private void ShiftToLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.Items[i] = this.Items[i + 1];
            }
        }

        private void ShiftToRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.Items[i] = this.Items[i - 1];
            }
        }

        private bool IsValidIndex(int index)
            => index < this.Count;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                if (i == this.Count - 1)
                {
                    sb.Append($"{this.Items[i]}");
                }
                else
                {
                    sb.Append($"{this.Items[i]}, ");
                }
            }

            return sb.ToString().TrimEnd();
        }
    } 
}
