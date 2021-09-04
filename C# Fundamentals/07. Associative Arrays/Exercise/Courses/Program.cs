using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "end")
                {
                    break;
                }

                if (!courses.ContainsKey(input[0]))
                {
                    courses.Add(input[0], new List<string>() { input[1] });
                }
                else
                {
                    courses[input[0]].Add(input[1]);
                }

                courses[input[0]].Sort();
            }

            foreach (var course in courses.OrderByDescending(x => x.Value.Count))//.ThenBy(x => x.Value))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
