using System;

namespace MovieRatings
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfMovies = int.Parse(Console.ReadLine());

            double minRating = double.MaxValue;
            string minRatingMovie = "";
            double maxRating = double.MinValue;
            string maxRatingMovie = "";
            double averageRating = 0;

            for (int i = 1; i <= numOfMovies; i++)
            {
                string nameOfMovie = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());

                averageRating += rating;

                if (rating > maxRating)
                {
                    maxRating = rating;
                    maxRatingMovie = nameOfMovie;
                }
                else if (rating < minRating)
                {
                    minRating = rating;
                    minRatingMovie = nameOfMovie;
                }
            }
            Console.WriteLine($"{maxRatingMovie} is with highest rating: {maxRating:f1}");
            Console.WriteLine($"{minRatingMovie} is with lowest rating: {minRating:f1}");
            Console.WriteLine($"Average rating: {averageRating /numOfMovies:f1}");
        }
    }
}
