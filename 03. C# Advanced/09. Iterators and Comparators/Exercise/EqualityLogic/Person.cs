using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        //---------------------------Properties---------------------------
        public string Name { get; private set; }

        public int Age { get; private set; }

        //---------------------------Constructors---------------------------
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        //---------------------------Methods---------------------------
        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }

            return result;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Age.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Person other = obj as Person;

            if (other == null)
            {
                return false;
            }

            return this.Age == other.Age && this.Name == other.Name;
        }
    }
}
