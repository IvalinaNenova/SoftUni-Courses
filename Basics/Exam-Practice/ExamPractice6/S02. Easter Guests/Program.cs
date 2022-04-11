using System;

namespace S02._Easter_Guests
{
    class Program
    {
        static void Main(string[] args)
        {
            int guests = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double easterBread = Math.Ceiling((double)guests / 3);
            int eggs = guests * 2;
            double total = easterBread * 4 + eggs * 0.45;

            double difference = Math.Abs(total - budget);
            if (total <= budget)
            {
                Console.WriteLine($"Lyubo bought {easterBread} Easter bread and {eggs} eggs.");
                Console.WriteLine($"He has {difference:f2} lv. left.");
            }
            else
            {
                Console.WriteLine("Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {difference:f2} lv. more.");
            }
        }
    }
}
