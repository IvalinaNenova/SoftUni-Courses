using System;

namespace T01.PipesInPool
{
    class Program
    {
        static void Main(string[] args)
        {
            int volume = int.Parse(Console.ReadLine());
            double debit1 = double.Parse(Console.ReadLine());
            double debit2 = double.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());
            debit1 *=  hours;
            debit2 *= hours;
            double total = debit1 + debit2;
            double totalPercent = (total / volume) * 100;
            double pipe1Percent = (debit1 / total) * 100;
            double pipe2Percent = (debit2 / total) * 100;

            if (total<=volume )
            {
                Console.WriteLine($"The pool is {totalPercent:f2}% full. Pipe 1: {pipe1Percent:f2}%. Pipe 2: {pipe2Percent:f2}%.");

            }
            else if (total>volume)
            {
                Console.WriteLine($"For {hours} hours the pool overflows with {total-volume} liters.");
            }
        }
    }
}
