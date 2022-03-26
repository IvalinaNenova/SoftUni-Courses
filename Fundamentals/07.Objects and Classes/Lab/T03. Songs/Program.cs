using System;
using System.Collections.Generic;

namespace T03._Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            List<Song> songList = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] data = Console.ReadLine().Split("_");

                string type = data[0];
                string name = data[1];
                string time = data[2];

                Song song = new Song();

                song.TypeList = type;
                song.Name = name;
                song.Time = time;

                songList.Add(song);
            }

            string typeList = Console.ReadLine();

            if (typeList == "all")
            {
                foreach (Song song in songList)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in songList)
                {
                    if (song.TypeList == typeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }

    class Song
    {
        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }
    }
}
