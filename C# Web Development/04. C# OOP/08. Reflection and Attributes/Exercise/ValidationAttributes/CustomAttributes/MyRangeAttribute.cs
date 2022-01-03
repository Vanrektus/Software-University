using System;

namespace ValidationAttributes.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class MyRangeAttribute : MyValidationAttribute
    {
        //---------------------------Fields---------------------------
        private readonly int minValue;
        private readonly int maxValue;

        //---------------------------Constructors---------------------------
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        //---------------------------Methods---------------------------
        public override bool IsValid(object obj)
        {
            if (!(obj is int))
            {
                throw new ArgumentException("Invalid");
            }

            int valueAsInt = (int)obj;
            bool isInRange = valueAsInt >= this.minValue && valueAsInt <= this.maxValue;

            if (!isInRange)
            {
                return false;
            }

            return true;
        }
    }
}
