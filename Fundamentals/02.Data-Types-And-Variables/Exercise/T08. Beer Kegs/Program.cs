using System;

namespace T08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfKegs = int.Parse(Console.ReadLine());

            float biggestVolume = float.MinValue;
            string biggestModel = "";

            for (int keg = 1; keg <= numberOfKegs; keg++)
            {
                string kegModel = Console.ReadLine();
                float kegRadius = float.Parse(Console.ReadLine());
                int kegHeight = int.Parse(Console.ReadLine());

                double kegVolume = Math.PI * Math.Pow(kegRadius, 2) * kegHeight;

                if (kegVolume > biggestVolume)
                {
                    biggestVolume = (float)kegVolume;
                    biggestModel = kegModel;
                }
            }

            Console.WriteLine(biggestModel);
        }
    }
}
