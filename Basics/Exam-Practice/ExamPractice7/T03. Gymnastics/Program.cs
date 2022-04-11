using System;

namespace T03._Gymnastics
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string category = Console.ReadLine();
            double difficulty = 0;
            double performance = 0;

            if (country== "Russia")
            {
                if (category == "ribbon")
                {
                    difficulty = 9.100;
                    performance = 9.400;
                }
                else if (category == "hoop")
                {
                    difficulty = 9.300;
                    performance = 9.800;
                }
                else if (category == "rope")
                {
                    difficulty = 9.600;
                    performance = 9.000;
                }
            }
            else if (country == "Bulgaria")
            {
                if (category == "ribbon")
                {
                    difficulty = 9.600;
                    performance = 9.400;
                }
                else if (category == "hoop")
                {
                    difficulty = 9.550;
                    performance = 9.750;
                }
                else if (category == "rope")
                {
                    difficulty = 9.500;
                    performance = 9.400;
                }
            }
            else if (country == "Italy")
            {
                if (category == "ribbon")
                {
                    difficulty = 9.200;
                    performance = 9.500;
                }
                else if (category == "hoop")
                {
                    difficulty = 9.450;
                    performance = 9.350;
                }
                else if (category == "rope")
                {
                    difficulty = 9.700;
                    performance = 9.150;
                }
            }

            Console.WriteLine($"The team of {country} get {difficulty+performance:f3} on {category}.");
            Console.WriteLine($"{100 - (difficulty+performance)/20*100:f2}%");
        }
    }
}
