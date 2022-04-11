using System;

namespace T01._Agency_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            string companyName = Console.ReadLine();
            int adultTickets = int.Parse(Console.ReadLine());
            int kidTickets = int.Parse(Console.ReadLine());
            double adultTicketPrice = double.Parse(Console.ReadLine());
            double servicePrice = double.Parse(Console.ReadLine());

            double kidTicketPrice = adultTicketPrice * 0.3;
            double totalSales = adultTickets * (adultTicketPrice + servicePrice) + kidTickets * (kidTicketPrice + servicePrice);
            double profit = totalSales * 0.2;

            Console.WriteLine($"The profit of your agency from {companyName} tickets is {profit:F2} lv.");
        }
    }
}
