using System;

namespace FavoriteMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();

            int movieCounter = 0;
            double currentPoints = 0;
            double maxPoints = double.MinValue;
            string bestMovie = "";

            while (movieName != "STOP")
            {
                movieCounter++;

                if (movieCounter == 7)
                {
                    Console.WriteLine($"The limit is reached.");
                    break;
                }

                foreach (char currentChar in movieName)
                {
                    if (char.IsUpper(currentChar))
                    {
                        currentPoints += currentChar - movieName.Length;
                    }
                    else if (char.IsLower(currentChar))
                    {
                        currentPoints += currentChar - (movieName.Length * 2);
                    }
                    else
                    {
                        currentPoints += currentChar;
                    }
                }

                if (maxPoints < currentPoints)
                {
                    maxPoints = currentPoints;
                    bestMovie = movieName;
                }

                currentPoints = 0;
                movieName = Console.ReadLine();
            }

            Console.WriteLine($"The best movie for you is {bestMovie} with {maxPoints} ASCII sum.");
        }
    }
}
