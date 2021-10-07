using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class Lake<T> : IEnumerable<T>
    {
        //---------------------------Fields---------------------------
        private readonly T[] stones;

        //---------------------------Constructors---------------------------
        public Lake(T[] stones)
        {
            this.stones = stones;
        }

        //---------------------------Methods---------------------------
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < stones.Length; i += 2)
            {
                yield return stones[i];
            }

            int reversedOrderIndex = stones.Length % 2 == 0 ? stones.Length - 1 : stones.Length - 2;

            for (int i = reversedOrderIndex; i > 0; i -= 2)
            {
                yield return stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
