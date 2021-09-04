using System;

namespace Scholarship2
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageSuccess = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            if (income < minSalary)
            {
                if (averageSuccess >= 4.50)
                {
                    double socialScholarship = minSalary * 0.35;
                    if (averageSuccess >= 5.50)
                    {
                        double excellentScholarship = averageSuccess * 25;
                        if (socialScholarship > excellentScholarship)
                        {
                            Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
                        }
                        else if (socialScholarship <= excellentScholarship)
                        {
                            Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excellentScholarship)} BGN");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
                    }
                }
                else
                {
                    Console.WriteLine("You cannot get a scholarship!");
                }
            }
            else if (averageSuccess >= 5.50)
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(averageSuccess * 25)} BGN");
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
