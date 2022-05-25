using System;
using System.Collections.Generic;
using System.Linq;

namespace T10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var users = new SortedDictionary<string, SortedSet<string>>();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                string[] command = input.Split(new string[] { " -> ", " | " }, StringSplitOptions.RemoveEmptyEntries);
                string side = command[0];
                string user = command[1];

                if (input.Contains('|'))
                {
                    bool isFound = users.Values.Any(userData => userData.Contains(user));

                    if (!isFound)
                    {
                        if (!users.ContainsKey(side))
                        {
                            users[side] = new SortedSet<string>();
                        }

                        users[side].Add(user);
                    }
                }

                else if (input.Contains("->"))
                {
                    user = command[0];
                    side = command[1];
                    bool isFound = false;

                    foreach (var userData in users)
                    {
                        foreach (var person in userData.Value)
                        {
                            if (person == user)
                            {
                                users[userData.Key].Remove(person);
                                isFound = true;
                                if (!users.ContainsKey(side))
                                {
                                    users[side] = new SortedSet<string>();
                                    
                                }
                                users[side].Add(user);
                                break;
                            }
                        }
                        if (isFound)
                        {
                            break;
                        }
                    }

                    if (!isFound)
                    {
                        if (!users.ContainsKey(side))
                        {
                            users[side] = new SortedSet<string>();
                        }
                        users[side].Add(user);
                    }

                    Console.WriteLine($"{user} joins the {side} side!");
                }

                input = Console.ReadLine();
            }

            var ordered = users
                .Where(x => x.Value.Any())
                .OrderByDescending(y => y.Value.Count);

            foreach (var (side, members) in ordered)
            {
                Console.WriteLine($"Side: {side}, Members: {members.Count}");

                foreach (var member in members)
                {
                    Console.WriteLine($"! {member}");
                }
            }
        }
    }
}
