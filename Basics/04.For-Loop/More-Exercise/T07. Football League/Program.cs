using System;

namespace T07._Football_League
{
    class Program
    {
        static void Main(string[] args)
        {
            int StadiumCapacity = int.Parse(Console.ReadLine());
            int fans = int.Parse(Console.ReadLine());
            int A = 0;
            int B = 0;
            int V = 0;
            int G = 0;

            for (int i = 0; i <fans ; i++)
            {
               string sector = Console.ReadLine();
                if (sector == "A")
                {
                    A++;
                }
                else if (sector=="B")
                {
                    B++;
                }
                else if (sector=="V")
                {
                    V++;
                }
                else if (sector == "G")
                {
                    G++;
                }


            }
            double percentInA = 1.0*A / fans * 100;
            double percentInB = 1.0 * B / fans * 100;
            double percentInV = 1.0 * V / fans * 100;
            double percentInG = 1.0 * G / fans * 100;
            double percentTotalFans = 1.0 * fans / StadiumCapacity*100;

            Console.WriteLine($"{percentInA:f2}%");
            Console.WriteLine($"{percentInB:f2}%");
            Console.WriteLine($"{percentInV:f2}%");
            Console.WriteLine($"{percentInG:f2}%");
            Console.WriteLine($"{percentTotalFans:f2}%");
        }
    }
}
