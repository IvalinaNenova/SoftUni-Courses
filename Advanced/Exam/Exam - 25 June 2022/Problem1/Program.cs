using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> tilesNeeded = new Dictionary<int, string>
            {
                {40, "Sink"},
                {50, "Oven"},
                {60, "Countertop"},
                {70, "Wall"},
            };
            SortedDictionary<string, int> completedAreas = new SortedDictionary<string, int>
            {
                {"Sink", 0},
                {"Oven", 0},
                {"Countertop", 0},
                {"Wall", 0},
                {"Floor", 0},
            };

            int[] input1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var grayTiles = new Queue<int>(input2);
            var whiteTiles = new Stack<int>(input1);

            while (grayTiles.Any() && whiteTiles.Any())
            {
                int gray = grayTiles.Dequeue();
                int white = whiteTiles.Pop();
                int totalArea = 0;

                if (gray == white)
                {
                    totalArea = gray + white;
                    if (tilesNeeded.ContainsKey(totalArea))
                    {
                        string area = tilesNeeded[totalArea];
                        completedAreas[area]++;
                    }
                    else
                    {
                        completedAreas["Floor"]++;
                    }
                }
                else
                {
                    whiteTiles.Push(white / 2);
                    grayTiles.Enqueue(gray);
                }
            }

            Console.WriteLine(whiteTiles.Any()
                ? $"White tiles left: {string.Join(", ", whiteTiles)}"
                : "White tiles left: none");
            Console.WriteLine(grayTiles.Any()
                ? $"Grey tiles left: {string.Join(", ", grayTiles)}"
                : $"Grey tiles left: none");

            var filtered = completedAreas.Where(x => x.Value > 0).OrderByDescending(x => x.Value);
            foreach (var (area, count) in filtered)
            {
                Console.WriteLine($"{area}: {count}");
            }
        }
    }
}
