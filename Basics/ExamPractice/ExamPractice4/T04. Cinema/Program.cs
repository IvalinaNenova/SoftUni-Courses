using System;

namespace T04._Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            double income = 0;
            int seatsTaken = 0;

            while (input!= "Movie time!")
            {
                int numberOfPeople = int.Parse(input);
                seatsTaken += numberOfPeople;
                if (seatsTaken>capacity)
                {
                    Console.WriteLine("The cinema is full.");
                    break;
                }
                if (numberOfPeople%3==0)
                {
                    income -= 5;
                }
                
                income += numberOfPeople * 5;


                input = Console.ReadLine();
            }
            if (input == "Movie time!")
            {
                Console.WriteLine($"There are {capacity-seatsTaken} seats left in the cinema.");
            }

            Console.WriteLine($"Cinema income - {income} lv.");
        }
    }
}
