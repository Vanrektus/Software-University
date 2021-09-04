using System;
using System.Collections.Generic;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                string[] currentStudent = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (currentStudent[0] == "end")
                {
                    break;
                }

                Student student = new Student();

                student.FirstName = currentStudent[0];
                student.LastName = currentStudent[1];
                student.Age = int.Parse(currentStudent[2]);
                student.Hometown = currentStudent[3];

                students.Add(student);
            }

            string city = Console.ReadLine();

            foreach (Student currentStudent in students)
            {
                if (city == currentStudent.Hometown)
                {
                    Console.WriteLine($"{currentStudent.FirstName} {currentStudent.LastName} is {currentStudent.Age} years old.");
                }
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }
    }
}
