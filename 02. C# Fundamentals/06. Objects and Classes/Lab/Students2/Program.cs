using System;
using System.Collections.Generic;

namespace Students2
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

                if (IsSameStudent(students, currentStudent[0], currentStudent[1], int.Parse(currentStudent[2])))
                {
                    
                }
                else
                {
                    Student student = new Student();

                    student.FirstName = currentStudent[0];
                    student.LastName = currentStudent[1];
                    student.Age = int.Parse(currentStudent[2]);
                    student.Hometown = currentStudent[3];

                    students.Add(student);
                }
            }

            string city = Console.ReadLine();

            PrintStudents(students, city);
        }

        static bool IsSameStudent(List<Student> students, string firstName, string lastName, int age)
        {

            foreach (Student sameStudent in students)
            {
                if (firstName == sameStudent.FirstName && lastName == sameStudent.LastName)
                {
                    sameStudent.Age = age;
                    return true;
                }
            }

            return false;
        }

        static void PrintStudents(List<Student> students, string city)
        {
            foreach (Student student in students)
            {
                if (city == student.Hometown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
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
