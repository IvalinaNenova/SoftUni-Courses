using System;

namespace T01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintMinNumber();
        }

        private static void PrintMinNumber()
        {
            int count = 0;
            int minNumber = int.MaxValue;

            for (int i = 0; i < 3; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < minNumber)
                {
                    minNumber = number;
                }
                count++;

            }

            Console.WriteLine(minNumber);
        }
    }
}
