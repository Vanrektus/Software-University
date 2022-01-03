using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTabs = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());

            double leftSalary = salary;

            for (int i = 1; i <= numberOfTabs; i++)
            {
                string nameOfTab = Console.ReadLine();
                switch (nameOfTab)
                {
                    case "Facebook":
                        leftSalary -= 150;
                        break;
                    case "Instagram":
                        leftSalary -= 100;
                        break;
                    case "Reddit":
                        leftSalary -= 50;
                        break;
                }
            }
            if (leftSalary > 0)
            {
                Console.WriteLine(leftSalary);
            }
            else
            {
                Console.WriteLine("You have lost your salary.");
            }
        }
    }
}
