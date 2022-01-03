using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 1; i <= n; i++)
            {
                string[] currentSong = Console.ReadLine()
                    .Split("_");

                Song song = new Song();

                song.TypeList = currentSong[0];
                song.Name = currentSong[1];
                song.Time = currentSong[2];

                songs.Add(song);
            }

            string typeList = Console.ReadLine();

            if (typeList == "all")
            {
                foreach (Song currentSong in songs)
                {
                    Console.WriteLine(currentSong.Name);
                }
            }
            else
            {
                foreach (Song currentSong in songs)
                {
                    if (typeList == currentSong.TypeList)
                    {
                        Console.WriteLine(currentSong.Name);
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
