using System;

namespace T04._Easter_Eggs_Battle
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstPlayerEggs = int.Parse(Console.ReadLine());
            int secondPlayerEggs = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int playerOneCounter = firstPlayerEggs;
            int playerTwoCounter = secondPlayerEggs;
            
            while (input != "End of battle")
            {
                if (input == "one")
                {
                    playerTwoCounter--;
                }
                else if (input == "two")
                {
                    playerOneCounter--;
                }
                if (playerOneCounter == 0 || playerTwoCounter == 0)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            if (playerOneCounter == 0)
            {
                Console.WriteLine($"Player one is out of eggs. Player two has {playerTwoCounter} eggs left.");
            }
            else if (playerTwoCounter == 0)
            {
                Console.WriteLine($"Player two is out of eggs. Player one has {playerOneCounter} eggs left.");
            }
            if (input == "End of battle")
            {
                Console.WriteLine($"Player one has {playerOneCounter} eggs left.");
                Console.WriteLine($"Player two has {playerTwoCounter} eggs left.");
            }
        }
    }
}
