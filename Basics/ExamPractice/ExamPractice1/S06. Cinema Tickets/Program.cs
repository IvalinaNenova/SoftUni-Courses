using System;

namespace S06._Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            int student = 0;
            int standard = 0;
            int kid = 0;
            while (movie != "Finish")
            {
                int Seats = int.Parse(Console.ReadLine());
                int numberOfTickets = 0;
                while (Seats > numberOfTickets)
                {

                    string typeOfTicket = Console.ReadLine();
                    if (typeOfTicket == "End")
                    {
                        Console.WriteLine($"{movie} - {1.0 * numberOfTickets / Seats*100:f2}% full.");
                        break;
                    }
                    numberOfTickets++;



                    if (typeOfTicket == "student")
                    {
                        student++;
                    }
                    else if (typeOfTicket == "standard")
                    {
                        standard++;
                    }
                    else if (typeOfTicket == "kid")
                    {
                        kid++;
                    }
                    if (Seats <= numberOfTickets)
                    {
                        Console.WriteLine($"{movie} - 100.00% full.");
                        break;
                    }
                }
                movie = Console.ReadLine();
            }
            int totalTickets = student + standard + kid;
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{1.0 * student / totalTickets*100:f2}% student tickets.");
            Console.WriteLine($"{1.0 * standard / totalTickets*100:f2}% standard tickets.");
            Console.WriteLine($"{1.0 * kid / totalTickets*100:f2}% kids tickets.");
        }
    }
}
