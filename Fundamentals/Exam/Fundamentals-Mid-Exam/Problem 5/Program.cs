using System;
using System.Collections.Generic;
using System.Linq;

namespace CArds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> deck = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                List<string> commands = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

                string card = commands[1];
                //int index = int.Parse(commands[1]);


                if (commands.Count == 2)
                {
                    if (commands[0].Contains("Add"))
                    {

                        if (deck.Contains(commands[1]))
                        {
                            Console.WriteLine("Card is already in the deck");
                            continue;
                        }
                        deck.Add(card);
                        Console.WriteLine("Card succesfully added");
                    }
                    else if (commands[0].Contains("Remove"))
                    {

                        if (!deck.Contains(commands[1]))
                        {
                            Console.WriteLine("Card not found");
                        }
                        if (deck.Contains(commands[1]))
                        {
                            deck.Remove(card);
                            Console.WriteLine("Card succefully removed");
                        }




                    }
                }

                if (commands.Count == 3)
                {
                    if (commands[0].Contains("insert"))
                    {
                        int index = int.Parse(commands[1]);
                        card = commands[2];


                        if (index < 0 || index >= deck.Count)
                        {
                            Console.WriteLine("Index out of range");
                            continue;
                        }


                        deck.Insert(index, card);
                        Console.WriteLine("Card succesfully added");




                    }
                    if (commands[0].Contains("Remove at"))
                    {


                        int index = int.Parse(commands[1]);
                        card = commands[2];




                        deck.RemoveAt(index);
                        Console.WriteLine("Card succesfully added");

                    }
                }


            }

            Console.WriteLine(string.Join(" ", deck));
        }
    }
}
