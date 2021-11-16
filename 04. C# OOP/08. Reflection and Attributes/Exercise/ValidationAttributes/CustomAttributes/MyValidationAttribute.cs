using System;

namespace ValidationAttributes.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public abstract class MyValidationAttribute : Attribute
    {
        //---------------------------Methods---------------------------
        public abstract bool IsValid(object obj);
    }
}
