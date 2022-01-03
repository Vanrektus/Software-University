using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentList studentList = new StudentList();

            int n = int.Parse(Console.ReadLine());

            NewStudentList(studentList, n);

            PrintStudents(studentList);
        }

        static void NewStudentList(StudentList studentList, int n)
        {
            for (int i = 0; i < n; i++)
            {
                string[] newStudentList = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                studentList.Students.Add(new Student
                {
                    FirstName = newStudentList[0],
                    LastName = newStudentList[1],
                    Grade = double.Parse(newStudentList[2])
                });
            }
        }

        static void PrintStudents(StudentList studentList)
        {
            foreach (Student student in studentList.Students.OrderByDescending(student => student.Grade))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
    }

    class StudentList
    {
        public List<Student> Students { get; set; }

        public StudentList()
        {
            Students = new List<Student>();
        }
    }
}
