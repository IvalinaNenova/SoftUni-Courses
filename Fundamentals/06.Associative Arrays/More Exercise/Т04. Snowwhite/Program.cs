using System;
using System.Collections.Generic;
using System.Linq;

namespace Т04._Snowwhite
{
    class Dwarf
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Physics { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Dwarf>> dwarfs = new Dictionary<string, List<Dwarf>>();
            List<Dwarf> dwarfs2 = new List<Dwarf>();

            string input = Console.ReadLine();

            while (input != "Once upon a time")
            {
                string[] dwarfData = input.Split(" <:> ");

                string name = dwarfData[0];
                string color = dwarfData[1];
                int physics = int.Parse(dwarfData[2]);

                if (!dwarfs.ContainsKey(color))
                {
                    dwarfs.Add(color, new List<Dwarf>());
                }

                bool isDwarfExisting = dwarfs[color].Any(x => x.Name == name);

                if (!isDwarfExisting)
                {
                    Dwarf dwarf = new Dwarf()
                    {
                        Name = name,
                        Color = color,
                        Physics = physics
                    };

                    dwarfs[color].Add(dwarf);
                    dwarfs2.Add(dwarf);
                }
                else
                {
                    Dwarf dwarf = dwarfs[color].Find(dwarf => dwarf.Name == name);
                    dwarf.Physics = Math.Max(dwarf.Physics, physics);
                }
                input = Console.ReadLine();
            }

            var sorted = dwarfs2
                .OrderByDescending(x => x.Physics)
                .ThenByDescending(x => dwarfs[x.Color].Count)
                .ToList();

            foreach (var dwarf in sorted)
            {
                Console.WriteLine($"({dwarf.Color}) {dwarf.Name} <-> {dwarf.Physics}");
            }
        }
    }
}
