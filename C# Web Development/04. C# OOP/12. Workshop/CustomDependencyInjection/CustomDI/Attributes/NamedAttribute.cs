using System;

namespace CustomDI.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
    public class NamedAttribute : Attribute
    {
        //---------------------------Properties---------------------------
        public string Name { get; }

        //---------------------------Constructors---------------------------
        public NamedAttribute(string name)
        {
            Name = name;
        }
    }
}
