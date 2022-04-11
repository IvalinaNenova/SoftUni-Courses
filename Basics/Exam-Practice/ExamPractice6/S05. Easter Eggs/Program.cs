using System;

namespace S05._Easter_Eggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfeggs = int.Parse(Console.ReadLine());
            int red = 0;
            int orange = 0;
            int blue = 0;
            int green = 0;
            int maxEggs = int.MinValue;
            string maxColor = "";

            for (int i = 0; i < numberOfeggs; i++)
            {
                string color = Console.ReadLine();

                if (color == "red")
                {
                    red++;
                    if (red>maxEggs)
                    {
                        maxEggs = red;
                        maxColor = color;

                    }
                }
                else if (color == "orange")
                {
                    orange++;
                    if (orange > maxEggs)
                    {
                        maxEggs = orange;
                        maxColor = color;

                    }
                }
                else if (color == "green")
                {
                    green++;
                    if (green > maxEggs)
                    {
                        maxEggs = green;
                        maxColor = color;

                    }
                }
                else if (color == "blue")
                {
                    blue++;
                    if (blue > maxEggs)
                    {
                        maxEggs = blue;
                        maxColor = color;

                    }
                }
            }

            Console.WriteLine($"Red eggs: {red}");
            Console.WriteLine($"Orange eggs: {orange}");
            Console.WriteLine($"Blue eggs: {blue}");
            Console.WriteLine($"Green eggs: {green}");
            Console.WriteLine($"Max eggs: {maxEggs} -> {maxColor}");
        }
    }
}
