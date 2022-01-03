using System;

namespace GenericScale
{
    public class EqualityScale<T> where T : IComparable
    {
        //---------------------------Fields---------------------------
        private readonly T left;

        private readonly T right;

        //---------------------------Constructors---------------------------
        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        //---------------------------Methods---------------------------
        public bool AreEqual()
        {
            return left.Equals(right);
        }
    }
}
