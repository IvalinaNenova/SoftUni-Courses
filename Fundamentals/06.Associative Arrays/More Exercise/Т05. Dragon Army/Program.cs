using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Т05._Dragon_Army
{

    class Dragon
    {
        public string Name { get; set; }

        public int Damage { get; set; }

        public int Health { get; set; }

        public int Armour { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, SortedDictionary<string, List<Dragon>>> dragons =
                new Dictionary<string, SortedDictionary<string, List<Dragon>>>();

            for (int i = 0; i < n; i++)
            {
                string[] dragonData = Console.ReadLine().Split();

                string type = dragonData[0];
                string name = dragonData[1];
                int damage = dragonData[2] == "null" ? 45 : int.Parse(dragonData[2]);
                int health = dragonData[3] == "null" ? 250 : int.Parse(dragonData[3]);
                int armour = dragonData[4] == "null" ? 10 : int.Parse(dragonData[4]);

                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new SortedDictionary<string, List<Dragon>>());
                }

                if (!dragons[type].ContainsKey(name))
                {
                    Dragon dragon = new Dragon()
                    {
                        Name = name,
                        Damage = damage,
                        Health = health,
                        Armour = armour
                    };

                    dragons[type].Add(name, new List<Dragon>());
                    dragons[type][name].Add(dragon);

                }
                else
                {
                    Dragon dragon = dragons[type][name].Find(x => x.Name == name);
                    dragon.Damage = damage;
                    dragon.Health = health;
                    dragon.Armour = armour;
                }
            }
            foreach (var dragon in dragons)
            {
                double averageDamage = dragon.Value.Values.Average(d => d.Average(x => x.Damage));
                double averageHealth = dragon.Value.Values.Average(d => d.Average(x => x.Health));
                double averageArmour = dragon.Value.Values.Average(d => d.Average(x => x.Armour));

                Console.WriteLine($"{dragon.Key}::({averageDamage:f2}/{averageHealth:f2}/{averageArmour:f2})");

             

                foreach (var dragonName in dragon.Value.Values)
                {
                    for (int i = 0; i < dragonName.Count; i++)
                    {
                        Console.WriteLine($"-{dragonName[i].Name} -> damage: {dragonName[i].Damage}, health: {dragonName[i].Health}, armor: {dragonName[i].Armour}");
                    }
                    
                }
            }
        }
    }
}
