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
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }

                return Math.Round(players.Sum(p => p.SkillLevel) / players.Count);
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (players.Find(p => p.Name == playerName) == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            players.Remove(players.Find(p => p.Name == playerName));
        }
    }
}
