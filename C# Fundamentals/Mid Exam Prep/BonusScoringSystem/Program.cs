using System;

namespace BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            byte numberOfStudents = byte.Parse(Console.ReadLine());
            byte numberOfLectures = byte.Parse(Console.ReadLine());
            byte initialBonus = byte.Parse(Console.ReadLine());

            double bestStudent = 0;
            int bestStudentAttendances = 0;

            for (int i = 0; i < numberOfStudents; i++)
            {
                int studentAttendances = int.Parse(Console.ReadLine());

                double totalBonus = studentAttendances / (double)numberOfLectures * (5 + initialBonus);

                if (totalBonus > bestStudent)
                {
                    bestStudent = totalBonus;
                    bestStudentAttendances = studentAttendances;
                }
            }

            Console.WriteLine($"Max Bonus: {(int)Math.Ceiling(bestStudent)}.");
            Console.WriteLine($"The student has attended {bestStudentAttendances} lectures.");
        }
    }
}
