using System;

namespace T04._Game_Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string player1 = Console.ReadLine();
            string player2 = Console.ReadLine();
            string input = Console.ReadLine();
            int player1Points = 0;
            int player2Points = 0;
            int numberOfCards = 36;
            string winner = "";
            int maxPoints = 0;
            bool isWar = false;


            while (input != "End of game")
            {
                int card1 = int.Parse(input);
                int card2 = int.Parse(Console.ReadLine());
                numberOfCards -= 2;

                if (card1>card2)
                {
                    player1Points += card1 - card2;
                }
                else if (card2>card1)
                {
                    player2Points += card2 - card1;
                }
                else if (card1 == card2)
                {
                    card1 = int.Parse(Console.ReadLine());
                    card2 = int.Parse(Console.ReadLine());
                    if (card1 > card2)
                    {
                        winner = player1;
                        maxPoints = player1Points;
                        isWar = true;
                        break;
                    }
                    else if (card2 > card1)
                    {
                        winner = player2;
                        maxPoints = player2Points;
                        isWar = true;
                        break;
                    }
                }

                input = Console.ReadLine();
            }

            if (isWar)
            {
                Console.WriteLine($"Number wars!");
                Console.WriteLine($"{winner} is winner with {maxPoints} points");
            }
            else if (input == "End of game")
            {
                Console.WriteLine($"{player1} has {player1Points} points");
                Console.WriteLine($"{player2} has {player2Points} points");
            }

        }
    }
}
