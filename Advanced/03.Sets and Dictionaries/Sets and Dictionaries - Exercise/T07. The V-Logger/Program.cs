using System;
using System.Collections.Generic;
using System.Linq;

namespace T07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var users = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            while (!input.Contains("Statistics"))
            {
                string[] commands = input.Split(' ');
                string vlogger = commands[0];

                if (input.Contains("joined"))
                {
                    if (!users.ContainsKey(vlogger))
                    {
                        users[vlogger] = new Dictionary<string, SortedSet<string>>();
                        users[vlogger]["followers"] = new SortedSet<string>();
                        users[vlogger]["following"] = new SortedSet<string>();
                    }

                }
                else if (input.Contains("followed"))
                {
                    string firstVlogger = commands[0];
                    string secondVlogger = commands[2];

                    if (CheckIfValidUsers(users, firstVlogger, secondVlogger))
                    {
                        users[secondVlogger]["followers"].Add(firstVlogger);
                        users[firstVlogger]["following"].Add(secondVlogger);
                    }

                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {users.Count} vloggers in its logs.");
            var ordered = users.OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(y => y.Value["following"].Count);
            int rank = 1;

            foreach (var (user, data) in ordered)
            {

                int countFollowers = data["followers"].Count;
                int countFollowing = data["following"].Count;
                Console.WriteLine($"{rank}. {user} : {countFollowers} followers, {countFollowing} following");

                if (rank == 1)
                {
                    foreach (var follower in data["followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                rank++;
            }
        }

        private static bool CheckIfValidUsers(Dictionary<string, Dictionary<string, SortedSet<string>>> users, string firstVlogger, string secondVlogger)
        {
            return users.ContainsKey(firstVlogger) &&
                   users.ContainsKey(secondVlogger) &&
                   firstVlogger != secondVlogger;

        }
    }
}
