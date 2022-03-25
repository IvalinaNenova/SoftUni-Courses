using System;

namespace T06._Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            int totalStudentTickets = 0;
            int totalStandardTickets = 0;
            int totalKidTickets = 0;

            while (movieName != "Finish")
            {
                int freeSeats = int.Parse(Console.ReadLine());
                int ticketsSold = 0;

                for (; ticketsSold < freeSeats; ticketsSold++)
                {
                    string typeOfTicket = Console.ReadLine();
                    
                    if (typeOfTicket == "End")
                    {
                        break;
                    }
                    else if (typeOfTicket == "student")
                    {
                        totalStudentTickets++;
                    }
                    else if (typeOfTicket == "standard")
                    {
                        totalStandardTickets++;
                    }
                    else if (typeOfTicket == "kid")
                    {
                        totalKidTickets++;
                    }

                }
                Console.WriteLine($"{movieName} - {(double)ticketsSold / freeSeats * 100:f2}% full.");
               

                movieName = Console.ReadLine();

            }
            int totalTickets = totalStudentTickets + totalStandardTickets + totalKidTickets;

            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{(double)totalStudentTickets / totalTickets * 100:f2}% student tickets.");
            Console.WriteLine($"{(double)totalStandardTickets / totalTickets * 100:f2}% standard tickets.");
            Console.WriteLine($"{(double)totalKidTickets / totalTickets * 100:f2}% kids tickets.");



        }
    }
}
