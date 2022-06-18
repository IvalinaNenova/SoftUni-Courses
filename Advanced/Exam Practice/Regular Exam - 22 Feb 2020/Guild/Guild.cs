using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        //Next, write a C# class Guild that has a roster (a collection which stores the entity Player). All entities inside the repository have the same properties. Also, the Guild class should have those properties:
        //•	Name: string
        //•	Capacity: int
        private List<Player> roster;
        public string Name { get; set; }

        public int Capacity { get; set; }
        public int  Count => roster.Count;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }
        //    The class constructor should receive name and capacity, also it should initialize the roster with a new instance of the collection.Implement the following features:
        public void AddPlayer(Player player) /*- adds an entity to the roster if there is room for it*/
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name) /*- removes a player by given name, if such exists, and returns {bool*/
        {
            return roster.Remove(roster.FirstOrDefault(p => p.Name == name));
        }

        public void PromotePlayer(string name) /*- promote(set his rank to "Member") the first player with the given name.If the player is already a "Member", do nothing.*/
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);
            if (player != null && player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name) /*- demote(set his rank to "Trial") the first player with the given name.If the player is already a "Trial",  do nothing.*/
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);
            if (player != null && player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class) /*- removes all the players by the given class and returns all players from that class as an array*/
        {
            Player[] removedPlayers = this.roster.FindAll(p => p.Class == @class).ToArray();
            this.roster.RemoveAll(p => p.Class == @class);
            return removedPlayers;
        }

        public string Report() //- returns a string in the following format:	//"Players in the guild: {guildName}
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Players in the guild: {Name}");

            for (int i = 0; i < roster.Count; i++)
            {
                output.AppendLine(roster[i].ToString());
            }

            return output.ToString().TrimEnd();
        }

    }
}
