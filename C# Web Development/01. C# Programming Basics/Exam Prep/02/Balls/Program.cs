using System;

namespace Balls
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBalls = int.Parse(Console.ReadLine());
            

            int redBalls = 0;
            int orangeBalls = 0;
            int yellowBalls = 0;
            int whiteBalls = 0;
            double blackBalls = 0;
            int otherBalls = 0;
            double totalPoints = 0;

            for (int i = 1; i <= numberOfBalls; i++)
            {
                string colorOfBall = (Console.ReadLine());
                switch (colorOfBall)
                {
                    case "red":
                        redBalls++;
                        totalPoints += 5;
                        break;
                    case "orange":
                        orangeBalls++;
                        totalPoints += 10;
                        break;
                    case "yellow":
                        yellowBalls++;
                        totalPoints += 15;
                        break;
                    case "white":
                        whiteBalls++;
                        totalPoints += 20;
                        break;
                    case "black":
                        blackBalls++;
                        totalPoints = Math.Floor(totalPoints / 2);
                        break;
                    default:
                        otherBalls++;
                        break;
                }
            }

            Console.WriteLine($"Total points: {totalPoints}");
            Console.WriteLine($"Points from red balls: {redBalls}");
            Console.WriteLine($"Points from orange balls: {orangeBalls}");
            Console.WriteLine($"Points from yellow balls: {yellowBalls}");
            Console.WriteLine($"Points from white balls: {whiteBalls}");
            Console.WriteLine($"Other colors picked: {otherBalls}");
            Console.WriteLine($"Divides from black balls: {blackBalls}");
        }
    }
}
