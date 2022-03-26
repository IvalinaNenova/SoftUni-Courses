using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._MOBA_Challenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedDictionary<string, int>> playerPool = new SortedDictionary<string, SortedDictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "Season end")
            {
                string[] command = input
                    .Split(new string[] {" -> ", " vs "}, StringSplitOptions.RemoveEmptyEntries);

                if (command.Length == 3)
                {
                    string player = command[0];
                    string position = command[1];
                    int currentSkill = int.Parse(command[2]);

                    FillDictionary(playerPool, player, position, currentSkill);
                }
                else
                {
                    string player1 = command[0];
                    string player2 = command[1];

                    if (playerPool.ContainsKey(player1) && playerPool.ContainsKey(player2))
                    {
                        bool doTheyFight = CheckIfTheyCanFight(playerPool, player1, player2);

                        if (doTheyFight)
                        {
                            RemoveLoosingPlayer(playerPool, player1, player2);
                        }
                    }
                }

                input = Console.ReadLine();
            }

            var orderedPool = playerPool
                .OrderByDescending(x => x.Value.Values.Sum());

            foreach (var player in orderedPool)
            {
                int totalSkill = player.Value.Values.Sum();

                Console.WriteLine($"{player.Key}: {totalSkill} skill");

                var orderedSkills = player.Value
                    .OrderByDescending(x => x.Value);

                foreach (var position in orderedSkills)
                {
                    Console.WriteLine($"- {position.Key} <::> {position.Value}");
                }
            }
        }

        private static void FillDictionary(SortedDictionary<string, SortedDictionary<string, int>> playerPool, string player, string position, int currentSkill)
        {
            if (!playerPool.ContainsKey(player))
            {
                playerPool.Add(player, new SortedDictionary<string, int>());
            }

            if (!playerPool[player].ContainsKey(position))
            {
                playerPool[player].Add(position, currentSkill);
            }
            else
            {
                int previousSkill = playerPool[player][position];

                if (previousSkill < currentSkill)
                {
                    playerPool[player][position] = currentSkill;
                }
            }
        }

        
        private static bool CheckIfTheyCanFight(SortedDictionary<string, SortedDictionary<string, int>> playerPool, string player1, string player2)
        {
            

            foreach (var position1 in playerPool[player1].Keys)
            {
                foreach (var position2 in playerPool[player2].Keys)
                {
                    if (position1 == position2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static void RemoveLoosingPlayer(SortedDictionary<string, SortedDictionary<string, int>> playerPool, string player1, string player2)
        {
            int player1TotalSkills = playerPool[player1].Values.Sum();
            int player2TotalSkills = playerPool[player2].Values.Sum();

            if (player1TotalSkills > player2TotalSkills)
            {
                playerPool.Remove(player2);
            }
            else if (player2TotalSkills > player1TotalSkills)
            {
                playerPool.Remove(player1);
            }
        }

    }
}
