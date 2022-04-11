using System;

namespace T03._Film_Premiere
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            string package = Console.ReadLine();
            int numberOfTickets = int.Parse(Console.ReadLine());
            double pricePerTicket = 0;

            if (movie == "John Wick")
            {
                switch (package)
                {
                    case "Drink":
                        pricePerTicket = 12;
                        break;
                    case "Popcorn":
                        pricePerTicket = 15;
                        break;
                    case "Menu":
                        pricePerTicket = 19;
                        break;
                }
            }
            else if (movie == "Star Wars")
            {
                switch (package)
                {
                    case "Drink":
                        pricePerTicket = 18;
                        break;
                    case "Popcorn":
                        pricePerTicket = 25;
                        break;
                    case "Menu":
                        pricePerTicket = 30;
                        break;
                }
            }
            else if (movie == "Jumanji")
            {
                switch (package)
                {
                    case "Drink":
                        pricePerTicket = 9;
                        break;
                    case "Popcorn":
                        pricePerTicket = 11;
                        break;
                    case "Menu":
                        pricePerTicket = 14;
                        break;
                }
            }
            double total = pricePerTicket * numberOfTickets;
            if (movie == "Star Wars" && numberOfTickets >= 4)
            {
                total *= 0.70;
            }
            else if (movie == "Jumanji" && numberOfTickets == 2)
            {
                total *= 0.85;
            }

            Console.WriteLine($"Your bill is {total:f2} leva.");

        }
    }
}
