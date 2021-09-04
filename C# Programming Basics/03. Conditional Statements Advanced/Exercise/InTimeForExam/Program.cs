using System;

namespace InTimeForExam
{
    class Program
    {
        static void Main(string[] args)
        {
            double examHour = double.Parse(Console.ReadLine());
            double examMinute = double.Parse(Console.ReadLine());
            double arrivalHour = double.Parse(Console.ReadLine());
            double arrivalMinute = double.Parse(Console.ReadLine());

            examHour = examHour * 60;
            arrivalHour = arrivalHour * 60;

            double totalExamTime = examHour + examMinute;
            double totalArrivalTime = arrivalHour + arrivalMinute;

            if (totalArrivalTime < totalExamTime)
            {
                double ExamMinusArrival = totalExamTime - totalArrivalTime;
                if (ExamMinusArrival <= 30)
                {
                    Console.WriteLine("On time");
                    Console.WriteLine($"{ExamMinusArrival} minutes before the start");
                }
                else if (ExamMinusArrival > 30)
                {
                    if (ExamMinusArrival >= 60)
                    {
                        if ((ExamMinusArrival % 60) < 10)
                        {
                            Console.WriteLine("Early");
                            Console.WriteLine($"{Math.Floor(ExamMinusArrival / 60)}:0{ExamMinusArrival % 60} hours before the start");
                        }
                        else
                        {
                            Console.WriteLine("Early");
                            Console.WriteLine($"{Math.Floor(ExamMinusArrival / 60)}:{ExamMinusArrival % 60} hours before the start");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Early");
                        Console.WriteLine($"{ExamMinusArrival} minutes before the start");
                    }
                    
                }
            }
            else if (totalArrivalTime > totalExamTime)
            {
                double ArrivalMinusExam = totalArrivalTime - totalExamTime;
                if (ArrivalMinusExam >= 60)
                {
                    if ((ArrivalMinusExam % 60) < 10)
                    {
                        Console.WriteLine("Late");
                        Console.WriteLine($"{Math.Floor(ArrivalMinusExam / 60)}:0{ArrivalMinusExam % 60} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine("Late");
                        Console.WriteLine($"{Math.Floor(ArrivalMinusExam / 60)}:{ArrivalMinusExam % 60} hours after the start");
                    }
                }
                else
                {
                    Console.WriteLine("Late");
                    Console.WriteLine($"{ArrivalMinusExam} minutes after the start");
                }
            }
            else if (totalArrivalTime == totalExamTime)
            {
                Console.WriteLine("On time");
            }
        }
    }
}
