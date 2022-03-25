using System;

namespace T05.Number100to200
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            if (num<100)
            {
                Console.WriteLine("Less than 100");

            }
            if (num>200)
            {
                Console.WriteLine("Greater than 200");
            }
            if (num >=100 && num<=200)
            {
                Console.WriteLine("Between 100 and 200");
            }
        }
    }
}
