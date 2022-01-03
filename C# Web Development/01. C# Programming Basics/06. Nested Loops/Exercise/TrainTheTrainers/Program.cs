using System;

namespace TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfJudges = int.Parse(Console.ReadLine());
            string nameOfPresentation = Console.ReadLine();

            double totalSumOfGrades = 0.0;
            int totalNumOfJudges = 0;

            while (nameOfPresentation != "Finish")
            {
                double sumOfGrades = 0.0;
                for (int i = 1; i <= numberOfJudges; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    sumOfGrades += grade;
                    totalNumOfJudges++;
                    totalSumOfGrades += grade;
                }
                Console.WriteLine($"{nameOfPresentation} - {sumOfGrades / numberOfJudges:f2}.");

                nameOfPresentation = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {totalSumOfGrades / totalNumOfJudges:f2}.");
        }
    }
}
