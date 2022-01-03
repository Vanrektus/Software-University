using System;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int numberOfDissatisfiedGrades = int.Parse(input);

            input = Console.ReadLine();

            int currentPoorGrades = 0;
            double averageScore = 0.0;
            int totalGrades = 0;
            string lastProblem = "";

            while (input != "Enough")
            {
                int grade = int.Parse(Console.ReadLine());
                totalGrades++;
                averageScore += grade;
                lastProblem = input;
                if (grade <= 4)
                {
                    currentPoorGrades++;
                }
                if (currentPoorGrades >= numberOfDissatisfiedGrades)
                {
                    break;
                }
                input = Console.ReadLine();
            }
            if (currentPoorGrades >= numberOfDissatisfiedGrades)
            {
                Console.WriteLine($"You need a break, {currentPoorGrades} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {averageScore / totalGrades:f2}");
                Console.WriteLine($"Number of problems: {totalGrades}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
