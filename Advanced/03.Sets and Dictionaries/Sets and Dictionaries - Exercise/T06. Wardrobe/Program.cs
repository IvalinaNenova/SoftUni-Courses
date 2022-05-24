using System;
using System.Collections.Generic;

namespace T06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfColors = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < numberOfColors; i++)
            {
                string[] wardrobeData = Console.ReadLine().Split(" -> ");
                string color = wardrobeData[0];
                string[] itemOfClothing = wardrobeData[1].Split(',');

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                foreach (var item in itemOfClothing)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color][item] = 0;
                    }

                    wardrobe[color][item]++;
                }
            }

            string[] itemToLookFor = Console.ReadLine().Split(' ');
            string searchedColor = itemToLookFor[0];
            string searchedItem = itemToLookFor[1];

            foreach (var (color, item) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var (piece, count) in item)
                {
                    if (color == searchedColor && piece == searchedItem)
                    {
                        Console.WriteLine($"* {piece} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {piece} - {count}");
                    }
                }
            }
        }
    }
}
