using System;

namespace T09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberOfStudents = int.Parse(Console.ReadLine());
            double priceOfOneLightsaber = double.Parse(Console.ReadLine());
            double priceOfOneRobe = double.Parse(Console.ReadLine());
            double priceOfOneBelt = double.Parse(Console.ReadLine());

            double numberOfLightsabers = Math.Ceiling(numberOfStudents * 1.1);
            int freeBelts = numberOfStudents / 6;
            int numberOfBelts = numberOfStudents - freeBelts;

            double total = numberOfStudents * priceOfOneRobe + numberOfLightsabers * priceOfOneLightsaber + numberOfBelts * priceOfOneBelt;
            double difference = Math.Abs(budget - total);

            if (total<= budget)
            {
                Console.WriteLine($"The money is enough - it would cost {total:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {difference:f2}lv more.");
            }
        }
    }
}
