using System;

namespace T02._Easter_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGuests = int.Parse(Console.ReadLine());
            double pricePerGuest = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double priceOfCake = budget * 0.1;

            if (numberOfGuests>=10 && numberOfGuests<=15)
            {
                pricePerGuest *= 0.85;
            }
            else if (numberOfGuests >15 && numberOfGuests <= 20)
            {
                pricePerGuest *= 0.8;
            }
            else if (numberOfGuests >20)
            {
                pricePerGuest *= 0.75;
            }

            double total = numberOfGuests * pricePerGuest + priceOfCake;
            double difference = Math.Abs(total - budget);

            if (total<=budget)
            {
                Console.WriteLine($"It is party time! {difference:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"No party! {difference:f2} leva needed.");
            }
        }
    }
}
