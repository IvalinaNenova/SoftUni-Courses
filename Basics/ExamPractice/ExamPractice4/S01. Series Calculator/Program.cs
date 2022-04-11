using System;

namespace S06._Favorite_Movie
{
    class Program
    {
        static void Main(string[] args)
        {
            string seriesName = Console.ReadLine();
            int seasons = int.Parse(Console.ReadLine());
            int episodes = int.Parse(Console.ReadLine());
            double minPerEpisode = double.Parse(Console.ReadLine());

            double total = minPerEpisode * 1.2 * episodes * seasons + seasons * 10;

            Console.WriteLine($"Total time needed to watch the {seriesName} series is {total} minutes.");
        }
    }
}
