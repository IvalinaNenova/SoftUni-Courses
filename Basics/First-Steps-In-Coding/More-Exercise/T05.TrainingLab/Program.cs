using System;

namespace T05.TrainingLab
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            double freeWidth = width - 1;
            double desksInWidth = Math.Floor(freeWidth / 0.7);
            double desksInLenght = Math.Floor(lenght / 1.2);
            double totalDesks = desksInWidth * desksInLenght - 3;
            Console.WriteLine(totalDesks);


        }
    }
}
