using System;

namespace T09.FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double volume = lenght * width * height;
            double littres = volume * 0.001;
            double littresNeeded = littres - littres * (percent / 100);
            Console.WriteLine(littresNeeded );
        }
    }
}
