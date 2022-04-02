using System;
using System.Collections.Generic;

namespace E03._P_rates
{
    class Town
    {
        public Town(string name, int population, int gold)
        {
            Name = name;
            Population = population;
            Gold = gold;
        }

        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }

        public void UpdateData(int population, int gold)
        {
            this.Population += population;
            this.Gold += gold;
        }

        public void PlunderTown(Dictionary<string, Town> targets, string town, int peopleKilled, int goldStolen)
        {
            this.Population -= peopleKilled;
            this.Gold -= goldStolen;

            Console.WriteLine($"{town} plundered! {goldStolen} gold stolen, {peopleKilled} citizens killed.");

            if (this.Population == 0 || this.Gold == 0)
            {
                targets.Remove(town);
                Console.WriteLine($"{town} has been wiped off the map!");
            }
        }

        public void IncreaseGold(int goldAdded)
        {
            if (goldAdded < 0)
            {
                Console.WriteLine("Gold added cannot be a negative number!");
            }
            else
            {
                this.Gold += goldAdded;
                Console.WriteLine($"{goldAdded} gold added to the city treasury. {this.Name} now has {this.Gold} gold.");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Town> targets = new Dictionary<string, Town>();

            while (input != "Sail")
            {
                string[] townData = input.Split("||");
                string town = townData[0];
                int population = int.Parse(townData[1]);
                int gold = int.Parse(townData[2]);

                if (!targets.ContainsKey(town))
                {
                    targets.Add(town, new Town(town, population, gold));
                }
                else
                {
                    targets[town].UpdateData(population, gold);
                }

                input = Console.ReadLine();
            }

            string actionsInput = Console.ReadLine();

            while (actionsInput != "End")
            {
                string[] actionsData = actionsInput.Split("=>");
                string captainsCommand = actionsData[0];
                string town = actionsData[1];

                if (captainsCommand == "Plunder")
                {
                    int peopleKilled = int.Parse(actionsData[2]);
                    int goldStolen = int.Parse(actionsData[3]);
                    targets[town].PlunderTown(targets, town, peopleKilled, goldStolen);
                }
                else if (captainsCommand == "Prosper")
                {
                    int goldAdded = int.Parse(actionsData[2]);
                    targets[town].IncreaseGold(goldAdded);
                }

                actionsInput = Console.ReadLine();
            }

            if (targets.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {targets.Count} wealthy settlements to go to:");

                foreach (var target in targets)
                {
                    Console.WriteLine($"{target.Key} -> Population: {target.Value.Population} citizens, Gold: {target.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
