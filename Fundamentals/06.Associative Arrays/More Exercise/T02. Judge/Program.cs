using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string,int>> contestsAndParticipants = new Dictionary<string, Dictionary<string,int>>();
            Dictionary<string, int> individualsRankings = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "no more time")
            {
                string[] inputData = input.Split(" -> ");
                string username = inputData[0];
                string contest = inputData[1];
                int currentPoints = int.Parse(inputData[2]);

                if (!contestsAndParticipants.ContainsKey(contest))
                {
                    contestsAndParticipants.Add(contest, new Dictionary<string, int>());
                }

                if (!contestsAndParticipants[contest].ContainsKey(username))
                {
                    contestsAndParticipants[contest].Add(username, currentPoints);
                }
                else
                {
                    int previousPoints = contestsAndParticipants[contest][username];

                    if (previousPoints < currentPoints)
                    {
                        contestsAndParticipants[contest][username] = currentPoints;
                        currentPoints-=previousPoints;
                    }
                    else
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    
                }

                if (!individualsRankings.ContainsKey(username))
                {
                    individualsRankings.Add(username, currentPoints);
                }
                else
                {
                    individualsRankings[username] += currentPoints;
                }

                input = Console.ReadLine();
            }

            foreach (var contest in contestsAndParticipants)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Keys.Count} participants");

                var orderedParticipants = contest.Value
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key);
                
                int position = 1;

                foreach (var participant in orderedParticipants)
                {
                    Console.WriteLine($"{position}. {participant.Key} <::> {participant.Value}");
                    position++;
                }
            }

            Console.WriteLine("Individual standings:");

            var sortedRankings = individualsRankings
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key);

                int rank = 1;

            foreach (var user in sortedRankings)
            {
                Console.WriteLine($"{rank}. {user.Key} -> {user.Value}");
                rank++;
            }
        }
    }
}
