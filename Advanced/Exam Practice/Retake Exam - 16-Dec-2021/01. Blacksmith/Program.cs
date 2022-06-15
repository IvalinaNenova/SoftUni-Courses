using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> swordsMaterials = new Dictionary<int, string>
            {
                {70, "Gladius"},
                {80, "Shamshir"},
                {90, "Katana"},
                {110, "Sabre"},
                {150, "Broadsword"},
            };

            int[] steelInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] carbonInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> steel = new Queue<int>(steelInput);
            Stack<int> carbon = new Stack<int>(carbonInput);

            var forgedSwords = new SortedDictionary<string, int>();

            while (steel.Any() && carbon.Any())
            {
                int currentSteel = steel.Dequeue();
                int currentCarbon = carbon.Pop();
                int total = currentSteel + currentCarbon;

                if (swordsMaterials.ContainsKey(total))
                {
                    string sword = swordsMaterials[total];

                    if (!forgedSwords.ContainsKey(sword))
                    {
                        forgedSwords[sword] = 0;
                    }

                    forgedSwords[sword]++;
                }
                else
                {
                    carbon.Push(currentCarbon + 5);
                }
            }

            int count = forgedSwords.Values.Sum();

            Console.WriteLine(forgedSwords.Any()
                ? $"You have forged {count} swords."
                : "You did not have enough resources to forge a sword.");

            Console.WriteLine(!steel.Any() ? "Steel left: none" : $"Steel left: {string.Join(", ", steel)}");

            Console.WriteLine(!carbon.Any() ? "Carbon left: none" : $"Carbon left: {string.Join(", ", carbon)}");

            foreach (var (sword, amount) in forgedSwords)
            {
                Console.WriteLine($"{sword}: {amount}");
            }
        }
    }
}
