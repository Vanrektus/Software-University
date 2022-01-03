using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>() { grade });
                }
                else
                {
                    students[name].Add(grade);
                }
            }

            Dictionary<string, double> studentsSorted = new Dictionary<string, double>();

            foreach (var item in students)
            {
                double currentStudentGrade = 0.0;

                foreach (var grades in item.Value)
                {
                    currentStudentGrade += grades;
                }

                currentStudentGrade /= item.Value.Count;

                studentsSorted.Add(item.Key, currentStudentGrade);
            }

            foreach (var student in studentsSorted.Where(x => x.Value >= 4.50).OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{student.Key} -> {student.Value:f2}");

            }
        }
    }
}
