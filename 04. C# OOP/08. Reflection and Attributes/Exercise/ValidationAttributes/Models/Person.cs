using ValidationAttributes.CustomAttributes;

namespace ValidationAttributes.Models
{
    public class Person
    {
        //---------------------------Properties---------------------------
        [MyRequired]
        public string FullName { get; set; }

        [MyRange(12, 90)]
        public int Age { get; set; }

        //---------------------------Constructors---------------------------
        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }
    }
}
