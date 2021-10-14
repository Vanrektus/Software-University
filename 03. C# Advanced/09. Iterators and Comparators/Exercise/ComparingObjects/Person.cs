using System;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        //---------------------------Properties---------------------------
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Town { get; private set; }

        //---------------------------Constructors---------------------------
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        //---------------------------Methods---------------------------
        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }

            if (result == 0)
            {
                result = this.Town.CompareTo(other.Town);
            }

            return result;
        }
    }
}
