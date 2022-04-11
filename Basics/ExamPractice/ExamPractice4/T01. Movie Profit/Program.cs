using System;

namespace T01._Movie_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            int numberOfTickets = int.Parse(Console.ReadLine());
            double pricePerTicket = double.Parse(Console.ReadLine());
            int percentForTheatre = int.Parse(Console.ReadLine());

            double profitFromTickets = numberOfTickets * pricePerTicket * days;
            double studioProfit = profitFromTickets * (1-((double)percentForTheatre / 100));

            Console.WriteLine($"The profit from the movie {movie} is {studioProfit:f2} lv.");
        }
    }
}
