using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private readonly List<Player> players;

        public Team(string name)
        {
            Name = name;

            players = new List<Player>();
        }
        public string Name { get; set; }

        public double Rating
            => players.Count == 0 
                ? 0 
                : Math.Round(players.Average(p => p.SkillLevel));
       

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(p => p.Name == playerName);

            if (player == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            players.Remove(player);
        }
    }
}
