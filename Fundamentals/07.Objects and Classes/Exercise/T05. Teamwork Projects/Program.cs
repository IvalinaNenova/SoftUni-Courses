using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace T05._Teamwork_Projects
{
    class Team
    {
        public Team(string creator, string teamName)
        {
            TeamName = teamName;
            Creator = creator;
            Member = new List<string>();
        }
        public string TeamName { get; set; }

        public string Creator { get; set; }

        public List<string> Member { get; set; }

        public override string ToString()
        {
            
            Member.Sort();
            string output = $"{this.TeamName}\n";
            output += $"- {this.Creator}\n";

            foreach (string member in Member)
            {
                output += $"-- {member}\n";
            }
            
            return output.Trim();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfTeams = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>(); 

            for (int i = 0; i < countOfTeams; i++)
            {
                string[] data = Console.ReadLine().Split("-");
                string creator = data[0];
                string teamName = data[1];

                Team existingTeamCreator = teams.Find(team => team.Creator == creator);
                Team existingTeamName = teams.FirstOrDefault(team => team.TeamName == teamName);


                if (existingTeamCreator == null && existingTeamName == null)
                {
                    teams.Add(new Team(creator, teamName));
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
               
                else if (existingTeamName != null)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }

                else if (existingTeamCreator != null)
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
            }

            string input = Console.ReadLine();

            while (input != "end of assignment")
            {
                string[] userData = input.Split("->");
                string memberName = userData[0];
                string teamName = userData[1];

                Team existingTeam = teams.Find(team => team.TeamName == teamName);
                Team existingUser = teams.Find(x => x.Member.Contains(memberName) || x.Creator == memberName);

                if (existingTeam == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (existingUser != null)
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                }
                else
                {
                    existingTeam.Member.Add(memberName);
                }

                
                input = Console.ReadLine();
            }

            
            List<Team> sortedTeams = teams.OrderByDescending(team => team.Member.Count()).ThenBy(name=> name.TeamName).ToList();

            List<string> disbandedTeams = teams
                .Where(team => team.Member.Count() == 0)
                .OrderBy(team => team.TeamName)
                .Select(name => name.TeamName)
                .ToList();

            sortedTeams.RemoveAll(teams => teams.Member.Count() == 0);

            foreach (Team team in sortedTeams)
            {
                Console.WriteLine(team);
            }

            Console.WriteLine("Teams to disband:");
            foreach (string emptyTeam in disbandedTeams)
            {
                Console.WriteLine(emptyTeam);
            }
        }
    }
}
