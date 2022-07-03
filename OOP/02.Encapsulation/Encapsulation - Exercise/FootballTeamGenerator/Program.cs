using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] commands = line.Split(';');
                string action = commands[0];
                string teamName = commands[1];

                try
                {
                    switch (action)
                    {
                        case "Team":
                            teams.Add(new Team(teamName));
                            break;
                        case "Add":
                        {
                            Team targetTeam = ValidateTargetTeam(teams, teamName);

                            Player player = new Player(commands[2],
                                int.Parse(commands[3]),
                                int.Parse(commands[4]),
                                int.Parse(commands[5]),
                                int.Parse(commands[6]),
                                int.Parse(commands[7]));

                            targetTeam.AddPlayer(player);
                            break;
                        }
                        case "Remove":
                        {
                            string playerName = commands[2];
                            Team targetTeam = ValidateTargetTeam(teams, teamName);
                            targetTeam.RemovePlayer(playerName);
                            break;
                        }
                        case "Rating":
                        {
                            Team targetTeam = ValidateTargetTeam(teams, teamName);
                            Console.WriteLine($"{teamName} - {targetTeam.Rating}");
                            break;
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
               

                line = Console.ReadLine();
            }

        }

        private static Team ValidateTargetTeam(List<Team> teams, string teamName)
        {
            Team targetTeam = teams.FirstOrDefault(t => t.Name == teamName);

            if (targetTeam == null)
            {
                throw new Exception($"Team {teamName} does not exist.");
            }

            return targetTeam;
        }
    }
}
