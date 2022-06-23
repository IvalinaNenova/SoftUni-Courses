using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _01._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            var effects = new Queue<int>(input1);
            var casings = new Stack<int>(input2);
            var bombsRecipe = new Dictionary<int, string>
            {
                {40,"Datura Bombs"},
                {60,"Cherry Bombs"},
                {120,"Smoke Decoy Bombs"}
            };
            var bombsMade = new Dictionary<string, int>
            {
                {"Datura Bombs", 0},
                {"Cherry Bombs", 0},
                {"Smoke Decoy Bombs", 0}
            };

            bool isPouchFull = false;
            while (effects.Any() && casings.Any())
            {
                int currentEffect = effects.Peek();
                int currentCasing = casings.Pop();

                int total = currentCasing + currentEffect;
                if (bombsRecipe.ContainsKey(total))
                {
                    effects.Dequeue();
                    string bombMade = bombsRecipe[total];
                    bombsMade[bombMade]++;
                }
                else
                {
                    casings.Push(currentCasing - 5);
                }

                isPouchFull = !bombsMade.Any(x => x.Value < 3);
                if (isPouchFull)
                {
                    break;
                }
            }

            Console.WriteLine(isPouchFull
                ? "Bene! You have successfully filled the bomb pouch!"
                : "You don't have enough materials to fill the bomb pouch.");
            Console.WriteLine(effects.Any()
                ? $"Bomb Effects: {string.Join(", ", effects)}"
                : "Bomb Effects: empty");
            Console.WriteLine(casings.Any()
                ? $"Bomb Casings: {string.Join(", ", casings)}"
                : "Bomb Casings: empty");

            foreach (var (bomb, amount) in bombsMade.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb}: {amount}");
            }
        }
    }
}
