using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace T01._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, string> contestAndPassword = new Dictionary<string, string>();

            while (input != "end of contests")
            {
                string[] contestData = input.Split(":");
                string contest = contestData[0];
                string password = contestData[1];

                contestAndPassword.Add(contest, password);

                input = Console.ReadLine();
            }

            string inputData = Console.ReadLine();

            SortedDictionary<string, Dictionary<string, int>> candidates =
                new SortedDictionary<string, Dictionary<string, int>>();

            while (inputData != "end of submissions")
            {
                string[] candidateData = inputData.Split("=>");
                string contestName = candidateData[0];
                string password = candidateData[1];
                string candidateName = candidateData[2];
                int candidatePoints = int.Parse(candidateData[3]);

                bool isValidInput = CheckContestAndPasswordValidity(contestAndPassword, contestName, password);

                if (isValidInput)
                {
                    if (!candidates.ContainsKey(candidateName))
                    {
                        candidates.Add(candidateName, new Dictionary<string, int>());
                    }

                    if (!candidates[candidateName].ContainsKey(contestName))
                    {
                        candidates[candidateName].Add(contestName, candidatePoints);
                    }
                    else
                    {
                        if (candidates[candidateName][contestName] < candidatePoints)
                        {
                            candidates[candidateName][contestName] = candidatePoints;
                        }
                    }

                }

                inputData = Console.ReadLine();
            }

            int bestCandidatePoints = 0;
            string bestCandidate = string.Empty;

            foreach (var entry in candidates)
            {
                int totalPoints = entry.Value.Values.Sum();

                if (totalPoints > bestCandidatePoints)
                {
                    bestCandidatePoints = totalPoints;
                    bestCandidate = entry.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestCandidatePoints} points.");
            Console.WriteLine($"Ranking:");


            foreach (var candidate in candidates)
            {
                Console.WriteLine(candidate.Key);

                var sorted = candidate.Value.OrderByDescending(x => x.Value);

                foreach (var item in sorted)
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }

            }

        }

        public static bool CheckContestAndPasswordValidity(Dictionary<string, string> validContests, string contest,
                string password)
        {
            if (validContests.ContainsKey(contest) && validContests[contest] == password)
            {
                return true;
            }

            return false;
        }
    }
}
