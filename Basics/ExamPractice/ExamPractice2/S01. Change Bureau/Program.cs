using System;

namespace S01._Change_Bureau
{
    class Program
    {
        static void Main(string[] args)
        {
            //            •	1 биткойн = 1168 лева.
            //•	1 китайски юан = 0.15 долара.
            //•	1 долар = 1.76 лева.
            //•	1 евро = 1.95 лева.
            double bitcoin = double.Parse(Console.ReadLine());
            double yuan = double.Parse(Console.ReadLine());
            double commision = double.Parse(Console.ReadLine());

            double dollars = yuan * 0.15;
            double leva = dollars * 1.76 + bitcoin * 1168;
            double euro = (leva / 1.95) * (1 - (commision / 100));

            Console.WriteLine($"{euro:f2}");
            //•	На първия ред – броят биткойни. Цяло число в интервала[0…20]
            //•	На втория ред – броят китайски юана.Реално число в интервала[0.00… 50 000.00]
            //•	На третия ред – комисионната.Реално число в интервала[0.00... 5.00]

        }
    }
}
