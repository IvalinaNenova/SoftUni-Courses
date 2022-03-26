using System;
using System.Collections.Generic;
using System.Linq;

namespace C02._MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] dungeonRooms = Console.ReadLine()
            //    .Split("|")
            //    .ToArray();

            //const int maxHealth = 100;
            //int health = maxHealth;
            //int treasure = 0;
            //bool isGameOver = false;

            //for (int i = 0; i < dungeonRooms.Length; i++)
            //{
            //    string[] roomContents = dungeonRooms[i].Split();
            //    string roomType = roomContents[0];

            //    if (roomType == "potion")
            //    {
            //        int healthBoost = int.Parse(roomContents[1]);
            //        int healAmount = 0;

            //        if ((healthBoost + health) > maxHealth)
            //        {
            //            healAmount = maxHealth - health;
            //            health = maxHealth;
            //        }
            //        else
            //        {
            //            healAmount = healthBoost;
            //            health += healthBoost;
            //        }

            //        Console.WriteLine($"You healed for {healAmount} hp.");
            //        Console.WriteLine($"Current health: {health} hp.");
            //    }
            //    else if (roomType == "chest")
            //    {
            //        int bitcoins = int.Parse(roomContents[1]);
            //        treasure += bitcoins;

            //        Console.WriteLine($"You found {bitcoins} bitcoins.");
            //    }
            //    else
            //    {
            //        string monster = roomContents[0];
            //        int monsterAttack = int.Parse(roomContents[1]);
            //        health -= monsterAttack;

            //        if (health <= 0)
            //        {
            //            Console.WriteLine($"You died! Killed by {monster}.");
            //            Console.WriteLine($"Best room: {i + 1}");
            //            isGameOver = true;
            //            break;
            //        }
            //        else
            //        {
            //            Console.WriteLine($"You slayed {monster}.");
            //        }

            //    }
            //}

            //if (!isGameOver)
            //{
            //    Console.WriteLine("You've made it!");
            //    Console.WriteLine($"Bitcoins: {treasure}");
            //    Console.WriteLine($"Health: {health}");
            //}

            double[] array = {0.15824, 2.55584, 1.3654554};
            double[] rounded = array.Select(d => Math.Round(d, 2)).ToArray();


            Console.WriteLine(string.Join(", ", rounded));

        }
    }
}
