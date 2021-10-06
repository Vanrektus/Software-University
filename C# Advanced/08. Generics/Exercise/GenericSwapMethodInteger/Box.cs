using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodInteger
{
    public class Box<T>
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

        public void Swap(int firstIndex, int secondIndex)
        {
            T firstValue = this.List[firstIndex];
            this.List[firstIndex] = this.List[secondIndex];
            this.List[secondIndex] = firstValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var currentValue in this.List)
            {
                sb.AppendLine($"{currentValue.GetType()}: {currentValue}");
            }

            return sb
                .ToString()
                .TrimEnd();
        }
    }
}
