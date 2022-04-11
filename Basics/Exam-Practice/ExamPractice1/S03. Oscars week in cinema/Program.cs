using System;

namespace S03._Oscars_week_in_cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            string typeOfTicket = Console.ReadLine();
            int numberOfTickets = int.Parse(Console.ReadLine());
            double price = 0;

            //Филм               normal         luxury    ultra luxury
            //A Star Is Born       7.50 лв.    10.50 лв.   13.50 лв.
            //Bohemian Rhapsody    7.35 лв.    9.45 лв.    12.75 лв.
            //Green Book           8.15 лв.    10.25 лв.   13.25 лв.
            //The Favourite        8.75 лв.    11.55 лв.   13.95 лв.
            if (typeOfTicket == "normal")
            {
                if (movie == "A Star Is Born")
                {
                    price = 7.50;
                }
                else if (movie == "Bohemian Rhapsody")
                {
                    price = 7.35;
                }
                else if (movie == "Green Book")
                {
                    price = 8.15;
                }
                else if (movie == "The Favourite")
                {
                    price = 8.75;
                }
            }
            else if (typeOfTicket == "luxury")
            {
                if (movie == "A Star Is Born")
                {
                    price = 10.50;
                }
                else if (movie == "Bohemian Rhapsody")
                {
                    price = 9.45;
                }
                else if (movie == "Green Book")
                {
                    price = 10.25;
                }
                else if (movie == "The Favourite")
                {
                    price = 11.55;
                }
            }
            else if (typeOfTicket == "ultra luxury")
            {
                if (movie == "A Star Is Born")
                {
                    price = 13.50;
                }
                else if (movie == "Bohemian Rhapsody")
                {
                    price = 12.75;
                }
                else if (movie == "Green Book")
                {
                    price = 13.25;
                }
                else if (movie == "The Favourite")
                {
                    price = 13.95;
                }
            }
            double total = price * numberOfTickets;

            Console.WriteLine($"{movie} -> {total:f2} lv.");


        }
    }
}
