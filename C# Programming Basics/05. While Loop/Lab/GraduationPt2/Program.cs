using System;

namespace GraduationPt2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double grade = double.Parse(Console.ReadLine());

            double averageGrade = 0.0;
            double currentGrade = 1;

            while (grade >= 4.00)
            {
                averageGrade += grade;
                if (currentGrade >= 12)
                {
                    break;
                }
                currentGrade++;
                grade = double.Parse(Console.ReadLine());
            }
            if (currentGrade < 12)
            {
                Console.WriteLine($"{name} has been excluded at {currentGrade} grade");
            }
            else
            {
                Console.WriteLine($"{name} graduated. Average grade: {averageGrade / currentGrade:f2}");
            }
        }
    }
}
