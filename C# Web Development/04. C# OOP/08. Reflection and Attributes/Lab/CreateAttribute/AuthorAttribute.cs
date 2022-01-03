using System;

namespace AuthorProblem
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorAttribute : Attribute
    {
        //---------------------------Properties---------------------------
        public string Name { get; set; }

        //---------------------------Constructors---------------------------
        public AuthorAttribute(string name)
        {
            this.Name = name;
        }
    }
}
