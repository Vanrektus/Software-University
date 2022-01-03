using System;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string result = Grades(number);

            Console.WriteLine(result);
        }

        static string Grades(double grade)
        {
            string gradeInWords = "";

            if (grade >= 2.00 && grade < 3.00)
            {
                gradeInWords = "Fail";
            }
            else if (grade >= 3.00 && grade < 3.50)
            {
                gradeInWords = "Poor";
            }
            else if (grade >= 3.50 && grade < 4.50)
            {
                gradeInWords = "Good";
            }
            else if (grade >= 4.50 && grade < 5.50)
            {
                gradeInWords = "Very good";
            }
            else if (grade >= 5.50 && grade <= 6.00)
            {
                gradeInWords = "Excellent";
            }

            return gradeInWords;
        }
    }
}
