using System;
using System.Numerics;

namespace T11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            ushort numberOfSnowballs = ushort.Parse(Console.ReadLine());

            BigInteger bestSnowball = 0;
            int bestSnow = 0;
            int bestTime = 0;
            int bestQuality = 0;

            for (ushort snowball = 0; snowball < numberOfSnowballs; snowball++)
            {
                ushort snowballSnow = ushort.Parse(Console.ReadLine());
                ushort snowballTime = ushort.Parse(Console.ReadLine());
                ushort snowballQuality = ushort.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

                if (snowballValue > bestSnowball)
                {
                    bestSnow = snowballSnow;
                    bestTime = snowballTime;
                    bestQuality = snowballQuality;
                    bestSnowball = snowballValue;
                }
            }

            Console.WriteLine($"{bestSnow} : {bestTime} = {bestSnowball} ({bestQuality})");
        }
    }
}
