using System;

namespace CustomDI.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Constructor, AllowMultiple = true)]
    public class InjectAttribute : Attribute
    {

    }
}
