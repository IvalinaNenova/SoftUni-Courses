using System;

namespace S01._Oscars_ceremony
{
    class Program
    {
        static void Main(string[] args)
        {
            int rent = int.Parse(Console.ReadLine());

            double oscars = rent * 0.7;
            double catering = oscars * 0.85;
            double sound = catering / 2;

            double total = rent + oscars + catering + sound;

            Console.WriteLine($"{total:f2}");
        }
    }
}
