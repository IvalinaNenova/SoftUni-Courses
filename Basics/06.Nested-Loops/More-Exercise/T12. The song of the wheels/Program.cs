using System;

namespace T12._The_song_of_the_wheels
{
    class Program
    {
        static void Main(string[] args)
        {
            int controlNum = int.Parse(Console.ReadLine());
            string password = "";
            int counter = 0;
            bool isFound = false;

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            if (a < b && c > d && a * b + c * d == controlNum)
                            {
                                Console.Write($"{a}{b}{c}{d} ");
                                counter++;
                                if (counter == 4)
                                {
                                    password = ($"{a}{b}{c}{d}");
                                    isFound = true;
                                }
                            }
                        }
                    }
                }
            }
            if (isFound)
            {
                Console.WriteLine();
                Console.WriteLine($"Password: {password}");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No!");
            }
        }
    }
}
