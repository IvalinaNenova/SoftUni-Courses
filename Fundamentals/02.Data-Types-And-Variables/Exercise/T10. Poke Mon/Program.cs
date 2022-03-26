using System;

namespace T10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int currentPower = power;
            int pokeCounter = 0;

            while (currentPower >= distance)
            {
                currentPower -= distance;
                pokeCounter++;

                if (currentPower == power * 0.5 && exhaustionFactor > 0)
                {
                    currentPower /= exhaustionFactor;
                }
            }

            Console.WriteLine(currentPower);
            Console.WriteLine(pokeCounter);
        }
    }
}
