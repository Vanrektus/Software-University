using System;

namespace CustomDI.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
    public class NamedAttribute : Attribute
    {
        public string Name { get; }

        public NamedAttribute(string name)
        {
            Name = name;
        }
    }
}
