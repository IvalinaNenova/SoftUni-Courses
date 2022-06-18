using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        //    First, write a C# class Player with the following properties:
        //    •	Name: string
        //    •	Class: string
        //    •	Rank: string – "Trial" by default
        //    •	Description: string – "n/a" by default
        public string Name { get; set; }

        public string Class { get; set; }

        public string Rank { get; set; } = "Trial";

        public string Description { get; set; } = "n/a";
        //    The class constructor should receive name and class.
        public Player(string name, string @class)
        {
            Name = name;
            Class = @class;
        }
        // Override the ToString() method in the following format:
        //    "Player {Name}: {Class}
        //    Rank: {Rank
        //    }
        //    Description: {Description
        //    }
        //"
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Player {Name}: {Class}");
            output.AppendLine($"Rank: {Rank}");
            output.Append($"Description: {Description}");
            return output.ToString();
        }
    }
}
