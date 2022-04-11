using System;

namespace T06._Tournament_of_Christmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int tournamentDays = int.Parse(Console.ReadLine());
            int totalgamesWon = 0;
            int totalgamesLost = 0;
            double totalMoneyWon = 0;

            for (int day = 1; day <= tournamentDays; day++)
            {
                string sport = Console.ReadLine();

                int gamesWon = 0;
                int gamesLost = 0;
                double moneyWonPerDay = 0;

                while (sport != "Finish")
                {
                    string result = Console.ReadLine();
                    if (result == "win")
                    {
                        gamesWon++;
                        moneyWonPerDay += 20;
                    }
                    else if (result == "lose")
                    {
                        gamesLost++;
                    }
                    sport = Console.ReadLine();
                }
                
                totalgamesWon += gamesWon;
                totalgamesLost += gamesLost;

                if (gamesWon > gamesLost)
                {
                    moneyWonPerDay *= 1.1;
                }
                totalMoneyWon += moneyWonPerDay;

            }
            
            if (totalgamesWon > totalgamesLost)
            {
                totalMoneyWon *= 1.2;
                Console.WriteLine($"You won the tournament! Total raised money: {totalMoneyWon:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalMoneyWon:f2}");
            }

        }
    }
}
