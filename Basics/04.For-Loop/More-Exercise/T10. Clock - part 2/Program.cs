using System;

namespace T10._Clock___part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int h = 0; h < 24; h++)
            {
                for (int m = 0; m < 60; m++)
                {
                    for (int s = 0; s < 60; s++)
                    {
                        Console.WriteLine($"{h} : {m} : {s}");
                    }
                }
            }
        }
    }
}
