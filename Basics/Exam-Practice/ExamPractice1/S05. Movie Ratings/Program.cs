using System;

namespace S05._Movie_Ratings
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfMovies = int.Parse(Console.ReadLine());
            double minRating = double.MaxValue;
            double maxRating = double.MinValue;
            double sumOfRatings = 0;
            string lowestRatedMovie = "";
            string highestRatedMovie = "";
            for (int i = 0; i < numberOfMovies; i++)
            {
                string movie = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());
                sumOfRatings += rating;

                if (rating>maxRating)
                {
                    maxRating = rating;
                    highestRatedMovie = movie;
                }
                if (rating<minRating)
                {
                    minRating = rating;
                    lowestRatedMovie = movie;
                }

            }
            double averageRating = 1.0 * sumOfRatings / numberOfMovies;
            Console.WriteLine($"{highestRatedMovie} is with highest rating: {maxRating:f1}");
            Console.WriteLine($"{lowestRatedMovie} is with lowest rating: {minRating:f1}");
            Console.WriteLine($"Average rating: {averageRating:f1}");

            

        }
    }
}
