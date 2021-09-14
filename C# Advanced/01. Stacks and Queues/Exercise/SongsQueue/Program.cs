using System;
using System.Collections.Generic;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songsArray = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> songs = new Queue<string>(songsArray);

            while (true)
            {
                string commands = Console.ReadLine();

                if (songs.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }

                if (commands == "Play")
                {
                    songs.Dequeue();
                }
                else if (commands.Contains("Add"))
                {
                    if (songs.Contains(commands.Substring(4)))
                    {
                        Console.WriteLine($"{commands.Substring(4)} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(commands.Substring(4));
                    }
                }
                else
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }

        }
    }
}
