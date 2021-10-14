using System;

namespace ExcellentResult
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            bool gradeIsExcellent = grade >= 5.50;
            if (gradeIsExcellent)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
