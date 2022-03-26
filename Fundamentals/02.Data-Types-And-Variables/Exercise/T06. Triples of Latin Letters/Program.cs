using System;

namespace T06._Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (char i = 'a'; i < 'a' + n; i++)
            {
                for (char j = 'a'; j < 'a' + n; j++)
                {
                    for (char k = 'a'; k < 'a' + n; k++)
                    {
                        Console.WriteLine($"{i}{j}{k}");
                    }
                }
            }
        }
    }
}
