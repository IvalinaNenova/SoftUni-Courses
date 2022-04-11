using System;

namespace S06._Favorite_Movie
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            int maxValue = int.MinValue;
            string favouriteMovie = "";
            int counter = 0;

            while (movieName != "STOP")
            {
                counter++;
                int movieValue = 0;
                for (int i = 0; i < movieName.Length; i++)
                {
                    char letter = movieName[i];
                    int num = Convert.ToInt32(letter);
                    int letterValue;

                    if (num >= 65 && num <= 90)
                    {
                        letterValue = num - movieName.Length;
                    }
                    else if (num >= 97 && num <= 122)
                    {
                        letterValue = num - movieName.Length * 2;
                    }
                    else
                    {
                        letterValue = num;
                    }
                    movieValue += letterValue;
                }
                if (movieValue > maxValue)
                {
                    maxValue = movieValue;
                    favouriteMovie = movieName;
                }

                if (counter == 7)
                {
                    Console.WriteLine("The limit is reached.");
                    break;
                }
                movieName = Console.ReadLine();
            }
            Console.WriteLine($"The best movie for you is {favouriteMovie} with {maxValue} ASCII sum.");
        }
    }
}
