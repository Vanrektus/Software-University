using System;

namespace Person
{
    public class Child : Person
    {
        //---------------------------Constructors---------------------------
        public Child(string name, int age)
            : base(name, age)
        {

        }

        //---------------------------Methods---------------------------
        public override int Age
        {
            get
            {
                return base.Age;
            }

            protected set
            {
                if (value > 15)
                {
                    throw new ArgumentOutOfRangeException("Child age cannot be more than 15");
                }

                base.Age = value;
            }
        }
    }
}
