using System;

namespace Person
{
    public class Person
    {
        //---------------------------Fields---------------------------
        private string name;
        private int age;

        //---------------------------Propperties---------------------------
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Name's length shouldn't be less than 3 symbols!");
                }

                this.name = value;
            }
        }

        public virtual int Age
        {
            get
            {
                return this.age;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age cannot be negative");
                }

                this.age = value;
            }
        }

        //---------------------------Constructors---------------------------
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        //---------------------------Methods---------------------------
        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
