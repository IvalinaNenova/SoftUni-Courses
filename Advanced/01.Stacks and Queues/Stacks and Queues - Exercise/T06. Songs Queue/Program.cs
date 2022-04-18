using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> playlist = new Queue<string>(Console.ReadLine().Split(", "));

            while (playlist.Count > 0)
            {
                string[] command = Console.ReadLine().Split(' ').ToArray();

                if (command[0] == "Play")
                {
                    playlist.Dequeue();
                }
                else if (command[0] == "Add")
                {
                    string songToAdd = string.Join(" ", command.Skip(1));

                    if (playlist.Contains(songToAdd))
                    {
                        Console.WriteLine($"{songToAdd} is already contained!");
                    }
                    else
                    {
                        playlist.Enqueue(songToAdd);
                    }
                }
                else if (command[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", playlist));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
