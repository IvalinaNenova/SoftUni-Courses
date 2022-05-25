using System;
using System.Collections.Generic;
using System.Linq;

namespace T08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contestLogInInfo = new Dictionary<string, string>();
            GetCorrectLogInInfo(contestLogInInfo);

            string userInput = Console.ReadLine();
            var userData = new SortedDictionary<string, Dictionary<string, int>>();

            while (userInput != "end of submissions")
            {
                string[] userInfo = userInput.Split("=>");
                string contest = userInfo[0];
                string username = userInfo[2];
                int points = int.Parse(userInfo[3]);

                if (CheckLogInInfo(userInfo, contestLogInInfo))
                {
                    CollectCandidatesData(userData, username, contest, points);
                }

                userInput = Console.ReadLine();
            }

            PrintMessage(userData);
        }

        private static void CollectCandidatesData(SortedDictionary<string, Dictionary<string, int>> userData, string username, string contest, int points)
        {
            if (!userData.ContainsKey(username))
            {
                userData[username] = new Dictionary<string, int>();
                userData[username].Add(contest, points);
            }

            if (!userData[username].ContainsKey(contest))
            {
                userData[username][contest] = points;
            }
            else if (userData[username][contest] < points)
            {
                userData[username][contest] = points;
            }
        }

        private static void PrintMessage(SortedDictionary<string, Dictionary<string, int>> userData)
        {
            var best = FindBestCandidate(userData);
            string bestCandidate = best.Item1;
            int bestCandidatePoints = best.Item2;

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestCandidatePoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var (user, userContests) in userData)
            {
                Console.WriteLine(user);
                var ordered = userContests.OrderByDescending(x => x.Value);
                foreach (var (contest, points) in ordered)
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }

        private static (string, int) FindBestCandidate(SortedDictionary<string, Dictionary<string, int>> userData)
        {
            int bestCandidatePoints = 0;
            string bestCandidate = string.Empty;

            foreach (var entry in userData)
            {
                int totalPoints = entry.Value.Values.Sum();

                if (totalPoints > bestCandidatePoints)
                {
                    bestCandidatePoints = totalPoints;
                    bestCandidate = entry.Key;
                }
            }

            return (bestCandidate ,bestCandidatePoints);
        }

        private static void GetCorrectLogInInfo(Dictionary<string, string> contestLogInInfo)
        {
            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] contestData = input.Split(':');
                string contestName = contestData[0];
                string contestPassword = contestData[1];

                contestLogInInfo[contestName] = contestPassword;

                input = Console.ReadLine();
            }
        }

        private static bool CheckLogInInfo(string[] userLogIn, Dictionary<string, string> contestLogInInfo)
        {
            string contest = userLogIn[0];
            string password = userLogIn[1];

            return contestLogInInfo.ContainsKey(contest) &&
                   contestLogInInfo[contest] == password;
        }
    }
}
