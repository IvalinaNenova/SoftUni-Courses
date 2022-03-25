using System;

namespace T06._Wedding_Seats
{
    class Program
    {
        static void Main(string[] args)
        {
            char lastSection = char.Parse(Console.ReadLine());
            int rowsInFirstSection = int.Parse(Console.ReadLine());
            int seatsInOddRow = int.Parse(Console.ReadLine());
            int counter = 0;
            for (char section = 'A'; section <= lastSection; section++)
            {
                rowsInFirstSection += 1;
                for (int rows = 1; rows < rowsInFirstSection; rows++)
                {
                    if (rows % 2 == 1)
                    {
                        for (char numberOfSeats = 'a'; numberOfSeats < 'a'+ seatsInOddRow; numberOfSeats++)
                        {
                            Console.WriteLine($"{section}{rows}{numberOfSeats}");
                            counter++;
                        }
                    }
                    else
                    {
                        for (char numberOfSeats = 'a'; numberOfSeats < 'a'+seatsInOddRow+2; numberOfSeats++)
                        {
                            Console.WriteLine($"{section}{rows}{numberOfSeats}");
                            counter++;
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
