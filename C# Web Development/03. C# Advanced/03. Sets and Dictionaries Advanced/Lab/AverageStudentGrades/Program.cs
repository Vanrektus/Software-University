using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<decimal>() { grade });
                }
                else
                {
                    students[name].Add(grade);
                }
            }

            foreach (var currentStudent in students)
            {
                Console.WriteLine($"{currentStudent.Key} -> {string.Join(' ', currentStudent.Value.Select(x => x.ToString("F2")))} (avg: {currentStudent.Value.Average():f2})");
            }
        }
    }
}
