using System;

namespace R01._Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            bool isGameOver = false;
            int winCounter = 0;

            string input = Console.ReadLine();

            while (input != "End of battle")
            {
                int distance = int.Parse(input);

                if (distance > energy)
                {
                    isGameOver = true;
                    break;
                }

                energy -= distance;
                winCounter++;

                if (winCounter % 3 == 0)
                {
                    energy += winCounter;
                }

                input = Console.ReadLine();
            }

            if (isGameOver)
            {
                Console.WriteLine($"Not enough energy! Game ends with {winCounter} won battles and {energy} energy");
            }
            else
            {
                Console.WriteLine($"Won battles: {winCounter}. Energy left: {energy}");
            }
        }
    }
}
