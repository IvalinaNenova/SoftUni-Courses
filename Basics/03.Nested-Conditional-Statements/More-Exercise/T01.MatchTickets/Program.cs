using System;

namespace T01.MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            

            double budget = double.Parse(Console.ReadLine());
            string typeOfTicket = Console.ReadLine();
            int numberOfPeople = int.Parse(Console.ReadLine());

            const double VIPPrice = 499.99;
            const double normalPrice = 249.99;
           
            double moneyForTransport = 0;
            double moneyForTickets = 0;

            if (numberOfPeople <5)
            {
                moneyForTransport = budget * 0.75;
            }
            else if (numberOfPeople <10)
            {
                moneyForTransport = budget * 0.6;
            }
            else if (numberOfPeople <25)
            {
                moneyForTransport = budget * 0.5;
            }
            else if (numberOfPeople <50)
            {
                moneyForTransport = budget * 0.4;
            }
            else 
            {
                moneyForTransport = budget * 0.25;
            }

            
            if (typeOfTicket == "VIP")
            {
                moneyForTickets = numberOfPeople * VIPPrice;
                
            }
            else if (typeOfTicket == "Normal")
            {
                moneyForTickets = numberOfPeople * normalPrice;
            }
            double total = moneyForTransport + moneyForTickets;
            double difference = Math.Abs(budget - total);
            if (budget>total)
            {
                Console.WriteLine($"Yes! You have {difference:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
            }

        }
    }
}
