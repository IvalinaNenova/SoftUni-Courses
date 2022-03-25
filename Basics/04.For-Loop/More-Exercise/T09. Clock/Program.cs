using System;

namespace T09._Clock
{
    class Program
    {
        static void Main(string[] args)
        {
           

            for (int i = 0; i <= 23; i++)
            {
                for (int m = 0; m <60; m++)
                {
                    Console.WriteLine($"{i} : {m}");
                }
            }
        }
    }
}
