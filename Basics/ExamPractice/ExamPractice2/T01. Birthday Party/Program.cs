using System;

namespace T01._Birthday_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            double rent = double.Parse(Console.ReadLine());

            double cake = rent * 0.2;
            double drinks = cake * 0.55;
            double entertainment = rent / 3;

            double total = rent + cake + drinks + entertainment;

            Console.WriteLine(total);
        }
    }
}
